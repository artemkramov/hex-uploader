using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECR.Models
{
    class IntelHex
    {

        const int HEADER_LINES_COUNT = 3;

        private List<string> lines = new List<string>();

        private IntelHexHeaders headers = new IntelHexHeaders();

        public IntelHexHeaders Headers
        {
            private set { this.headers = value; }
            get { return this.headers; }
        }

        public void Load(Stream inputStream)
        {
            this.Clear();
            string line = "";
            StreamReader reader = new StreamReader(inputStream);
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }

        public void Clear()
        {
            this.lines.Clear();
            this.headers.Clear();
        }

        public void ParseHeaders()
        {
            if (lines.Count > HEADER_LINES_COUNT)
            {
                for (int i = 0; i < HEADER_LINES_COUNT; i++)
                {
                    this.headers.ParseLine(lines[i]);
                }
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public byte[] ToBinary()
        {
            List<string> rows = new List<string>(this.lines);
            /**
             * Remove header lines and prelast row
             */
            for (int i = 0; i < HEADER_LINES_COUNT; i++)
            {
                rows.RemoveAt(0);
            }
            rows.RemoveAt(rows.Count - 2);
            StringBuilder sbWrite = new StringBuilder();
            StringBuilder check = new StringBuilder();
            for (int i = 0; i < rows.Count; i++)
            {
                check.AppendLine(rows[i]);
                string binaryValue = "";
                rows[i] = rows[i].Substring(9);
                char[] charArray = rows[i].ToCharArray();

                if (charArray.Length > 32)
                {
                    binaryValue = new string(charArray, 0, 32);
                    sbWrite.Append(binaryValue);
                }
            }
            Serializer serializer = new Serializer();
            serializer.Deserialize(check.ToString());
            
            byte[] buffer = StringToByteArray(sbWrite.ToString());

            return buffer;
        }

    }

    class IntelHexHeaders
    {

        private string version;
        private string firmwareGUID;
        private string description;

        public string Version
        {
            private set { this.version = value; }
            get { return version; }
        }

        public string FirmwareGUID
        {
            private set { this.firmwareGUID = value; }
            get { return firmwareGUID; }
        }

        public string Description
        {
            private set { this.description = value; }
            get { return description; }
        }

        public void ParseLine(string headerLine)
        {
            /**
             * Remove extra symbols from the beginning
             */
            headerLine = headerLine.Substring(2);
            string[] words = headerLine.Split(' ');
            string keyWord = words[0];
            string data = String.Join(" ", words.Skip(1).ToArray());
            switch (words[0])
            {
                case "VERS":
                    this.Version = data;
                    break;
                case "GUID":
                    this.FirmwareGUID = data;
                    break;
                case "DESCR":
                    this.description = data;
                    break;
                default:
                    break;
            }
        }

        public void Clear()
        {
            this.Version = "";
            this.FirmwareGUID = "";
            this.Description = "";
        }


    }

    internal class Record
    {
        internal int Type { get; set; }
        internal int DataLength { get; set; }
        internal UInt16 Address { get; set; }
        internal byte[] Data { get; set; }

        internal byte Checksum
        {
            get
            {
                byte checksum;

                checksum = (byte)DataLength;
                checksum += (byte)Type;
                checksum += (byte)Address;
                checksum += (byte)((Address & 0xFF00) >> 8);

                for (int i = 0; i < DataLength; i++)
                {
                    checksum += Data[i];
                }

                checksum = (byte)(~checksum + 1);

                return checksum;
            }
        }

        public override String ToString()
        {
            String outcome;

            // store in little endian, show in big endian
            byte[] addressBytes = BitConverter.GetBytes(Address);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(addressBytes);

            outcome = String.Format("{0}{1:X2}{2:X2}{3:X2}{4:X2}", ':', DataLength, addressBytes[0], addressBytes[1], Type);

            for (int i = 0; i < DataLength; i++)
            {
                outcome += String.Format("{0:X2}", Data[i]);
            }

            outcome += String.Format("{0:X2}", Checksum);

            return outcome;
        }
    }

    public class Serializer
    {
        private const int START_CODE_OFFSET = 0;
        private const int START_CODE_LENGTH = 1;
        private const int BYTE_COUNT_OFFSET = START_CODE_OFFSET + START_CODE_LENGTH;
        private const int BYTE_COUNT_LENGTH = 2;
        private const int ADDRESS_OFFSET = BYTE_COUNT_OFFSET + BYTE_COUNT_LENGTH;
        private const int ADDRESS_LENGTH = 4;
        private const int RECORD_TYPE_OFFSET = ADDRESS_OFFSET + ADDRESS_LENGTH;
        private const int RECORD_TYPE_LENGTH = 2;
        private const int DATA_OFFSET = RECORD_TYPE_OFFSET + RECORD_TYPE_LENGTH;
        private const int CHECKSUM_LENGTH = 2;

        private int MinimumLineLength
        {
            get
            {
                return START_CODE_LENGTH + BYTE_COUNT_LENGTH + ADDRESS_LENGTH + RECORD_TYPE_LENGTH + CHECKSUM_LENGTH;
            }
        }

        private bool IsChecksumValid(String line, Record currentRecord)
        {
            byte current = Convert.ToByte(line.Substring(DATA_OFFSET + currentRecord.DataLength * 2, CHECKSUM_LENGTH), 16);

            return currentRecord.Checksum == current;
        }

        public String Serialize(byte[] source)
        {
            int i = 0, currentRecordIndex;
            Record[] records;
            String outcome;
            Record currentRecord;

            if (source.Length == 0)
            {
                return "";
            }

            records = new Record[source.Length / 255 + 2];
            currentRecord = null;
            currentRecordIndex = 0;

            for (i = 0; i < source.Length; i++)
            {
                if (i % 255 == 0)
                {
                    if (currentRecord != null)
                    {
                        records[currentRecordIndex++] = currentRecord;
                    }
                    currentRecord = new Record();
                    currentRecord.Type = 0;
                    currentRecord.Data = new byte[255];
                    currentRecord.Address = (ushort)((i / 255) * (256 + 12));
                    currentRecord.DataLength = 0;
                }

                currentRecord.Data[i % 255] = source[i];
                currentRecord.DataLength++;
            }

            if (currentRecord.DataLength > 0 && i % 255 != 0)
            {
                records[currentRecordIndex] = currentRecord;
            }

            var lastRecord = new Record();
            lastRecord.Type = 1;
            lastRecord.Address = 0;
            lastRecord.DataLength = 0;
            records[records.Length - 1] = lastRecord;

            outcome = "";
            i = 0;
            foreach (Record r in records)
            {
                outcome += r.ToString();
                if (i < records.Length - 1)
                {
                    outcome += Environment.NewLine;
                }
                i++;
            }

            return outcome;
        }

        public byte[] Deserialize(String source)
        {
            String[] lines = source.Split(Environment.NewLine.ToCharArray());
            lines = lines.Where(line => line.Length > 0).ToArray();
            Record[] records = new Record[lines.Length];
            byte[] outcome;
            int recordIndex = 0, finalDataSize = 0, outcomeIndex;

            foreach (String l in lines)
            {
                if (l.Length < MinimumLineLength)
                {
                    throw new IntelHexParserException(IntelHexParserException.Kind.INVALID_LINE);
                }

                Record current = new Record();

                if (l[0] != ':')
                {
                    throw new IntelHexParserException(IntelHexParserException.Kind.MISSING_START_CODE);
                }

                current.DataLength = Convert.ToInt16(l.Substring(BYTE_COUNT_OFFSET, BYTE_COUNT_LENGTH), 16);
                current.Address = Convert.ToUInt16(l.Substring(ADDRESS_OFFSET, ADDRESS_LENGTH), 16);
                current.Type = Convert.ToInt16(l.Substring(RECORD_TYPE_OFFSET, RECORD_TYPE_LENGTH), 16);

                if (current.Type != 0 && current.Type != 1)
                {
                    //throw new IntelHexParserException(IntelHexParserException.Kind.UNSUPPORTED_RECORD_TYPE);
                }

                current.Data = new byte[current.DataLength];

                for (int i = 0; i < current.DataLength; i++)
                {
                    current.Data[i] = Convert.ToByte(l.Substring(DATA_OFFSET + 2 * i, 2), 16);
                }

                if (!IsChecksumValid(l, current))
                {
                    throw new IntelHexParserException(IntelHexParserException.Kind.INVALID_CHECKSUM);
                }

                records[recordIndex++] = current;
                finalDataSize += current.DataLength;
            }

            outcome = new byte[finalDataSize];
            outcomeIndex = 0;
            for (int i = 0; i < records.Length; i++)
            {
                Record r = records[i];
                for (int j = 0; j < r.DataLength; j++)
                {
                    outcome[outcomeIndex++] = r.Data[j];
                }
            }

            return outcome;
        }
    }

    public class IntelHexParserException : Exception
    {
        public enum Kind
        {
            INVALID_LINE,
            MISSING_START_CODE,
            UNSUPPORTED_RECORD_TYPE,
            INVALID_CHECKSUM
        }

        public Kind MyKind { get; internal set; }

        internal IntelHexParserException(Kind kind)
            : base(kind.ToString())
        {
            this.MyKind = kind;
        }

    }
}

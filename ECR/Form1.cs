using ECR.Events;
using ECR.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECR
{
    public partial class MainForm : Form
    {

        private Validator validator;
        private ECRDevice device;
        private BackgroundWorker bgWorker = new BackgroundWorker();
        private IntelHex intelHex = new IntelHex();

        private NameValueCollection buttonStates = new NameValueCollection();

        public MainForm()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            //this.MaximumSize = new System.Drawing.Size(screenWidth, this.Height);
            InitializeComponent();
            validator = new Validator();
            device = new ECRDevice();
            device.HttpClient.HttpErrorEvent += OnHttpError;
            device.HttpErrorEvent += OnHttpError;
            ECRDictionary.InitTranslations();
        }

        private bool IsPanelDataValid(Panel panel, bool isErrorClear)
        {
            bool isValid = true;
            if (isErrorClear)
                errorProvider.Clear();
            foreach (Control control in panel.Controls)
            {
                string rules = (string)control.Tag;
                if (!String.IsNullOrWhiteSpace(rules))
                {
                    ValidationResult response = validator.Validate(control.Text, rules);
                    if (response.success == false)
                    {
                        isValid = false;

                        errorProvider.SetIconPadding(control, -20);
                        errorProvider.SetError(control, ECRDictionary.GetTranslation(response.message));
                    }
                }
            }
            return isValid;
        }

        private NameValueCollection FetchPanelData(Panel panel)
        {
            var list = new NameValueCollection();
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox)
                {
                    list[control.Name] = control.Text;
                }
                if (control is ComboBox)
                {
                    list[control.Name] = ((ComboBox)control).SelectedValue.ToString();
                }
            }
            return list;
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (IsPanelDataValid(panelLogin, true))
            {

                ChangePanelsState(false);

                LoadingButton(btnConnect);
                var panelData = this.FetchPanelData(panelLogin);
                try
                {
                    device.Connect(panelData["textboxIP"], panelData["textboxUsername"], panelData["textboxPassword"]);
                    Task<dynamic> task = Task.Factory.StartNew(() => device.GetState());
                    dynamic state = await task;
                    task.Dispose();
                    if (state != null)
                    {
                        Task taskLoadData = Task.Factory.StartNew(() => device.LoadDeviceData());
                        await taskLoadData;
                        taskLoadData.Dispose();

                        Task taskLoadDescriptions = Task.Factory.StartNew(() => device.LoadTranslations());
                        await taskLoadDescriptions;

                        Task<dynamic> taskLoadInformation = Task.Factory.StartNew(() => device.GetInformation());
                        dynamic information = await taskLoadInformation;
                        FillInformation(information);
                        panelInformation.Visible = true;

                        ResetButton(btnConnect);
                        ShowInfoMessage(ECRDictionary.GetTranslation("Connected successfully"));
                        ChangePanelsState(true);
                    }
                    else
                    {
                        ResetButton(btnConnect);
                    }
                }
                catch (Exception ex)
                {
                    ResetButton(btnConnect);
                    ShowErrorMessage(ECRDictionary.GetTranslation(ex.Message));
                }
            }
        }

        private void FillInformation(dynamic data)
        {
            lblInfoVersionValue.Text = data.fw_version;
            lblInfoDescriptionValue.Text = data.fw_descr;
            lblInfoFirmwareGUIDValue.Text = data.fw_guid;
            lblInfoHardwareGUIDValue.Text = data.hw_guid;
            lblInfoUploadLengthValue.Text = data.fw_upload_len;
        }
       

        private int ReadComboData(ComboBox combo)
        {
            var selectedItem = (ComboboxItem)combo.SelectedItem;
            return int.Parse(selectedItem.Value.ToString());
        }

        private async void SendReport(int reportType, Button currentButton)
        {
            try
            {
                LoadingButton(currentButton);
                Task<dynamic> task = Task.Factory.StartNew(() => device.SendReport(reportType));
                dynamic response = await task;

                ResetButton(currentButton);
            }
            catch (Exception) { }
        }

        private void LoadingButton(Button button)
        {
            buttonStates.Add(button.Name, button.Text);
            button.Text = ECRDictionary.GetTranslation("In work...");
            button.Enabled = false;
        }

        private void ResetButton(Button button)
        {
            string buttonText = buttonStates[button.Name];
            button.Text = buttonText;
            button.Enabled = true;
            buttonStates.Remove(button.Name);
        }

        private void OnHttpError(object sender, HttpErrorEventArgs e)
        {
            ShowErrorMessage(ECRDictionary.GetTranslation(e.Message));
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, ECRDictionary.GetTranslation("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfoMessage(string message)
        {
            MessageBox.Show(message, ECRDictionary.GetTranslation("Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void FillCombobox(List<ExpandoObject> list, string displayMember, string valueMember, ComboBox combo)
        {
            combo.Items.Clear();
            combo.DisplayMember = displayMember;
            combo.ValueMember = valueMember;
            foreach (ExpandoObject listItem in list)
            {
                var item = new ComboboxItem();
                item.Text = GetProperty((dynamic)listItem, displayMember);
                item.Value = GetProperty((dynamic)listItem, valueMember);
                combo.Items.Add(item);
            }
            if (list.Count > 0)
            {
                combo.Text = GetProperty((dynamic)list[0], displayMember);
            }
        }


        public static object GetProperty(object target, string name)
        {
            return Microsoft.VisualBasic.CompilerServices.Versioned.CallByName(target, name, CallType.Get);
        }

        private void ChangePanelsState(bool enabledState)
        {
            panelInformation.Enabled = enabledState;
            panelUpload.Enabled = enabledState;
            panelInformation.Enabled = enabledState;
        }

        public void RefreshHexInfo()
        {
            labelVersionValue.Text = this.intelHex.Headers.Version;
            labelDescriptionValue.Text = this.intelHex.Headers.Description;
            labelFirmwareGUIDValue.Text = this.intelHex.Headers.FirmwareGUID;
            tableLayoutPanel2.Visible = true;
            panelUploadControls.Visible = true;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            Stream inputStream = null;
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = "c:\\";
            fileDialog.Filter = "Hex files (*.hex)|*.hex";
            fileDialog.RestoreDirectory = true;
            DialogResult userReaction = fileDialog.ShowDialog();

            if (userReaction == DialogResult.OK)
            {
                try
                {
                    if ((inputStream = fileDialog.OpenFile()) != null)
                    {
                        labelFileName.Text = fileDialog.SafeFileName;
                        using (inputStream)
                        {
                            this.intelHex.Load(inputStream);
                            this.intelHex.ParseHeaders();
                            this.RefreshHexInfo();
                        }
                    }
                }
                catch (Exception)
                {
                    ShowErrorMessage(ECRDictionary.GetTranslation("Cannot open the file"));
                }
            }
            if (userReaction == DialogResult.Cancel || userReaction == DialogResult.Abort)
            {
                Clear();
            }
        }

        private void Clear()
        {
            labelFileName.Text = "";
            this.intelHex.Clear();
            this.RefreshHexInfo();
            tableLayoutPanel2.Visible = false;
            panelUploadControls.Visible = false;
            panelUploadProgress.Visible = false;
        }

        private async void btnUploadHex_Click(object sender, EventArgs e)
        {
            LoadingButton(btnUploadHex);
            FirmwareInfo firmwareInfo = new FirmwareInfo();
            firmwareInfo.Set("Version", intelHex.Headers.Version);
            firmwareInfo.Set("Description", intelHex.Headers.Description);
            firmwareInfo.Set("FirmwareGUID", intelHex.Headers.FirmwareGUID);
            Task<dynamic> task = Task.Factory.StartNew(() => device.SendFirmwareInfo(firmwareInfo));
            dynamic responseFirmwareInfo = await task;
            
            ResponseFirmware response = device.ParseFirmwareInfoResponse(responseFirmwareInfo);
            if (response.IsSuccess)
            {
                panelUploadProgress.Visible = true;
                try
                {
                    byte[] buffer = this.intelHex.ToBinary();
                    Task<dynamic> taskSend = Task.Factory.StartNew(() => device.SendHexFile(buffer));
                    dynamic responseFirmwareUpload = await taskSend;
                    
                    ResetButton(btnUploadHex);
                    panelUploadProgress.Visible = false;
                    response = device.ParseFirmwareUploadResponse(responseFirmwareUpload);
                    if (response.IsSuccess)
                    {
                        ShowInfoMessage(ECRDictionary.GetTranslation("Hex file was uploaded successfully"));
                    }
                    else
                    {
                        if (response.Error.Length > 0)
                            ShowErrorMessage(response.Error);
                    }
                }
                catch (IntelHexParserException)
                {
                    panelUploadProgress.Visible = false;
                    ResetButton(btnUploadHex);
                    ShowErrorMessage(ECRDictionary.GetTranslation("Invalid HEX format"));
                }
            }
            else
            {
                ResetButton(btnUploadHex);
                if (response.Error.Length > 0)
                    ShowErrorMessage(response.Error);
            }
        }

        private async void btnFlash_Click(object sender, EventArgs e)
        {
            LoadingButton(btnFlash);
            Task<dynamic> task = Task.Factory.StartNew(() => device.Flash());
            dynamic responseFirmwareInfo = await task;
            ResponseFirmware response = device.ParseFirmwareResponseBurn(responseFirmwareInfo);
            ResetButton(btnFlash);
            if (response.IsSuccess)
            {
                ShowInfoMessage(ECRDictionary.GetTranslation("Flash is starting..."));
                Clear();
                ChangePanelsState(false);
            }
            else
            {
                ResetButton(btnFlash);
                if (response.Error.Length > 0)
                    ShowErrorMessage(response.Error);
            }
        }


    }

  


}

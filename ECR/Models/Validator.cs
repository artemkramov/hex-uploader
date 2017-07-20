using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECR.Models
{

    /// <summary>
    /// Validate the form data
    /// </summary>
    class Validator
    {

        /// <summary>
        /// Delimiter for parsing of the rules
        /// </summary>
        public const char DELIMITER = '|';

        /// <summary>
        /// Separator for the decimal point
        /// </summary>
        const string DECIMAL_SEPARATOR = ".";

        /// <summary>
        /// List of errors
        /// </summary>
        private NameValueCollection errorList = new NameValueCollection();

        /// <summary>
        /// Init data
        /// </summary>
        public Validator()
        {
            errorList.Add("Required", "This field is required");
            errorList.Add("Max", "The field length must be less than {0}");
            errorList.Add("Float", "The field must be a number");
            errorList.Add("Byte", "The field must be a positive integer number");
            errorList.Add("Count", "Incorrect field (must be like 10)");
        }

        /// <summary>
        /// Get decimal point
        /// </summary>
        /// <returns></returns>
        public string GetDecimalDelimiter()
        {
            return DECIMAL_SEPARATOR;
        }

        /// <summary>
        /// Parse rules and run all validation methods
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        public ValidationResult Validate(string value, string rules)
        {
            var result = new ValidationResult();
            result.success = true;
            var ruleArray = rules.Split(DELIMITER);
            if (ruleArray.Length > 0)
            {
                foreach (string ruleName in ruleArray)
                {
                    var methodName = "Validate" + ruleName;
                    MethodInfo methodInfo = this.GetType().GetMethod(methodName);
                    
                    ValidationResult response = (ValidationResult)methodInfo.Invoke(this, new object[] { value, ruleName });
                    if (!response.success)
                    {
                        return response;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Required rule validation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ruleName"></param>
        /// <returns></returns>
        public ValidationResult ValidateRequired(string value, string ruleName)
        {
            var response = new ValidationResult();
            response.success = true;
            if (String.IsNullOrWhiteSpace(value))
            {
                response.success = false;
                response.message = errorList["Required"];
            }
            return response;
        }

        /// <summary>
        /// Float rule validation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ruleName"></param>
        /// <returns></returns>
        public ValidationResult ValidateFloat(string value, string ruleName)
        {
            var response = new ValidationResult();
            response.success = true;
            try
            {
                float temp = float.Parse(value);
            }
            catch (Exception)
            {
                response.success = false;
                response.message = errorList["Float"];
            }
            return response;
        }

        /// <summary>
        /// Positive integer number validation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ruleName"></param>
        /// <returns></returns>
        public ValidationResult ValidateByte(string value, string ruleName)
        {
            var response = new ValidationResult();
            response.success = true;
            try
            {
                float temp = byte.Parse(value);
            }
            catch (Exception)
            {
                response.success = false;
                response.message = errorList["Byte"];
            }
            return response;
        }

        /// <summary>
        /// Positive integer number validation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ruleName"></param>
        /// <returns></returns>
        public ValidationResult ValidateUlong(string value, string ruleName)
        {
            var response = new ValidationResult();
            response.success = true;
            try
            {
                float temp = ulong.Parse(value);
            }
            catch (Exception)
            {
                response.success = false;
                response.message = errorList["Byte"];
            }
            return response;
        }

        /// <summary>
        /// Count field validation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ruleName"></param>
        /// <returns></returns>
        public ValidationResult ValidateCount(string value, string ruleName)
        {
            var response = new ValidationResult();
            response.success = true;
            try
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    string[] parts = value.Split('.');
                    if (parts.Length > 1 && parts[1].Length > 3)
                    {
                        throw new Exception();
                    }
                    CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    ci.NumberFormat.NumberDecimalSeparator = DECIMAL_SEPARATOR;
                    float temp = float.Parse(value, NumberStyles.Float, ci);
                }
            }
            catch (Exception)
            {
                response.success = false;
                response.message = errorList["Count"];
            }
            return response;
        }

        /// <summary>
        /// Price field validation
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ruleName"></param>
        /// <returns></returns>
        public ValidationResult ValidatePrice(string value, string ruleName)
        {
            var response = new ValidationResult();
            response.success = true;
            try
            {
                CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                ci.NumberFormat.NumberDecimalSeparator = DECIMAL_SEPARATOR;
                ci.NumberFormat.NumberDecimalDigits = 2;
                float temp = float.Parse(value, NumberStyles.Float, ci);
            }
            catch (Exception)
            {
                response.success = false;
                response.message = errorList["Count"];
            }
            return response;
        }
    }
    
    /// <summary>
    /// Result of the validation
    /// </summary>
    struct ValidationResult
    {
        public bool success;
        public string message;

    }
}

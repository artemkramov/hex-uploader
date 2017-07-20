using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECR.Models
{
    class Validator
    {

        const char DELIMITER = '|';

        private NameValueCollection errorList = new NameValueCollection();

        public Validator()
        {
            errorList.Add("Required", "This field is required");
            errorList.Add("Max", "The field length must be less than {0}");
            errorList.Add("Float", "The field must be a number");
        }

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



    }
    
    struct ValidationResult
    {
        public bool success;
        public string message;

    }
}

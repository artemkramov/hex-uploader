using ECR.Events;
using ECR.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECR
{
    public partial class MainForm : Form
    {
        private Validator validator;
        private ECRDevice device;
        private BackgroundWorker bgWorker = new BackgroundWorker();

        private NameValueCollection buttonStates = new NameValueCollection();

        public MainForm()
        {
            InitializeComponent();
            validator = new Validator();
            device = new ECRDevice();
            device.HttpClient.HttpErrorEvent += OnHttpError;
            ECRDictionary.InitTranslations();
        }

        private bool IsPanelDataValid(Panel panel)
        {
            bool isValid = true;
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
            if (IsPanelDataValid(panelLogin))
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

                        FillFormPayment();
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

        private void btnXReport_Click(object sender, EventArgs e)
        {
            SendReport(ECRDevice.X_REPORT, btnXReport);
        }

        private void btnZReport_Click(object sender, EventArgs e)
        {
            SendReport(ECRDevice.Z_REPORT, btnZReport);
        }

        private void btnPaymentIn_Click(object sender, EventArgs e)
        {
            SendPayment(true, btnPaymentIn);
        }

        private void btnPaymentOut_Click(object sender, EventArgs e)
        {
            SendPayment(false, btnPaymentOut);
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

        private async void SendPayment(bool isIn, Button currentButton)
        {
            if (IsPanelDataValid(panelPayment))
            {
                try
                {
                    LoadingButton(currentButton);
                    float sum = Math.Abs(float.Parse(textboxSum.Text));
                    var selectedItem = (ComboboxItem)comboPaymentType.SelectedItem;
                    int number = int.Parse(selectedItem.Value.ToString());
                    if (isIn == false)
                    {
                        sum = -sum;
                    }
                    Task<dynamic> task = Task.Factory.StartNew(() => device.SendPayment(number, sum));
                    dynamic response = await task;

                    ResetButton(currentButton);
                }
                catch (Exception) { }
            }
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

        private void FillFormPayment()
        {
            comboPaymentType.Items.Clear();
            comboPaymentType.DisplayMember = "Name";
            comboPaymentType.ValueMember = "id";
            foreach (ExpandoObject paymentType in device.PaymentTypes)
            {
                var item = new ComboboxItem();
                item.Text = ((dynamic)paymentType).Name;
                item.Value = ((dynamic)paymentType).id;
                comboPaymentType.Items.Add(item);
            }
            if (device.PaymentTypes.Count > 0)
            {
                comboPaymentType.Text = ((dynamic)device.PaymentTypes[0]).Name;
            }
        }

        private void ChangePanelsState(bool enabledState)
        {
            panelPayment.Enabled = enabledState;
        }

    }
}

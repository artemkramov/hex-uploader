using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECR.CustomControls
{
    /// <summary>
    /// Class which defines custom combobox
    /// </summary>
    public partial class CustomCombobox : ComboBox
    {
        public CustomCombobox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECR.CustomControls
{
    public partial class CustomTextbox : TextBox
    {
        public CustomTextbox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            this.Width = 1000;
            base.OnPaint(pe);
        }
    }
}

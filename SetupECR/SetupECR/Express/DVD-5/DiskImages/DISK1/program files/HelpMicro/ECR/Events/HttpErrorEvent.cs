using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECR.Events
{
    class HttpErrorEventArgs : EventArgs
    {
        private string message;

        public string Message
        {
            get { return this.message;  }
            set { this.message = value; }
        }
    }
}

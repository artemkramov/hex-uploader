using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECR.Events
{
    /// <summary>
    /// Event class entity which for the handling of the http error data
    /// </summary>
    class HttpErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Message field
        /// </summary>
        private string message;

        /// <summary>
        /// Message property
        /// </summary>
        public string Message
        {
            get { return this.message;  }
            set { this.message = value; }
        }
    }
}

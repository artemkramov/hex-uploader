using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECR.Models
{
    /// <summary>
    /// Class which defines the combobox item from the windows form
    /// </summary>
    class ComboboxItem
    {
        /// <summary>
        /// DisplayMember value
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// ValueMember value
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Override ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Text;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SalsBreakdown.UserEntry {
    public interface IUserPrompts {
        string Ask(string prompt);
        void Display(string data);

        /// <summary>
        /// Adds multiple empty lines
        /// </summary>
        void DataBreak();
    }
}

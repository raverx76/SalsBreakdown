using System;
using System.Collections.Generic;
using System.Text;

namespace SalsBreakdown.UserEntry {
    public class ConsoleUerPrompt : IUserPrompts {
        public string Ask(string prompt) {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public void Display(string data) {
            Console.WriteLine(data);
        }

        public void DataBreak() {
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}

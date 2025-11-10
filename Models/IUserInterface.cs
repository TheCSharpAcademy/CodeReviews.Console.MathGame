using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame.Models
{
    internal interface IUserInterface
    {
        int PromptInt(string message, string color);
        void WriteSuccess();
        void WriteError();
        void WriteInfo(string message, string color);
        bool Confirm(string message);

        void displayGameResult(string message, string color, string duration);
    }
}

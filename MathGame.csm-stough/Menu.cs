using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class Menu
    {
        /// <summary>
        /// internal struct that encapsulates an option description and 
        /// the options Action delegate. This is really only so the
        /// optionPointers dictionary can be simplified.
        /// </summary>
        private struct Option
        {
            public string description;
            public Action operation;
        }

        private Dictionary<string, Option> optionPointers;
        private string menuHeader;
        private bool flattenSelectors;

        /// <summary>
        /// Initializes a new Menu object
        /// </summary>
        /// <param name="menuHeader">Text to be displayed in the menu header.</param>
        /// <param name="flattenSelectors">Shoul menu selectors be limited to Uppercase strings?</param>
        public Menu(string menuHeader, bool flattenSelectors = true)
        {
            optionPointers = new Dictionary<string, Option>();
            this.menuHeader = menuHeader;
            this.flattenSelectors = flattenSelectors;
        }

        /// <summary>
        /// Adds a new menu option.
        /// </summary>
        /// <param name="key">The selector for this option.</param>
        /// <param name="optionText">Text displayed for the option</param>
        /// <param name="value">Parameterless, and void return type function to call when selected</param>
        public void AddOption(string key, string optionText, Action value)
        {
            Option newOption = new Option() { description = optionText, operation = value };
            optionPointers[key] = newOption;
        }

        /// <summary>
        /// Selec an option in the menu
        /// </summary>
        /// <param name="key">The key of the option to select</param>
        public void SelectOption(string key)
        {
            if(Validate(key))
            {
                if(flattenSelectors) { key = key.ToUpper(); }
                optionPointers[key.Trim()].operation();
            }
        }

        /// <summary>
        /// Returns the string of the menu to display
        /// </summary>
        /// <returns>String representation of the menu</returns>
        public string GetMenuText()
        {
            string menuText = $"{menuHeader}:\n";
            menuText += "-----------------------------\n";
            foreach (string key in optionPointers.Keys)
            {
                menuText += $"{key} - {optionPointers[key].description}.\n";
            }
            menuText += "-----------------------------\n";

            return menuText;
        }
            
        /// <summary>
        /// Validates the user input
        /// </summary>
        /// <param name="key">Key selected</param>
        /// <returns>true or false for a valid selection</returns>
        private bool Validate(string key)
        {
            if (flattenSelectors)
            {
                return optionPointers.ContainsKey(key.Trim().ToUpper());
            }
            else
            {
                return optionPointers.ContainsKey(key.Trim());
            }
        }
    }
}

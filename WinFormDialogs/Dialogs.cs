using System.Diagnostics;
using System.Windows.Forms;

namespace WinFormDialogs
{
    public static class Dialogs
    {
        /// <summary>
        /// Prompt user for a question
        /// </summary>
        /// <param name="text">Question text</param>
        /// <returns>true or false</returns>
        /// <remarks>DebuggerStepThrough attribute stops the debugger from stepping into this method</remarks>
        [DebuggerStepThrough]
        public static bool Question(string text) => (MessageBox.Show(text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);

        /// <summary>
        /// Prompt user for a question
        /// </summary>
        /// <param name="text">Question text</param>
        /// <param name="title">Caption for dialog</param>
        /// <returns>true or false</returns>
        /// <remarks>DebuggerStepThrough attribute stops the debugger from stepping into this method</remarks>        
        [DebuggerStepThrough]
        public static bool Question(string text, string title) => (MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);

    }
}
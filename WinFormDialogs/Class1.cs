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
        public static bool Question(string text)
        {
            return (MessageBox.Show(
                text,
                Application.ProductName,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }
    }
}
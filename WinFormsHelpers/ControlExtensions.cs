using System;
using System.ComponentModel;

namespace WinFormsHelpers
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Determines if a control needs to be invoked to prevent a cross thread violation.
        /// </summary>
        /// <typeparam name="TControl">Control</typeparam>
        /// <param name="control">Control</param>
        /// <param name="action">Predicate to run</param>
        /// <example>
        /// <code title="From Form1" >
        /// private void OnTimedEvent(object source, ElapsedEventArgs e)
        /// {
        ///     ElapsedTimerLabel.InvokeIfRequired(label =>
        ///     {
        ///         label.Text = $"{e.SignalTime}";
        ///     });
        /// 
        ///     FileOperations.CheckIfNewIncomingFileIsNeeded();
        /// }
        /// </code>
        /// </example>
        public static void InvokeIfRequired<TControl>(this TControl control, Action<TControl> action) where TControl : ISynchronizeInvoke
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => action(control)), null);
            }
            else
            {
                action(control);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlOperationsEntityFrameworkCore.Models;

namespace BasicReadEntityFrameworkCore.LanguageExtensions
{
    public static class BindingSourceExtensions
    {
        /// <summary>
        /// Get current product
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static Product CurrentProduct(this  BindingSource sender) => (Product) sender.Current;

        /// <summary>
        /// Assert there is a current product
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool HasCurrent(this BindingSource sender) => sender.Current is not null;

        public static string ProductName(this BindingSource sender) => sender.CurrentProduct().ProductName;
        public static int ProductIdentifier(this BindingSource sender) => sender.CurrentProduct().ProductId;
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        /// Cast DataSource to a list of <see cref="Product"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static List<Product> Products(this BindingSource sender) => (List<Product>) sender.DataSource;
        /// <summary>
        /// Get current product
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static Product CurrentProduct([NotNull] this BindingSource sender) => (Product) sender.Current;

        /// <summary>
        /// Assert there is a current product
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool HasCurrent([NotNull] this BindingSource sender) => sender.Current is not null;

        public static string ProductName([NotNull] this BindingSource sender) => sender.CurrentProduct().ProductName;
        public static int ProductIdentifier([NotNull] this BindingSource sender) => sender.CurrentProduct().ProductId;
    }
}

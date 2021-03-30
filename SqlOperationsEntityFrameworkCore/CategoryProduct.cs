namespace SqlOperationsEntityFrameworkCore
{
    /// <summary>
    /// For showing grouping
    /// </summary>
    public class CategoryProduct
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public override string ToString() => $"{CategoryName}, {ProductName}";

    }
}
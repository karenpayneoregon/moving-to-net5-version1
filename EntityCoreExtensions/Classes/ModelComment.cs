namespace EntityCoreExtensions.Classes
{
    public class ModelComment
    {
        /// <summary>
        /// Property name
        /// </summary>
        public string Name { get; internal set; }
        /// <summary>
        /// Comment value
        /// </summary>
        public string Comment { get; internal set; }
        /// <summary>
        /// For debugging/validation
        /// </summary>
        public string Full => $"{Name}, {Comment}";
        /// <summary>
        /// For debugging/validation and/or to display in a user interface
        /// </summary>
        public override string ToString() => Name;

    }
}

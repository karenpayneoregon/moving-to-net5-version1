namespace PopulateComboBox.Classes
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CountryName { get; set; }
        public int ContactTypeIdentifier { get; set; }
        public int CountryIdentifier { get; set; }

        public override string ToString() => $"{Address} {City} {PostalCode} {CountryName}";

    }
}
namespace AmaryllisTestProject.DAL.Entities
{
    public class Car : BaseEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Class { get; set; }
        public int YearOfIssue { get; set; }
        public string RegistrationNumber { get; set; }
        public Order Order { get; set; }
    }
}

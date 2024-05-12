namespace AIComponents.Data.Domain
{
    public class Student : NodeBaseContextEntity
    {
        public Student()
        {
            FirstName = "";
            LastName = "";
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

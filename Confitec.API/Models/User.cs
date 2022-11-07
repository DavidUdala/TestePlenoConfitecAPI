namespace Confitec.API.Models
{
    public class User : IEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int Education { get; set; }
    }
}

namespace Confitec.API.Domain.Commands.Requests.User
{
    public abstract class AbstractUserRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int Education { get; set; }
    }
}

using System.Runtime.CompilerServices;

namespace Confitec.API.Domain.Commands.Responses
{
    public class GetAllResponse
    {
        public GetAllResponse(int id, string name, string lastName, string email, int education, DateTime birthDate)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Education = SetEducation(education);
            this.BirthDate = birthDate;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public DateTime BirthDate { get; set; }


        string SetEducation(int escolaridade)
        {
            switch (escolaridade)
            {
                case 0:
                    return  "Infantil";
                case 1:
                    return "Fundamental";
                case 2:
                    return "Médio";
                case 3:
                    return "Superior";
            }
            return "";
        }
    }
}

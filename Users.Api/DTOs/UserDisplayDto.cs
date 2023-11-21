using System.ComponentModel.DataAnnotations.Schema;

namespace Users.Api.Models
{
    public class UserDisplayDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public int PersonalNumber { get; set; }
        public string? UserName { get; set; }
        public List<string>? PostContent { get; set; }
    }
}

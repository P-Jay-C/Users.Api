namespace Users.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public int PersonalNumber { get; set; }

        public int? UserNameId { get; set; }
        public Username? Username { get; set; }

        public List<Post>? Posts { get; set; }

        public List<UserCommunity>? UserCommunities { get; set; }
    }
}

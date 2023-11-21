namespace Users.Api.Models
{
    public class Community
    {
        public int Id { get; set; }
        public int CommunityId { get; set; }

        public List<UserCommunity>? UserCommunities{ get; set; }
    }
}

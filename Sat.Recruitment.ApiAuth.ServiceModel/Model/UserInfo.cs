namespace Sat.Recruitment.ApiAuth.Model
{
    public class UserInfo
    {
        public Guid IdGuid { get; set; }
        public int Id { get; set; }
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}

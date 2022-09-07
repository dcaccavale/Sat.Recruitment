namespace Sat.Recruitment.Model.Entities
{
    /// <summary>
    /// Type of Users 
    /// </summary>
    public enum UserType
    {
        Normal,
        SuperUser,
        Premium

    }
    /// <summary>
    /// User class of bussiness model
    /// </summary>
    public class User : Entity
    {

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public UserType Type { get; set; }
        public decimal Money { get; set; }
       
    }

}
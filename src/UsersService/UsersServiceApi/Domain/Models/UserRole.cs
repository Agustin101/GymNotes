namespace UsersServiceApi.Domain.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int  Roleid { get; set; }
        public Role Role { get; set; }
    }
}

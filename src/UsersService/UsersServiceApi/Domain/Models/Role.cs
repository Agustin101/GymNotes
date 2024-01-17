namespace UsersServiceApi.Domain.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RolCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

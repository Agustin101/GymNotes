namespace UsersServiceApi.Application.Dtos
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime BirthDay { get; set; }
        public float Weigth { get; set; }
        public float Heigth { get; set; }
    }
}

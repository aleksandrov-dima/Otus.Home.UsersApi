namespace Otus.Home.UsersApi.Host.Models
{
    public class CreateOrEditUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
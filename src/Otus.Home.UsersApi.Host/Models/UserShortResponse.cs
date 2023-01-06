using System;

namespace Otus.Home.UsersApi.Host.Models
{
    public class UserShortResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Otus.Home.UsersApi.Core.Domain.Administration
{
    public class User
        :BaseEntity
    {
        [MaxLength(100)]
        public string FirstName { get; set; }
        
        [MaxLength(100)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [MaxLength(100)]
        public string Email { get; set; }
    }
}
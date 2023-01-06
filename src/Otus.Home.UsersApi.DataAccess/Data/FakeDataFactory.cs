using System;
using System.Collections.Generic;
using Otus.Home.UsersApi.Core.Domain.Administration;

namespace Otus.Home.UsersApi.DataAccess.Data
{
    public static class FakeDataFactory
    {
        public static IEnumerable<User> Users
        {
            get
            {
                var userId = Guid.Parse("a6c8c6b1-4349-45b0-ab31-244740aaf0f0");
                var user = new List<User>()
                {
                    new User()
                    {
                        Id = userId,
                        Email = "ivan_sergeev@mail.ru",
                        FirstName = "Иван",
                        LastName = "Петров"
                    }
                };

                return user;
            }
        }
    }
}
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
                var userId = new Guid();
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
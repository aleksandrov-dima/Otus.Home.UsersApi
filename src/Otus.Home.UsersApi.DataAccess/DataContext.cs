using System;
using Microsoft.EntityFrameworkCore;
using Otus.Home.UsersApi.Core.Domain.Administration;

namespace Otus.Home.UsersApi.DataAccess
{
    public sealed class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.LogTo(Console.WriteLine);
		}
	}
}
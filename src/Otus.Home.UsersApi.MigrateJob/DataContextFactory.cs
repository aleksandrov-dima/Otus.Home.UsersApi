using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Otus.Home.UsersApi.DataAccess;

namespace Otus.Home.UserApi.MigrateJob
{
	public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
	{

		public DataContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
			
			// получаем строку подключения из секретного Environment
			var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
			optionsBuilder.UseNpgsql(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
			optionsBuilder.UseSnakeCaseNamingConvention();
			return new DataContext(optionsBuilder.Options);
		}
	}
}
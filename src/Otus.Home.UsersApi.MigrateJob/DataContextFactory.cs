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

			// получаем конфигурацию из файла appsettings.json
			var builder = new ConfigurationBuilder();
			builder.SetBasePath(Directory.GetCurrentDirectory());
			builder.AddJsonFile("appsettings.json");
			IConfigurationRoot config = builder.Build();
			
			// получаем строку подключения из файла appsettings.json
			string connectionString = config.GetConnectionString("UsersDb");
			optionsBuilder.UseNpgsql(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
			optionsBuilder.UseSnakeCaseNamingConvention();
			return new DataContext(optionsBuilder.Options);
		}
	}
}
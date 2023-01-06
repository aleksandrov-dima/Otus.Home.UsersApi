using System;
using Microsoft.EntityFrameworkCore;

namespace Otus.Home.UserApi.MigrateJob
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var dataContext = new DataContextFactory().CreateDbContext(null))
			{
				dataContext.Database.Migrate();
			}
		}
	}
}
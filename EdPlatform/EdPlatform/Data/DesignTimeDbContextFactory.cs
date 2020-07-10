using EdPlatform.EFDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EdPlatform.Data
{
  public class DesignTimeDbContextFactory<T> : IDesignTimeDbContextFactory<T>
    where T : DbContext
  {
    public T CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<T>();

      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseSqlServer(connectionString);

      var dbContext = (T)Activator.CreateInstance(
          typeof(T),
          builder.Options);

      return dbContext;
    }

  }
  public class CodingBlastDesignTimeDbContextFactory : DesignTimeDbContextFactory<ApplicationDbContext>
  {
  }

  public class OtherDesignTimeDbContextFactory : DesignTimeDbContextFactory<EdPlatformDbContext>
  {
  }
}


using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DbCore;
using System;
using Microsoft.Extensions.Logging;

namespace TodoAPI;


public class DbCoreFactory
{
  public const string Key = "AppSettings:ConnectionString";
  private static string _nameOrConnectionString = null;
  private static ILoggerFactory _loggerFactory = null;

  public static void Init(IConfiguration Configuration)
  {
    _nameOrConnectionString = Configuration.GetValue<string>(Key);
  }

  public static DbCoreContext CreateDbCore()
  {
    var optionsBuilder = new DbContextOptionsBuilder<DbCoreContext>();
    var conn = new SqlConnection(_nameOrConnectionString);

    if (_nameOrConnectionString == null)
    {
      throw new Exception("DbCoreContext not initiliazed");
    }
    optionsBuilder.UseSqlServer(
      conn);
    return new DbCoreContext(optionsBuilder.Options);
  }

}
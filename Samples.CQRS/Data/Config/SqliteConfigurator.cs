using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using Environment = NHibernate.Cfg.Environment;
using System.Reflection;
using NHibernate.Connection;
using NHibernate.ByteCode.Castle;
using System.IO;

namespace MD.Samples.CQRS.Data
{
    public class SqliteConfigurator
    {
        public static ISessionFactory GetSessionFactory(string dbName, params Assembly[] assembliesWithMappings)
        {
            var dbFile = GetDbFileName(dbName);
            var _configuration = new Configuration()
            .SetProperty(Environment.ReleaseConnections, "on_close")
            .SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
            .SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
            .SetProperty(Environment.ConnectionProvider, typeof(DriverConnectionProvider).FullName)
            .SetProperty(Environment.Hbm2ddlAuto, "create")
            .SetProperty(Environment.ShowSql, true.ToString())
            .SetProperty(Environment.ConnectionString, string.Format("Data Source={0};Version=3;New=True;", dbFile))
            .SetProperty(Environment.ProxyFactoryFactoryClass, typeof(ProxyFactoryFactory).AssemblyQualifiedName);
            
            foreach (var assembly in assembliesWithMappings)
            {
                _configuration.AddAssembly(assembly);
            }

            return _configuration.BuildSessionFactory();
        }

        private static string GetDbFileName(string dbName)
        {
            var path = Path.GetFullPath(string.Format(@"c:\data\{0}", dbName));
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            return path;
        }
    }
}
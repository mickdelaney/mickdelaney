using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using System.Reflection;
using NHibernate.Tool.hbm2ddl;
using MD.Samples.CQRS.Orders.Domain;

namespace MD.Samples.CQRS.Data
{
    public static class SqlServerConfigurator
    {
        public static ISessionFactory GetSessionFactory(bool export, params Assembly[] assembliesWithMappings)
        {
            var _configuration = Fluently.Configure()
                                        .Database(MsSqlConfiguration.MsSql2008
                                        .ConnectionString(c => c.FromAppSetting("connectionString"))
                                        .ShowSql());

            foreach (var assembly in assembliesWithMappings)
            {
                _configuration.Mappings(m => m.FluentMappings.Add<ProductMap>());
                _configuration.Mappings(m => m.FluentMappings.Add<OrderMap>());
                _configuration.Mappings(m => m.FluentMappings.Add<UserMap>());
            }

            var cfg = _configuration.BuildConfiguration();
            var factory = cfg.BuildSessionFactory();

            if (export)
            {
                ISession session = factory.OpenSession();
                new SchemaExport(cfg).Execute(true, true, false, session.Connection, Console.Out);
            }

            return factory;
        }
    }
}

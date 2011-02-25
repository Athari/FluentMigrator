﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using FluentMigrator.Runner.Generators;
using Npgsql;

namespace FluentMigrator.Runner.Processors.Postgres
{
    public class PostgresProcessorFactory : MigrationProcessorFactory
    {
        public override IMigrationProcessor Create(string connectionString, IAnnouncer announcer, IMigrationProcessorOptions options)
        {
            var connection = new NpgsqlConnection(connectionString);
            return new PostgresProcessor(connection, new PostgresGenerator(), announcer, options);
        }

        public override IMigrationProcessor Create(IDbConnection connection, IAnnouncer announcer, IMigrationProcessorOptions options)
        {
            return new PostgresProcessor((NpgsqlConnection) connection, new PostgresGenerator(), announcer, options);
        }
    }
}

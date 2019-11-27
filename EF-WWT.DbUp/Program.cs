using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using DbUp;
using DbUp.Builder;
using DbUp.Engine;
using DbUp.Helpers;

namespace EF_WWT.DbUp
{
    public class Program
    {
        public static string EFWWTConnectionString => ConfigurationManager.ConnectionStrings["EFWWTConnectionString"].ConnectionString;

        private static string MigrationFolderName => "Migrations";
        private static string LoaderFolderName => "Loaders";

        static int Main(string[] args)
        {
            try
            {
                //DropDatabase.For.SqlDatabase(EFWWTConnectionString);
                EnsureDatabase.For.SqlDatabase(EFWWTConnectionString);


                var upgradeEngineBuilder = DeployChanges.To
                   .SqlDatabase(EFWWTConnectionString)
                   .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                   .LogToConsole();

                var upgrader = upgradeEngineBuilder.Build();

                var result = upgrader.PerformUpgrade();

                if (!result.Successful)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.Error);
                    Console.ResetColor();

#if DEBUG
                    Console.ReadLine();
#endif
                    return -1;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!");
                Console.ResetColor();
                return 0;
                //var initScripts = GetSqlScripts(InitStateFolderName).ToList();
                //var dbInitResult = Migrate(EFWWTConnectionString, initScripts, false, false);

                //var scripts = GetSqlScripts(MigrationFolderName).ToList();
                //var dbUpgradeResult = Migrate(EFWWTConnectionString, scripts, true, false);

                //var loaderScripts = GetSqlScripts(LoaderFolderName).ToList();
                //var dbLoaderResult = Migrate(EFWWTConnectionString, loaderScripts, true, true);

                //Console.WriteLine($"Db upgrade executed with result {dbUpgradeResult.Successful}");
                //Debug.WriteLine($"Db upgrade executed with result {dbUpgradeResult.Successful}");
                //if (!dbUpgradeResult.Successful)
                //{
                //    Console.WriteLine($"Db upgrade exception thrown: {dbUpgradeResult.Error}");
                //    Debug.WriteLine($"Db upgrade exception thrown: {dbUpgradeResult.Error}");
                //}

                //Environment.Exit(dbUpgradeResult.Successful ? 0 : 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Db upgrade exception thrown: {ex.ToString()}");
                Debug.WriteLine($"Exception: {ex.ToString()}");
                Environment.Exit(1);

                return -1;
            }
        }
        private static void WWTEnsureDatabase(string connectionString)
        {
            string databaseName = null;
            
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            databaseName = builder.InitialCatalog; 
            builder.InitialCatalog = "master";

            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $@"If not Exists(SELECT name, database_id FROM sys.databases where name = '{databaseName}')
                                        BEGIN 
                                            CREATE DATABASE {databaseName};
                                        END";
                command.CommandTimeout = 120;
                command.ExecuteNonQuery();
                connection.Close();
            }
        }


        private static DatabaseUpgradeResult Migrate(string connectionString, List<SqlScript> scripts, bool executeInTransaction, bool ignoreJournal)
        {
            UpgradeEngineBuilder upgrader;

            if (executeInTransaction)
            {
                upgrader = DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .LogScriptOutput();
            }
            else
            {
                upgrader = DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .LogScriptOutput();
            }

            if (ignoreJournal)
                upgrader.JournalTo(new NullJournal());

            upgrader.Configure(c =>
            {
                c.ScriptExecutor.ExecutionTimeoutSeconds = 40 * 60;
            });

            var engineUpgrader = upgrader.Build();

            return engineUpgrader.PerformUpgrade();
        }

        private static IEnumerable<SqlScript> GetSqlScripts(string path)
        {
            var result = new List<SqlScript>();
            var directory = new DirectoryInfo(path);

            FileInfo[] files = directory.Exists ? directory.GetFiles("*.sql", SearchOption.TopDirectoryOnly) : new FileInfo[0];

            foreach (var file in files)
            {
                var content = File.ReadAllText(file.FullName);
                result.Add(new SqlScript(file.Name, content));
            }
            return result;
        }
    }
}

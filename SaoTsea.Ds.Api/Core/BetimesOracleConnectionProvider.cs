using System;
using System.Data;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Helpers;

namespace SaoTsea.Ds.Api.Core
{
    public class BetimesOracleConnectionProvider : ODPManagedConnectionProvider
    {

        public BetimesOracleConnectionProvider(IDbConnection connection, AutoCreateOption autoCreateOption) : base(connection, autoCreateOption)
        {

        }

        public override string ComposeSafeTableName(string tableName)
        {
            return base.ComposeSafeTableName(tableName).ToUpper();
        }

        public override string ComposeSafeColumnName(string columnName)
        {
            return columnName.ToUpper();
        }

        protected override string GetSeqName(string tableName)
        {
            return base.GetSeqName(tableName).ToUpper();
        }

        public new static IDataStore CreateProviderFromString(
            string connectionString,
            AutoCreateOption autoCreateOption,
            out IDisposable[] objectsToDisposeOnDisconnect)
        {
            IDbConnection connection = BetimesOracleConnectionProvider.CreateConnection(connectionString);
            objectsToDisposeOnDisconnect = new IDisposable[1]
            {
                (IDisposable) connection
            };
            return BetimesOracleConnectionProvider.CreateProviderFromConnection(connection, autoCreateOption);
        }

        public new static IDataStore CreateProviderFromConnection(IDbConnection connection, AutoCreateOption autoCreateOption)
        {
            return (IDataStore)new BetimesOracleConnectionProvider(connection, autoCreateOption);
        }

        public new static void Register()
        {
            DataStoreBase.RegisterDataStoreProvider("ODPManaged", new DataStoreCreationFromStringDelegate(BetimesOracleConnectionProvider.CreateProviderFromString));
            DataStoreBase.RegisterDataStoreProvider("Oracle.ManagedDataAccess.Client.OracleConnection", new DataStoreCreationFromConnectionDelegate(BetimesOracleConnectionProvider.CreateProviderFromConnection));
        }
    }
}

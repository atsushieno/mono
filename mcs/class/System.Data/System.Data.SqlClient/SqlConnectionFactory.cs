//
// System.Data.SqlClient.SqlConnectionFactory
//
// Author:
//   Sureshkumar T <tsureshkumar@novell.com>
//
//
// Copyright (C) 2005 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//


using System.Data;
using System.Data.Common;
using System.Data.ProviderBase;

namespace System.Data.SqlClient {
	internal class SqlConnectionFactory : DbConnectionFactory
	{
		#region Fields
		internal static SqlConnectionFactory Instance; // singleton
                private static DbProviderFactory _providerFactory;
		static readonly object lockobj = new object ();
		#endregion // Fields

		#region Constructors

		private SqlConnectionFactory (DbProviderFactory pvdrfactory)
		{
                        _providerFactory = pvdrfactory;
		}

		#endregion // Constructors

		#region Properties

		public override DbProviderFactory ProviderFactory { get { return _providerFactory; }}

		#endregion // Properties

		#region Methods

		// create singleton connection factory.
		internal static DbConnectionFactory GetSingleton (DbProviderFactory pvdrFactory)
		{
			lock (lockobj) {
				if (Instance == null)
					Instance = new SqlConnectionFactory (pvdrFactory);
				return Instance;
			}
		}

                [MonoTODO]
        override protected DbConnectionInternal CreateConnection(DbConnectionOptions options, DbConnectionPoolKey poolKey, object poolGroupProviderInfo, DbConnectionPool pool, DbConnection owningConnection, DbConnectionOptions userOptions) {
                        throw new NotImplementedException ();
                }
                
                [MonoTODO]
		protected override DbConnectionOptions CreateConnectionOptions (string connectionString, DbConnectionOptions previous)
                {
                        throw new NotImplementedException ();
                }

                [MonoTODO]
                override internal DbConnectionPoolProviderInfo CreateConnectionPoolProviderInfo(DbConnectionOptions connectionOptions)
                {
                        throw new NotImplementedException ();
                }


		[MonoTODO]
                override protected DbMetaDataFactory CreateMetaDataFactory (DbConnectionInternal internalConnection, out bool cacheMetaDataFactory)
                {
                        throw new NotImplementedException ();
                }

		#endregion // Methods
        }
}


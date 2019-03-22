using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace ContactUs.DAO
{
    public class DapperDAO
    {
        #region Const

        private const string CONNECTION_STRING_KEY = "ContactUsConnection";

        #endregion Const

        #region Properties

        private readonly string _connectionString;

        #endregion Properties

        #region Constructor

        public DapperDAO() =>
            _connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_KEY].ConnectionString;

        #endregion Constructor

        #region Public Methods

        protected void ExecQuery(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sql: query, param: parameters);
            }
        }

        protected T GetFirstOrDefault<T>(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                IEnumerable<T> result = connection.Query<T>(sql: query, param: parameters);
                return result.FirstOrDefault();
            }
        }

        protected IEnumerable<T> GetList<T>(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<T>(sql: query, param: parameters);
            }
        }
        
        #endregion Public Methods
    }
}
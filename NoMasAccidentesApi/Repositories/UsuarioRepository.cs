using Dapper;
using Microsoft.Extensions.Configuration;
using NoMasAccidentesApi.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        IConfiguration configuration;

        public UsuarioRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object GetUserLogin(Login login)
        {
            //object result = null;
            dynamic result = null;
            try
            {

                var dyParam = new OracleDynamicParameters();
                dyParam.Add("U_USERNAME", OracleDbType.Char, ParameterDirection.Input, login.username);
                dyParam.Add("U_CLAVE", OracleDbType.Char, ParameterDirection.Input, login.clave);
                dyParam.Add("EMP_DETAIL_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);


                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_LOGIN_USER";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }


        private IDbConnection GetConnection()
        {
            var conectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(conectionString);
            return conn;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using NoMasAccidentesApi.Models;
using Oracle.ManagedDataAccess.Client;

namespace NoMasAccidentesApi.Repositories
{
    public class RubroRepository : IRubroRepository
    {

        IConfiguration configuration;

        public RubroRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }


        public object DeleteRubro(int id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("r_id", OracleDbType.Int32, ParameterDirection.Input, id);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_DELETE_RUBRO";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object EditaRubro(Rubro rubro, int id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("r_id", OracleDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("r_nombre", OracleDbType.Char, ParameterDirection.Input, rubro.rubro_nombre);
                dyParam.Add("r_activo", OracleDbType.Int32, ParameterDirection.Input, rubro.rubro_activo);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_EDITA_RUBRO";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object GetRubro()
        {

            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_GET_RUBRO";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object InsertRubro(Rubro rubro)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("r_nombre", OracleDbType.Varchar2, ParameterDirection.Input, rubro.rubro_nombre);
                dyParam.Add("r_activo", OracleDbType.Int32, ParameterDirection.Input, rubro.rubro_activo);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_RUBRO";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rubro;
        }

        private IDbConnection GetConnection()
        {
            var conectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(conectionString);
            return conn;
        }
    }
}

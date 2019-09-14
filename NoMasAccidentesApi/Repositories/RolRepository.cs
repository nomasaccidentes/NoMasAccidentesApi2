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
    public class RolRepository : IRolRepository
    {

        IConfiguration configuration;

        public RolRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }



        public object GetRol()
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
                    var query = "SP_GETROL";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object InsertRol(Rol rol)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("r_nombre", OracleDbType.Varchar2, ParameterDirection.Input, rol.rol_nombre);
                dyParam.Add("r_activo", OracleDbType.Int32, ParameterDirection.Input, rol.rol_activo);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_ROL";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return rol;
        }

        public object DeleteRol(int id)
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
                    var query = "SP_DELETE_ROL";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public object EditaRol(Rol rol, int id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("r_id", OracleDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("r_nombre", OracleDbType.Char, ParameterDirection.Input, rol.rol_nombre);
                dyParam.Add("r_activo", OracleDbType.Int32, ParameterDirection.Input, rol.rol_activo);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_EDITA_ROL";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
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

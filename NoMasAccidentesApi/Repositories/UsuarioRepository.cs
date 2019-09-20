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


        public object GetUsuarios()
        {
            //object result = null;
            dynamic result = null;
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
                    var query = "SP_GET_USUARIOS";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }


        public object DeleteUsuario(int id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("u_id", OracleDbType.Int32, ParameterDirection.Input, id);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_DELETE_USUARIO";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object EditaUsuario(Usuario usuario, int id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("u_id", OracleDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("u_activo", OracleDbType.Char, ParameterDirection.Input, usuario.usuario_activo);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_EDITA_USUARIO";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object InsertUsuario(UsuarioInsert usuario)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("u_username", OracleDbType.Varchar2, ParameterDirection.Input, usuario.usuario_username);
                dyParam.Add("u_clave", OracleDbType.Varchar2, ParameterDirection.Input, usuario.usuario_clave);
                dyParam.Add("u_activo", OracleDbType.Int32, ParameterDirection.Input, usuario.usuario_activo);
                dyParam.Add("c_id", OracleDbType.Single, ParameterDirection.Input, usuario.cliente_id);
                dyParam.Add("p_id", OracleDbType.Single, ParameterDirection.Input, usuario.profesional_id);
                dyParam.Add("r_id", OracleDbType.Single, ParameterDirection.Input, usuario.rol_id);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_USUARIO";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return usuario;
        }


        private IDbConnection GetConnection()
        {
            var conectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(conectionString);
            return conn;
        }

    }
}

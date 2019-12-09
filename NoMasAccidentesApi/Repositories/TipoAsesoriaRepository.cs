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
    public class TipoAsesoriaRepository : ITipoAsesoriaRepository
    {

        IConfiguration configuration;

        public TipoAsesoriaRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object editTipoAsesoria(TipoAsesoria asesoria, int id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("ta_id", OracleDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("ta_nombre", OracleDbType.Varchar2, ParameterDirection.Input, asesoria.tipoAsesoriaNombre);
                dyParam.Add("ta_estado", OracleDbType.Int32, ParameterDirection.Input, asesoria.tipoAsesoriaActivo);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_EDITA_TIPO_ASESORIA";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }   

        public object elimiaTipoAsesoria(int id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("ta_id", OracleDbType.Int32, ParameterDirection.Input, id);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_DELETE_TIPO_ASESORIA";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object getTipoAsesoria()
        {
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
                    var query = "SP_GET_TIPO_ASESORIA";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToArray();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object insertTipoAsesoria(TipoAsesoria tipo)
        {
            
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("ta_nombre", OracleDbType.Varchar2, ParameterDirection.Input, tipo.tipoAsesoriaNombre);
                dyParam.Add("ta_estado", OracleDbType.Int32, ParameterDirection.Input, tipo.tipoAsesoriaActivo);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_TIPO_ASESORIA";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tipo;
        }

        public object obtieneIdPorNombre(TipoAsesoria asesoria)
        {
            

         dynamic result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("ta_nombre", OracleDbType.Varchar2, ParameterDirection.Input, asesoria.tipoAsesoriaNombre);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_OBTIENE_ID_TIPO_ASESORIA";

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

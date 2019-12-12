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
    public class AsesoriaEspecialRepository : IAsesoriaEspecialRepository
    {

        IConfiguration configuration;

        public AsesoriaEspecialRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object cerrarAsesoria(AsesoriaEspecial asesoria, int asesoria_id)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("a_id", OracleDbType.Int32, ParameterDirection.Input, asesoria_id);
                dyParam.Add("a_resolucion", OracleDbType.Varchar2, ParameterDirection.Input, asesoria.asesoriaComentarioResolucion);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_EDITA_ASESORIA_ESP_CIERRE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object getAsesoriaByContrato(int contrato_id)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("ae_contrato_id", OracleDbType.Int32, ParameterDirection.Input, contrato_id);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);



                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_GET_ASE_ESP_BY_CON";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object getAsesoriaById(int id)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("aed_id", OracleDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);



                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_GET_ASE_ESP_BY_ID";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object getAsesorias()
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
                    var query = "SP_GET_ASE_ESPECIAL";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }


                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
            return result;

            
        }

        public object insertAsesoria(AsesoriaEspecial asesoria)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("ae_nombre", OracleDbType.Varchar2, ParameterDirection.Input, asesoria.asesoriaEspecialNombre);
                dyParam.Add("ae_fecha", OracleDbType.Date, ParameterDirection.Input, asesoria.asesoriaEspecialFecha);
                dyParam.Add("ae_contrato_id", OracleDbType.Int32, ParameterDirection.Input, asesoria.contratoId);
                dyParam.Add("ae_profesional_id", OracleDbType.Int32, ParameterDirection.Input, asesoria.profesionalId);
                dyParam.Add("a_tipo_asesoria", OracleDbType.Int32, ParameterDirection.Input, asesoria.tipoAsesoriaEspecialId);



                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_ASESORIA_ESPECIAL";

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

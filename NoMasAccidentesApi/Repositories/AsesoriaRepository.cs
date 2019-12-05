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
    public class AsesoriaRepository : IAsesoriaRepository
    {

        IConfiguration configuration;

        public AsesoriaRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object cerrarAsesoria(Asesoria asesoria, int asesoria_id)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("a_id", OracleDbType.Int32, ParameterDirection.Input, asesoria_id);
                dyParam.Add("a_resolucion", OracleDbType.Int32, ParameterDirection.Input, asesoria.asesoria_resolicion);



                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_EDITA_ASESORIA_CIERRE";

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

                dyParam.Add("a_contrato_id", OracleDbType.Int32, ParameterDirection.Input, contrato_id);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);



                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_GET_ASESORIA_CONTRATO";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
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
                    var query = "SP_GET_ASESORIAS";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object insertAsesoria(Asesoria asesoria)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("a_detalle", OracleDbType.Varchar2, ParameterDirection.Input, asesoria.asesoria_detalle);
                dyParam.Add("a_fecha", OracleDbType.Date, ParameterDirection.Input, asesoria.asesoria_fecha);
                dyParam.Add("a_contrato", OracleDbType.Int32, ParameterDirection.Input, asesoria.contrato_id);
                dyParam.Add("a_profesional", OracleDbType.Int32, ParameterDirection.Input, asesoria.profesional_id);



                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_ASESORIA";

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

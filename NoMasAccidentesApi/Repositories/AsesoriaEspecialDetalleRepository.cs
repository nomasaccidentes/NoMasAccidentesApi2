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
    public class AsesoriaEspecialDetalleRepository : IAsesoriaEspecialDetalleRepository
    {

        IConfiguration configuration;

        public AsesoriaEspecialDetalleRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object getAsesoriaEspecialDetalle()
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
                    var query = "SP_GET_ASE_ESP_DET";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToArray();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object getAsesoriaEspecialDetalleByAsesoria(int asesoriaId)
        {
            dynamic result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("aed_id", OracleDbType.Int32, ParameterDirection.Input, asesoriaId);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_GET_ASE_ESP_DET_BY_ID";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object insertAsesoriaEspecialDetalle(AsesoriaEspecialDetalle asesoria)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("aed_titulo", OracleDbType.Varchar2, ParameterDirection.Input, asesoria.asesoriaEspecialDetalleTitulo);
                dyParam.Add("aed_check", OracleDbType.Int32, ParameterDirection.Input, asesoria.asesoriaEspecialDetalleCheck);
                dyParam.Add("aed_asesoria_id", OracleDbType.Int32, ParameterDirection.Input, asesoria.asesoriaEspecialId);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_ASESORIA_ESPECIAL_D";

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

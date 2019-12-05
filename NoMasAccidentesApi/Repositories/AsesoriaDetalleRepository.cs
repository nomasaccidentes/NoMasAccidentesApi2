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
    public class AsesoriaDetalleRepository : IAsesoriaDetalleRepository
    {

        IConfiguration configuration;

        public AsesoriaDetalleRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object getAsesoriaDetalle()
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
                    var query = "SP_GET_ASESORIA_DET";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToArray();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object getAsesoriaDetalleByAsesoria(int asesoriaId)
        {
            dynamic result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("a_id", OracleDbType.Int32, ParameterDirection.Input, asesoriaId);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_GET_ASESORIA_DET_BY_ID";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToArray();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }


        public object insertAsesoriaDetalle(AsesoriaDetalle asesoria)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("ad_titulo", OracleDbType.Varchar2, ParameterDirection.Input, asesoria.asesoriaDetalleTitulo);
                dyParam.Add("ad_check", OracleDbType.Int32, ParameterDirection.Input, asesoria.asesoriaDetalleCheck);
                dyParam.Add("a_id", OracleDbType.Int32, ParameterDirection.Input, asesoria.asesoriaId);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_ASESORIA_DETALLE";

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

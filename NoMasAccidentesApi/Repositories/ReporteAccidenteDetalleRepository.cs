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
    public class ReporteAccidenteDetalleRepository : IReporteAccidenteDetalleRepository
    {
        IConfiguration configuration;

        public ReporteAccidenteDetalleRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object getReporteAccidenteDetalleByContratoId(int registroAccidente)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("ra_id", OracleDbType.Int32, ParameterDirection.Input, registroAccidente);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_GET_REGISTRO_ACC_DET_BY_ID";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object getReporteAccienteDetalle()
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
                    var query = "SP_GET_REGISTRO_ACC_DET";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToArray();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object insertRegistroAccidenteDetalle(RegistroAccidenteDetalle reg_detalle)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("rd_nombre", OracleDbType.Varchar2, ParameterDirection.Input, reg_detalle.registroAccidenteDetalleNombre);
                dyParam.Add("rd_usuario", OracleDbType.Varchar2, ParameterDirection.Input, reg_detalle.registroAccidenteDetalleUsuario);
                dyParam.Add("rd_fecha", OracleDbType.Date, ParameterDirection.Input, reg_detalle.registroAccidenteDetalleFecha);
                dyParam.Add("rd_reg_id", OracleDbType.Int32, ParameterDirection.Input, reg_detalle.registroAccidenteId);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_REGISTRO_ACC_DET";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return reg_detalle;
        }

        private IDbConnection GetConnection()
        {
            var conectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(conectionString);
            return conn;
        }
    }
}

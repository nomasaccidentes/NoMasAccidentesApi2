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
    public class CapacitacionRepository : ICapacitacionRepository
    {
        IConfiguration configuration;

        public CapacitacionRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object getCapacitacionByContrato(int id)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("c_contrato_id", OracleDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_GET_CAPACITACIONES_ById";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object getCapacitaciones()
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
                    var query = "SP_GET_CAPACITACIONES";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object insertCapacitacion(Capacitacion capacitacion)
        {
             object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("c_detalle", OracleDbType.Varchar2, ParameterDirection.Input, capacitacion.capacitacionDetalle);
                dyParam.Add("c_fecha", OracleDbType.Date, ParameterDirection.Input, capacitacion.capacitacionFecha);
                dyParam.Add("c_contrato_id", OracleDbType.Int32, ParameterDirection.Input, capacitacion.contrato_id);
                dyParam.Add("c_profesional_id", OracleDbType.Int32, ParameterDirection.Input, capacitacion.profesionalId);
                
                    

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_CAPACITACION";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return capacitacion;
        }



        private IDbConnection GetConnection()
        {
            var conectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(conectionString);
            return conn;
        }
    }
}

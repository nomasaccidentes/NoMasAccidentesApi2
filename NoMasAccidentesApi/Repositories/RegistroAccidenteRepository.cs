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
    public class RegistroAccidenteRepository : IRegistroAccidenteRepository
    {

        IConfiguration configuration;

        public RegistroAccidenteRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object getAccidentes()
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
                    var query = "SP_GET_REGISTRO_ACCIDENTE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToArray();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object getAccidentesByContratoId(int contratoId)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("c_contrato", OracleDbType.Int32, ParameterDirection.Input, contratoId);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_GET_REGISTRO_ACC_BY_CON";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object insertRegistroAccidente(RegistroAccidente registro)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("r_nombre", OracleDbType.Varchar2, ParameterDirection.Input, registro.regigstroAccidenteNombre);
                dyParam.Add("r_fecha", OracleDbType.Date, ParameterDirection.Input, registro.registroAccidenteFecha);
                dyParam.Add("p_id", OracleDbType.Int32, ParameterDirection.Input, registro.profesionalId);
                dyParam.Add("c_id", OracleDbType.Int32, ParameterDirection.Input, registro.contratoId);
                dyParam.Add("a_id", OracleDbType.Int32, ParameterDirection.Input, registro.asesoriaId);
                


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_REGISTRO_ACCIDENTE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return registro;
        }

        private IDbConnection GetConnection()
        {
            var conectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(conectionString);
            return conn;
        }
    }
}

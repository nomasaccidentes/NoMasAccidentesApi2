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
    public class ContratoRepository : IContratoRepository
    {

        IConfiguration configuration;

        public ContratoRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object GetContrato()
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
                    var query = "SP_GET_CONTRATO";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToArray();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object GetContratoByCliente(int id)
        {
            dynamic result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("c_id", OracleDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_GET_CONTRATO_BY_ID_CLIENTE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToArray();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object InserContrato(Contrato contrato)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("c_descripcion", OracleDbType.Varchar2, ParameterDirection.Input, contrato.contrato_descripcion);
                dyParam.Add("c_fecha_ini", OracleDbType.Date, ParameterDirection.Input, contrato.contrato_fecha_inicio);
                dyParam.Add("c_fecha_fin", OracleDbType.Date, ParameterDirection.Input, contrato.contrato_fecha_fin);
                dyParam.Add("c_cant_cap", OracleDbType.Int32, ParameterDirection.Input, contrato.cant_capacitacion);
                dyParam.Add("c_cant_ase", OracleDbType.Int32, ParameterDirection.Input, contrato.cant_asesoria);
                dyParam.Add("c_activo", OracleDbType.Int32, ParameterDirection.Input, contrato.contrato_activo);
                dyParam.Add("c_cliente_id", OracleDbType.Int32, ParameterDirection.Input, contrato.cliente_id);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_CONTRATO";

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

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
    public class ClienteRepository : IClienteRepository
    {

        IConfiguration configuration;

        public ClienteRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }


        public object DeleteCliente(int id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("c_id", OracleDbType.Int32, ParameterDirection.Input, id);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_DELETE_CLIENTE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object EditaCliente(Cliente cliente, int id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("c_id", OracleDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("c_nombre", OracleDbType.Varchar2, ParameterDirection.Input, cliente.cliente_nombre);
                dyParam.Add("c_direccion", OracleDbType.Varchar2, ParameterDirection.Input, cliente.cliente_direccion);
                dyParam.Add("c_rut", OracleDbType.Varchar2, ParameterDirection.Input, cliente.cliente_rut);
                dyParam.Add("c_activo", OracleDbType.Int32, ParameterDirection.Input, cliente.cliente_activo);
                dyParam.Add("r_id", OracleDbType.Int32, ParameterDirection.Input, cliente.rubro_id);
                dyParam.Add("c_correo", OracleDbType.Varchar2, ParameterDirection.Input, cliente.clienteCorreo);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_EDITA_CLIENTE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object GetCliente()
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
                    var query = "SP_GET_CLIENTE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToArray();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object getCorreoClienteByContratoId(int contratoId)
        {

            dynamic result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("c_contrato_id", OracleDbType.Int32, ParameterDirection.Input, contratoId);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "GET_CLIENTE_BY_CONTRATO";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;

            
        }

        public object InsertCliente(Cliente cliente)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("c_nombre", OracleDbType.Varchar2, ParameterDirection.Input, cliente.cliente_nombre);
                dyParam.Add("c_direccion", OracleDbType.Varchar2, ParameterDirection.Input, cliente.cliente_direccion);
                dyParam.Add("c_rut", OracleDbType.Varchar2, ParameterDirection.Input, cliente.cliente_rut);
                dyParam.Add("c_activo", OracleDbType.Int32, ParameterDirection.Input, cliente.cliente_activo);
                dyParam.Add("r_id", OracleDbType.Int32, ParameterDirection.Input, cliente.rubro_id);
                dyParam.Add("c_correo", OracleDbType.Varchar2, ParameterDirection.Input, cliente.clienteCorreo);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_CLIENTE";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cliente;
        }

        private IDbConnection GetConnection()
        {
            var conectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(conectionString);
            return conn;
        }
    }
}

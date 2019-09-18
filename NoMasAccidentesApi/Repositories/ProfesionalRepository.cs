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
    public class ProfesionalRepository : IProfesionalRepository
    {

        IConfiguration configuration;

        public ProfesionalRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }


        public object DeleteProfesional(int id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("p_id", OracleDbType.Int32, ParameterDirection.Input, id);

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_DELETE_PROFESIONAL";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object EditaProfesional(Profesional profesional, int id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("p_id", OracleDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("p_nombre", OracleDbType.Varchar2, ParameterDirection.Input, profesional.profesional_nombre);
                dyParam.Add("p_apellido", OracleDbType.Varchar2, ParameterDirection.Input, profesional.profesional_apellido);
                dyParam.Add("p_rut", OracleDbType.Varchar2, ParameterDirection.Input, profesional.profesional_rut);
                dyParam.Add("p_activo", OracleDbType.Int32, ParameterDirection.Input, profesional.profesional_activo);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_EDITA_PROFESIONAL";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object GetProfesional()
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
                    var query = "SP_GET_PROFESIONAL";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;

        }

        public object InsertProfesional(Profesional profesional)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("p_nombre", OracleDbType.Varchar2, ParameterDirection.Input, profesional.profesional_nombre);
                dyParam.Add("p_apellido", OracleDbType.Varchar2, ParameterDirection.Input, profesional.profesional_apellido);
                dyParam.Add("p_rut", OracleDbType.Varchar2, ParameterDirection.Input, profesional.profesional_rut);
                dyParam.Add("p_activo", OracleDbType.Int32, ParameterDirection.Input, profesional.profesional_activo);
                
                    

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_PROFESIONAL";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return profesional;
        }


        private IDbConnection GetConnection()
        {
            var conectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(conectionString);
            return conn;
        }
    }
}

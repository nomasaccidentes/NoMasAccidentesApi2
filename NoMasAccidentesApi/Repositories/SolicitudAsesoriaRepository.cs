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
    public class SolicitudAsesoriaRepository : ISolicitudAsesoria
    {

        IConfiguration configuration;

        public SolicitudAsesoriaRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object getSolicitudesAsesoria()
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
                    var query = "SP_GET_SOLICITUD_ASESORIA";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object insertSolicitudAsesoria(SolicitudAsesoria solicitud)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("s_descripcion", OracleDbType.Varchar2, ParameterDirection.Input, solicitud.solicitudAsesoriaDescripcion);
                dyParam.Add("s_contrato_id", OracleDbType.Int32, ParameterDirection.Input, solicitud.cotrato_id);
                dyParam.Add("s_fecha_asesoria", OracleDbType.Date, ParameterDirection.Input, solicitud.solicitudFechaAsesoria);
                

                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_SOLICITUD_ASESORIA";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        


        public object getSolicitudesAsesoriaByContrato(int id)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("s_contrato_id", OracleDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_GET_SOLICITUD_AS_CONTRATO";

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

        public object editaSolicitudAsesoria(SolicitudAsesoria solicitud, int id)
        {
            object result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("s_asesoria_id", OracleDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("s_solicitud_resolucion", OracleDbType.Varchar2, ParameterDirection.Input, solicitud.solicitudResolucion);
                dyParam.Add("s_estado_solicitud", OracleDbType.Int32, ParameterDirection.Input, solicitud.estadoSolicitudId);
                dyParam.Add("s_resolucion_fecha", OracleDbType.Date, ParameterDirection.Input, solicitud.solicitudResolucionFecha);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_EDITA_SOLICITUD_ASESORIA";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
            
        }
    }
}

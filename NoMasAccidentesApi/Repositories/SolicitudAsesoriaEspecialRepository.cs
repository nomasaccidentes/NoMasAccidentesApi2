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
    public class SolicitudAsesoriaEspecialRepository : ISolicitudAsesoriaEspecialRepository
    {

        IConfiguration configuration;

        public SolicitudAsesoriaEspecialRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public object editaSolicitudAsesoriaEspecial(SolicitudAsesoriaEspecial solicitudAsesoriaEspecial, int id)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("s_asesoria_id", OracleDbType.Int32, ParameterDirection.Input, id);
                dyParam.Add("s_solicitud_resolucion", OracleDbType.Varchar2, ParameterDirection.Input, solicitudAsesoriaEspecial.solicitudResolucion);
                dyParam.Add("s_estado_solicitud", OracleDbType.Int32, ParameterDirection.Input, solicitudAsesoriaEspecial.estadoSolicitudId);
                dyParam.Add("s_resolucion_fecha", OracleDbType.Date, ParameterDirection.Input, solicitudAsesoriaEspecial.solicitudResolucionFecha);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_EDITA_SOLICITUD_ASE_ESP";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;

            
        }

        public object getAsesoriaEspecialByContratoId(int contrato)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();
                dyParam.Add("ae_contrato_id", OracleDbType.Int32, ParameterDirection.Input, contrato);
                dyParam.Add("EMPCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);

                var conn = this.GetConnection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_GET_SOL_ESP_BY_CON";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;

            
        }

        public object getAsesoriasEspeciales()
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
                    var query = "SP_GET_SOLICITUD_ASESORIA_ESP";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object insertAsesoriaEspecial(SolicitudAsesoriaEspecial solicitudAsesoriaEspecial)
        {
            object result = null;

            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("s_descripcion", OracleDbType.Varchar2, ParameterDirection.Input, solicitudAsesoriaEspecial.solicitudAsesoriaDescripcion);
                dyParam.Add("s_contrato_id", OracleDbType.Int32, ParameterDirection.Input, solicitudAsesoriaEspecial.cotrato_id);
                dyParam.Add("s_fecha_asesoria", OracleDbType.Date, ParameterDirection.Input, solicitudAsesoriaEspecial.solicitudFechaAsesoria);
                dyParam.Add("s_tipo_asesoria", OracleDbType.Int32, ParameterDirection.Input, solicitudAsesoriaEspecial.solicitudAsesoriaTipoEspecial);


                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_SOLICITUD_AS_ESP";

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

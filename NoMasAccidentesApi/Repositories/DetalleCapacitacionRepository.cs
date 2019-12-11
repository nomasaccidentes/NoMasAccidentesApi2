using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using NoMasAccidentesApi.Models;
using Oracle.ManagedDataAccess.Client;

namespace NoMasAccidentesApi.Repositories
{
    public class DetalleCapacitacionRepository : IDetalleCapacitacionRepository
    {
        IConfiguration configuration;

        public DetalleCapacitacionRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public object getDetalleCapacitacion()
        {
            throw new NotImplementedException();
        }

        public object getDetalleCapacitacionByCapacitacion(int id)
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
                    var query = "SP_GET_DET_CAP_BY_ID";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure).ToArray();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        public object insertDetalleCapacitacion(DetalleCapacitacion detalle)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("cd_participante", OracleDbType.Varchar2, ParameterDirection.Input, detalle.capacitacionParticipante);
                dyParam.Add("cd_correo", OracleDbType.Varchar2, ParameterDirection.Input, detalle.capacitacionCorreo);
                dyParam.Add("c_capacitacion_id", OracleDbType.Varchar2, ParameterDirection.Input, detalle.capacitacionId);



                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_INSERT_DET_CAP";

                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    enviarMail(detalle.capacitacionParticipante, detalle.capacitacionCorreo, detalle.capacitacionId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public object pasarListaDetalleCapacitacion(DetalleCapacitacion detalle,int presente)
        {
            dynamic result = null;
            try
            {
                var dyParam = new OracleDynamicParameters();

                dyParam.Add("cd_id", OracleDbType.Int32, ParameterDirection.Input, presente);
                dyParam.Add("cd_asiste", OracleDbType.Int32, ParameterDirection.Input, detalle.capacitacionAsiste);



                var conn = this.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                if (conn.State == ConnectionState.Open)
                {
                    var query = "SP_PASA_LISTA_CD";
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




        public void enviarMail(string participante, string correoInvitado , int capacitacionid)
        {


            CapacitacionRepository capacitacionRepository = new CapacitacionRepository(configuration);

            dynamic  capacitacion = capacitacionRepository.getCapacitacionByCapacitacionId(capacitacionid);

            string emailOrigen = "nomasaccidentess@gmail.com";
            //string emailDestino = "alexnicolasfredeslopez@gmail.com";
            string constrasena = "fwhbskbqvucomxzb";
            String mensaje = "Hola <strong>" + participante + "</strong><br><br>" +
                " Estas invitado a una capacitación <br>" +
                " Dia: <strong>" + capacitacion.CAPACITACION_FECHA + "</strong> <br>" +
                " Profesional : <strong>" + capacitacion.PROFESIONAL+"</strong>." +
                " <br><br>" +
                "Saluda Atte. Equipo No Más Accidentes";
            MailMessage oMailMessage = new MailMessage(emailOrigen, correoInvitado, "Invitación a Capacitación ", mensaje);

            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtp = new SmtpClient("smtp.gmail.com");
            oSmtp.EnableSsl = true;
            oSmtp.UseDefaultCredentials = true;
            oSmtp.Host = "smtp.gmail.com";
            oSmtp.Port = 587;
            oSmtp.Credentials = new System.Net.NetworkCredential(emailOrigen, constrasena);

            oSmtp.Send(oMailMessage);

            oSmtp.Dispose();


        }
    }
}

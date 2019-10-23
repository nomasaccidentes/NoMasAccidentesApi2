using Dapper;
using Microsoft.Extensions.Configuration;
using NoMasAccidentesApi.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NoMasAccidentesApi.Repositories
{
    public class PagosRepository : IPagosRepository
    {


        IConfiguration configuration;

        public PagosRepository(IConfiguration _configuration)
        {
            configuration = _configuration;
        }



        public object InsertPagosByContrato(PagoContrato pagoContrato)
        {

            var dat = pagoContrato.pagoContratoVcto;

            var arrayList = new ArrayList();
            for (int ctr = 0; ctr <= 12; ctr++)
            {

                //Console.WriteLine(dat.AddMonths(ctr).ToString("d"));
                //arrayList.Add(dat.AddMonths(ctr).ToString("d"));

                object result = null;

                ContratoRepository contrato = new ContratoRepository(configuration);
                dynamic resultContrato = contrato.GetLastContratoId();

                try
                {
                    var dyParam = new OracleDynamicParameters();
                    pagoContrato.pagoContratoVcto = Convert.ToDateTime(dat.AddMonths(ctr).ToString("d"));
                    dyParam.Add("pc_pago_contrato_descripcion", OracleDbType.Varchar2, ParameterDirection.Input, pagoContrato.pagoContratoDescripcion);
                    dyParam.Add("pc_contrato_id", OracleDbType.Int32, ParameterDirection.Input, Convert.ToInt32(resultContrato[0].CONTRATO_ID));
                    dyParam.Add("pc_pago_fecha_vcto", OracleDbType.Date, ParameterDirection.Input, pagoContrato.pagoContratoVcto);
                    dyParam.Add("pc_cliente_id", OracleDbType.Int32, ParameterDirection.Input, pagoContrato.clienteId);

                    var conn = this.GetConnection();
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    if (conn.State == ConnectionState.Open)
                    {
                        var query = "SP_INSERT_PAGO_CONTRATO";

                        result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }



            }

            return "Ok";
        }


        private IDbConnection GetConnection()
        {
            var conectionString = configuration.GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;
            var conn = new OracleConnection(conectionString);
            return conn;
        }
    }
}

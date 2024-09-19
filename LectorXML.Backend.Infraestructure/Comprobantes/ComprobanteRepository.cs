using Dapper;
using LectorXML.Backend.Domain.Comprobante.Domain;
using LectorXML.Backend.Domain.Comprobantes.Interfaces;
using LectorXML.Backend.Domain.Config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorXML.Backend.Infraestructure.Comprobantes
{
    public class ComprobanteRepository : IComprobanteRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public ComprobanteRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<Factura?> Obtener()
        {
            Factura? respuesta = null;

            using (IDbConnection conn = new SqlConnection(this._databaseConfig.SqlServerConnection))
            {
                respuesta = await conn.QueryFirstOrDefaultAsync<Factura>("sp_ObtenerComprobante", commandType: CommandType.StoredProcedure);
            }

            return respuesta;
        }

        public async Task<Factura?> Registrar(Factura factura)
        {
            Factura? respuesta = null;

            using (IDbConnection conn = new SqlConnection(this._databaseConfig.SqlServerConnection))
            {
               await conn.QueryAsync("sp_RegistrarComprobante",
                   new {
                        factura.Nro ,
                        factura.MontoOtrosCargos,
                        factura.Codigo_Detraccion ,
                        Creado = DateTime.Now,
                        CreadoPor = "Alexandra"
                   }
                   , commandType: CommandType.StoredProcedure);
            }

            return respuesta;
        }
        public async Task<Factura?> Actualizar()
        {
            Factura? respuesta = null;

            using (IDbConnection conn = new SqlConnection(this._databaseConfig.SqlServerConnection))
            {
                respuesta = await conn.QueryFirstOrDefaultAsync<Factura>("sp_ActualizarComprobante", commandType: CommandType.StoredProcedure);
            }

            return respuesta;
        }
    }
}

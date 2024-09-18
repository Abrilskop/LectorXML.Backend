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
            Factura? respuesta = new Factura();
            //SQL que ejecutara Dapper, aquí puedes jugar con los orders que quieras.
            string sql = @"SELECT [Id]
                              ,[Codigo]
                              ,[Monto]
                              ,[CodigoDetraccion]
                              ,[Creado]
                              ,[CreadoPor]
                          FROM [Comprobante] 
                          ORDER BY Id";

            

            using (IDbConnection conn = new SqlConnection(this._databaseConfig.SqlServerConnection))
            {

                respuesta = await conn.QueryFirstOrDefaultAsync<Factura>(sql);
            }

            return respuesta;
        } 
    }
}

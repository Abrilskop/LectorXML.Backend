using LectorXML.Backend.Domain.Comprobante.Domain;
using LectorXML.Backend.Domain.Comprobantes.Interfaces;
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
        private static string _connectionString = "server=.;database=LectorXml; User ID=sa;Password=root;Encrypt=False;MultipleActiveResultSets=True";
        public async Task<Factura> registrar(Factura factura)
        {
            //SQL que ejecutara Dapper, aquí puedes jugar con los orders que quieras.
            string sql = @"SELECT [Id]
                              ,[Codigo]
                              ,[Monto]
                              ,[CodigoDetraccion]
                              ,[Creado]
                              ,[CreadoPor]
                          FROM [Comprobante] 
                          ORDER BY Id";

            //Iniciar la conexión con la base de datos
            using (IDbConnection con = new SqlConnection(_connectionString)
            {
                var Consulta = factura
            }


            //Ejecutar la consulta SQL y almacenar las líneas en nuestro modelo. 

            //Dapper devuelve un IEnumerable para trabajar más cómodos lo convertimos a listas. 
            return marks.ToList();
        }



    }
        

    }
}

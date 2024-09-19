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
                       Id = factura.Id,
                       DocumentoPago_Id = factura.DocumentoPago_Id,
                       Nro = factura.Nro,
                       FechaEmision = factura.FechaEmision,
                       Moneda_Id = factura.Moneda_Id,
                       Proveedor_NroIdentificacion = factura.Proveedor_NroIdentificacion,
                       Proveedor_RazonSocial = factura.Proveedor_RazonSocial,
                       Cliente_NroIdentificacion = factura.Cliente_NroIdentificacion,
                       Cliente_RazonSocial = factura.Cliente_RazonSocial,
                       SubTotal = factura.SubTotal,
                       Anticipo = factura.Anticipo,
                       Descuento = factura.Descuento,
                       OperacionGravada = factura.OperacionGravada,
                       OperacionExonerada = factura.OperacionExonerada,
                       ISC = factura.ISC,
                       IVA = factura.IVA,
                       OtroCargo = factura.OtroCargo,
                       OtroTributo = factura.OtroTributo,
                       Total = factura.Total,
                       OperacionGratuita = factura.OperacionGratuita,
                       TotalTexto = factura.TotalTexto,
                       TipoDocumento = factura.TipoDocumento,
                       OrdenCompra_Nro = factura.OrdenCompra_Nro,
                       NotaRecepcion_Codigo = factura.NotaRecepcion_Codigo,
                       Codigo_Detraccion = factura.Codigo_Detraccion,
                       FechaConsulta = factura.FechaConsulta,
                       DiaPago = factura.DiaPago,
                       FechaVencimientoPago = factura.FechaVencimientoPago,
                       PorcentajeDetraccion = factura.PorcentajeDetraccion,
                       MontoDetraccion = factura.MontoDetraccion,
                       DescripcionDetraccion = factura.DescripcionDetraccion,
                       EstadoSunat = factura.EstadoSunat,
                       TipoDocumentoNeoGrid = factura.TipoDocumentoNeoGrid,
                       MontoOtrosCargos = factura.MontoOtrosCargos,
                       CorrelativoPortal = factura.CorrelativoPortal,
                       OtroCargoAplicable = factura.OtroCargoAplicable,
                       Creado = DateTime.Now
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

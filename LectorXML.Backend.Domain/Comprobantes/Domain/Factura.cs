using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LectorXML.Backend.Domain.Comprobante.Domain
{
    public class Factura
    {
        public Guid? Id { get; set; }
        public Guid? DocumentoPago_Id { get; set; }
        public string Nro { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Moneda_Id { get; set; }
        public string Proveedor_NroIdentificacion { get; set; }
        public string Proveedor_RazonSocial { get; set; }
        public string Cliente_NroIdentificacion { get; set; }
        public string Cliente_RazonSocial { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Anticipo { get; set; }
        public decimal Descuento { get; set; }
        public decimal OperacionGravada { get; set; }
        public decimal OperacionExonerada { get; set; }
        public decimal ISC { get; set; }
        public decimal IVA { get; set; }
        public decimal OtroCargo { get; set; }
        public decimal OtroTributo { get; set; }
        public decimal Total { get; set; }
        public decimal OperacionGratuita { get; set; }
        public string TotalTexto { get; set; }
        public string TipoDocumento { get; set; }
        public string OrdenCompra_Nro { get; set; }
        public string NotaRecepcion_Codigo { get; set; }
        public string Codigo_Detraccion { get; set; }
        public DateTime? FechaConsulta { get; set; }
        public int DiaPago { get; set; }
        public DateTime? FechaVencimientoPago { get; set; }
        public decimal PorcentajeDetraccion { get; set; }
        public decimal MontoDetraccion { get; set; }
        public string DescripcionDetraccion { get; set; }
        public List<string> CuotasDetalle { get; set; }
        public string EstadoSunat { get; set; }
        public string TipoDocumentoNeoGrid { get; set; }
        public decimal MontoOtrosCargos { get; set; }
        public int? CorrelativoPortal { get; set; }
        public decimal OtroCargoAplicable { get; set; }
    }
}

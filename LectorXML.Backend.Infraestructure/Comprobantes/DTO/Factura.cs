using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorXML.Backend.Infraestructure.Comprobante.DTO
{
    public class Factura
    {
        // aqui pego :v
        public Factura()
        {
            this.Nro = null;
            this.Moneda_Id = null;
            this.Proveedor_NroIdentificacion = null;
            this.Proveedor_RazonSocial = null;
            this.Cliente_NroIdentificacion = null;
            this.Cliente_RazonSocial = null;
            this.SubTotal = 0.0m;
            this.Anticipo = 0.0m;
            this.Descuento = 0.0m;
            this.OperacionGravada = 0.0m;
            this.OperacionExonerada = 0.0m;
            this.ISC = 0.0m;
            this.IVA = 0.0m;
            this.OtroCargo = 0.0m;
            this.OtroCargoAplicable = 0.0m;
            this.OtroTributo = 0.0m;
            this.Total = 0.0m;
            this.OperacionGratuita = 0.0m;
            this.TotalTexto = null;
            this.TipoDocumento = null;
            this.OrdenCompra_Nro = null;
            this.Detalle = null;
            this.NotaRecepcion_Codigo = null;
            this.Codigo_Detraccion = null;
            this.FechaConsulta = null;
            this.DiaPago = 0;
            this.PorcentajeDetraccion = 0.0m;
            this.MontoDetraccion = 0.0m;
            this.DescripcionDetraccion = null;
            this.CuotasDetalle = null;
            this.EstadoSunat = null;
            this.TipoDocumentoNeoGrid = null;
            this.MontoOtrosCargos = 0.0m;
        }

        public object Nro { get; set; }
        public object Moneda_Id { get; set; }
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
        public decimal OtroCargoAplicable { get; set; }
        public decimal OtroTributo { get; set; }
        public decimal Total { get; set; }
        public decimal OperacionGratuita { get; set; }
        public object TotalTexto { get; set; }
        public object TipoDocumento { get; set; }
        public object OrdenCompra_Nro { get; set; }
        public object Detalle { get; set; }
        public object NotaRecepcion_Codigo { get; set; }
        public object Codigo_Detraccion { get; set; }
        public object FechaConsulta { get; set; }
        public int DiaPago { get; set; }
        public decimal PorcentajeDetraccion { get; set; }
        public decimal MontoDetraccion { get; set; }
        public object DescripcionDetraccion { get; set; }
        public object CuotasDetalle { get; set; }
        public object EstadoSunat { get; set; }
        public object TipoDocumentoNeoGrid { get; set; }
        public decimal MontoOtrosCargos { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Detraccion { get; set; }



    }
}

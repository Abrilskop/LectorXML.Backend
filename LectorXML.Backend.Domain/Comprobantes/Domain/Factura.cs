using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorXML.Backend.Domain.Comprobante.Domain
{
    public class Factura
    {

        public int Id { get; set; }
        public string? Cliente_NroIdentificacion { get; set; }
        public string? CodigoDetraccion { get; set;}
        public string? Proveedor_NroIdentificacion { get; set;}
        public string? Cliente_RazonSocial { get; set;}
        public string? Proveedor_RazonSocial { get; set;}
        public string? Codigo { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaEmision { get; set; }
        public string?  CreadoPor { get; set; }
        public DateTime? Creado { get; set; }
    }
}

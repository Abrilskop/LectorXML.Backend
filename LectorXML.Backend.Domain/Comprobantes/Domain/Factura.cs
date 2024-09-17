using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorXML.Backend.Domain.Comprobante.Domain
{
    public class Factura
    {
        public string? Cliente_NroIdentificacion { get; set; }
        public string? Detraccion { get; set;}
        public string? Proveedor_NroIdentificacion { get; set;}
        public string? Cliente_RazonSocial { get; set;}
        public string? Proveedor_RazonSocial { get; set;}
        public DateTime FechaEmision { get; set; }
    }
}

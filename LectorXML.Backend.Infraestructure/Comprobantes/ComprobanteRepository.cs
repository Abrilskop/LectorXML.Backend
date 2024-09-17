using LectorXML.Backend.Domain.Comprobante.Domain;
using LectorXML.Backend.Domain.Comprobantes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorXML.Backend.Infraestructure.Comprobantes
{
    public class ComprobanteRepository : IComprobanteRepository
    {
        public async Task<Factura> registrar(Factura factura)
        {
            return factura;
        }
    }
}

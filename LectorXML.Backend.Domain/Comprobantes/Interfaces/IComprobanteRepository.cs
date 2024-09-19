using LectorXML.Backend.Domain.Comprobante.Domain;
using LectorXML.Backend.Domain.Comprobante.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorXML.Backend.Domain.Comprobantes.Interfaces
{
    public interface IComprobanteRepository
    {
        Task<Factura?> Obtener();

        Task<Factura?> Registrar(Factura factura);

        Task<Factura?> Actualizar();
    }

}

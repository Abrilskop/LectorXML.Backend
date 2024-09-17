using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorXML.Backend.Domain.Comprobante.DTO
{
    public class FileResponse
    {
        public string Name {  get; set; }
        public decimal Size { get; set; }
        public string Extension { get; set; }

    }
}

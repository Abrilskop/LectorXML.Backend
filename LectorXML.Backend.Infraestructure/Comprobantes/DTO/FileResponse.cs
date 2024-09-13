using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorXML.Backend.Infraestructure.Comprobante.DTO
{
    public class FileResponse
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public decimal Size { get; set; }
        public string XmlContent { get; set; }
        public string Extension { get; set; }
        
    }

}

using LectorXML.Backend.Application;
using LectorXML.Backend.Application.Comprobantes;
using LectorXML.Backend.Infraestructure.Comprobante.DTO;
using LectorXML.Backend.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LectorXML.Backend.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class ComprobanteController : ControllerBase
    {
        private readonly ComprobanteApp _comprobanteApp;
        public ComprobanteController() 
        {  
            this._comprobanteApp = new ComprobanteApp();
        }

        // metodo get obtener
        [HttpGet()]
        public async Task<IActionResult> Listado(int id)
        {
            string cadena = await this._comprobanteApp.DevolverCadena();
            return Ok(cadena); // status 200

        }

        // metodo post enviar
        [HttpPost("HES")] 
        public IActionResult LecturaHesXml(int id)
        {
            return Ok(new { id });

        }

        [HttpPost("OS")]
        public IActionResult LecturaOsXml(int id)
        {
            return Ok(new { id }); 

        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Archivo no proporcionado o vacío.");


            StatusResponse<FileResponse> cadena = await this._comprobanteApp.ParciarDocumentoAObjeto(file);

            // Aquí puedes agregar lógica adicional según el tipo de archivo
            // Por ejemplo, si es un archivo HES o OS, podrías llamar a los métodos correspondientes
            return StatusCode(cadena.Codigo, cadena);
        }

        [HttpPost("upload-name")]
        public async Task<IActionResult> UploadName(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Archivo no proporcionado o vacío.");


            StatusResponse<FileResponse> cadena = await this._comprobanteApp.ModifyFileName(file);

            // Aquí puedes agregar lógica adicional según el tipo de archivo
            // Por ejemplo, si es un archivo HES o OS, podrías llamar a los métodos correspondientes
            return StatusCode(cadena.Codigo, cadena);
        }

        [HttpPost("upload-redondeo")]
        public async Task<IActionResult> UploadRedondeo(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Archivo no proporcionado o vacío.");


            StatusResponse<FileResponse> cadena = await this._comprobanteApp.ModifyRedondearPeso(file);

            // Aquí puedes agregar lógica adicional según el tipo de archivo
            // Por ejemplo, si es un archivo HES o OS, podrías llamar a los métodos correspondientes
            return StatusCode(cadena.Codigo, cadena);
        }

        [HttpPost("upload-addcharacters")]
        public async Task<IActionResult> UploadAddCharacters(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Archivo no proporcionado o vacío.");


            StatusResponse<FileResponse> cadena = await this._comprobanteApp.AddCharactersFile(file);

            // Aquí puedes agregar lógica adicional según el tipo de archivo
            // Por ejemplo, si es un archivo HES o OS, podrías llamar a los métodos correspondientes
            return StatusCode(cadena.Codigo, cadena);
        }

        [HttpPost("upload-sumanumeros")]
        public async Task<IActionResult> UploadSumaNumeros(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Archivo no proporcionado o vacío.");


            StatusResponse<FileResponse> cadena = await this._comprobanteApp.SumaNumerosPeso(file);

            // Aquí puedes agregar lógica adicional según el tipo de archivo
            // Por ejemplo, si es un archivo HES o OS, podrías llamar a los métodos correspondientes
            return StatusCode(cadena.Codigo, cadena);
        }

        [HttpPost("upload-Parceo")]
        public async Task<IActionResult> UploadParceoXML(IFormFile file)
        {

            Factura factura = new Factura();
            XmlSerializer serializer = new XmlSerializer(typeof(InvoiceType));
            try

            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                }
                InvoiceType resultXML = null;
                using (TextReader reader = new StreamReader(file.OpenReadStream()))
                    resultXML = (InvoiceType)serializer.Deserialize(reader);

                // VALIDAR EL FORMATO DEL UBL
                if (resultXML.UBLVersionID == null)
                {

                }
                else if (resultXML.UBLVersionID.Value == "2.0")
                {

                }
                else if (resultXML.UBLVersionID.Value != "2.1")
                {
                    
                }
                int? lengthEmi = resultXML.AccountingSupplierParty.Party.PartyTaxScheme?.Length;
                int? lengthEmiSecundario = resultXML.AccountingSupplierParty.Party.PartyIdentification?.Length;
                int? lengthCli = resultXML.AccountingCustomerParty.Party.PartyTaxScheme?.Length;
                int? lengthCliSecundario = resultXML.AccountingCustomerParty.Party.PartyIdentification?.Length;
                int? lengthTotTe = resultXML.Note?.Length;
                string rucEmisor = "";
                string rucCliente = "";

                if (lengthEmi != null)
                {
                    if (resultXML.AccountingSupplierParty.Party.PartyTaxScheme[0].CompanyID != null
                        && !string.IsNullOrEmpty(resultXML.AccountingSupplierParty.Party.PartyTaxScheme[0].CompanyID.Value))
                        rucEmisor = resultXML.AccountingSupplierParty.Party.PartyTaxScheme[0].CompanyID.Value;
                }
                if (lengthEmiSecundario != null)
                {
                    if (resultXML.AccountingSupplierParty.Party.PartyIdentification[0].ID != null
                        && !string.IsNullOrEmpty(resultXML.AccountingSupplierParty.Party.PartyIdentification[0].ID.Value))
                        rucEmisor = resultXML.AccountingSupplierParty.Party.PartyIdentification[0].ID.Value;
                }
                if (lengthCli != null)
                {
                    if (resultXML.AccountingCustomerParty.Party.PartyTaxScheme[0].CompanyID != null
                        && !string.IsNullOrEmpty(resultXML.AccountingCustomerParty.Party.PartyTaxScheme[0].CompanyID.Value))
                        rucCliente = resultXML.AccountingCustomerParty.Party.PartyTaxScheme[0].CompanyID.Value;
                }
                if (lengthCliSecundario != null)
                {
                    if (resultXML.AccountingCustomerParty.Party.PartyIdentification[0].ID != null
                        && !string.IsNullOrEmpty(resultXML.AccountingCustomerParty.Party.PartyIdentification[0].ID.Value))
                        rucCliente = resultXML.AccountingCustomerParty.Party.PartyIdentification[0].ID.Value;
                }
                factura.Cliente_NroIdentificacion = rucCliente;
                string Detraccion = string.Empty;
                string Proveedor_RazonSocial = string.Empty;
                string Cliente_RazonSocial = string.Empty;
                try
                {
                    if (lengthEmi != null)
                    {
                        if (resultXML.AccountingSupplierParty.Party.PartyTaxScheme[0].RegistrationName != null
                            && !string.IsNullOrEmpty(resultXML.AccountingSupplierParty.Party.PartyTaxScheme[0].RegistrationName.Value))
                            Proveedor_RazonSocial = resultXML.AccountingSupplierParty.Party.PartyTaxScheme[0].RegistrationName.Value;
                    }
                    if (lengthEmiSecundario != null)
                    {
                        if (resultXML.AccountingSupplierParty.Party.PartyLegalEntity[0].RegistrationName != null
                            && !string.IsNullOrEmpty(resultXML.AccountingSupplierParty.Party.PartyLegalEntity[0].RegistrationName.Value))
                            Proveedor_RazonSocial = resultXML.AccountingSupplierParty.Party.PartyLegalEntity[0].RegistrationName.Value;
                    }
                    if (lengthCli != null)
                    {
                        if (resultXML.AccountingCustomerParty.Party.PartyTaxScheme[0].RegistrationName != null
                            && !string.IsNullOrEmpty(resultXML.AccountingCustomerParty.Party.PartyTaxScheme[0].RegistrationName.Value))
                            Cliente_RazonSocial = resultXML.AccountingCustomerParty.Party.PartyTaxScheme[0].RegistrationName.Value;
                    }
                    if (lengthCliSecundario != null)
                    {
                        if (resultXML.AccountingCustomerParty.Party.PartyLegalEntity[0].RegistrationName != null
                            && !string.IsNullOrEmpty(resultXML.AccountingCustomerParty.Party.PartyLegalEntity[0].RegistrationName.Value))
                            Cliente_RazonSocial = resultXML.AccountingCustomerParty.Party.PartyLegalEntity[0].RegistrationName.Value;
                    }

                    // aqui detraccion
                    Detraccion = resultXML.PaymentTerms[0].PaymentMeansID[0].Value;

                }
                catch (System.Exception ex)
                {


                }
                factura.Detraccion = Detraccion;
                factura.Proveedor_NroIdentificacion = rucEmisor;
                factura.Cliente_RazonSocial = Cliente_RazonSocial;
                factura.Proveedor_RazonSocial = Proveedor_RazonSocial;
                factura.FechaEmision = resultXML.IssueDate.Value;
            }

            catch

            {

            }
            return Ok(factura);
        }

    }
}


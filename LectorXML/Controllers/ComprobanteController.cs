using LectorXML.Backend.Application;
using LectorXML.Backend.Application.Comprobantes;
using LectorXML.Backend.Domain.Comprobante.Domain;
using LectorXML.Backend.Domain.Comprobante.DTO;
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
        private ComprobanteApp _comprobanteApp;
        public ComprobanteController(ComprobanteApp comprobanteApp) 
        {  
            this._comprobanteApp = comprobanteApp;
        }

        [HttpGet()]
        public async Task<IActionResult> Listado(int id)
        {
            string cadena = await this._comprobanteApp.DevolverCadena();
            return Ok(cadena); 
        }

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
            return StatusCode(cadena.Codigo, cadena);
        }

        [HttpPost("upload-name")]
        public async Task<IActionResult> UploadName(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Archivo no proporcionado o vacío.");

            StatusResponse<FileResponse> cadena = await this._comprobanteApp.ModifyFileName(file);
            return StatusCode(cadena.Codigo, cadena);
        }

        [HttpPost("upload-redondeo")]
        public async Task<IActionResult> UploadRedondeo(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Archivo no proporcionado o vacío.");

            StatusResponse<FileResponse> cadena = await this._comprobanteApp.ModifyRedondearPeso(file);
            return StatusCode(cadena.Codigo, cadena);
        }

        [HttpPost("upload-addcharacters")]
        public async Task<IActionResult> UploadAddCharacters(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Archivo no proporcionado o vacío.");

            StatusResponse<FileResponse> cadena = await this._comprobanteApp.AddCharactersFile(file);
            return StatusCode(cadena.Codigo, cadena);
        }

        [HttpPost("upload-sumanumeros")]
        public async Task<IActionResult> UploadSumaNumeros(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Archivo no proporcionado o vacío.");

            StatusResponse<FileResponse> cadena = await this._comprobanteApp.SumaNumerosPeso(file);
            return StatusCode(cadena.Codigo, cadena);
        }

        [HttpPost("upload-Parceo")]
        public async Task<IActionResult> UploadParceoXML(IFormFile file)
        {
            StatusResponse<Factura> cadena = await this._comprobanteApp.LeerXml(file);
            return StatusCode(cadena.Codigo, cadena);
        }
    }
}


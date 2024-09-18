using LectorXML.Backend.Application.Comun;
using LectorXML.Backend.Domain.Comprobante.Domain;
using LectorXML.Backend.Domain.Comprobante.DTO;
using LectorXML.Backend.Domain.Comprobantes.Interfaces;
using LectorXML.Backend.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LectorXML.Backend.Application.Comprobantes
{
    public class ComprobanteApp:BaseApp<ComprobanteApp> {

        private IComprobanteRepository _comprobanteRepository;


        public ComprobanteApp(IComprobanteRepository comprobanteRepository) 
        { 
            this._comprobanteRepository = comprobanteRepository;
        }
        
        public async Task <string> DevolverCadena()
        {
            string cadena = "Operación exitosa";
            return cadena;
        }

        public async Task <StatusResponse<FileResponse>> ParciarDocumentoAObjeto(IFormFile file)
        {
            StatusResponse<FileResponse> respuesta = new StatusResponse<FileResponse>();
            StatusResponse<string> cadena = new StatusResponse<string>();
            cadena = await this.ProcesoComplejo(() => this.DevolverCadena(), "");
            respuesta.Titulo = cadena.Data;
            try
            {
                // Crear la respuesta
                FileResponse fileResponse = new FileResponse();

                // Validar que el archivo no sea nulo
                if (file == null || file.Length == 0)
                {
                    respuesta.Titulo = "Ocurrio un error mientras se Parseaba el archivo";
                    respuesta.Detalle = "No hay ningun archivo enviado";
                    respuesta.Codigo = 400;
                    //respuesta.Errores = TODO crear un diccionario y enviar los errores por este atributo
                    return respuesta;
                }

                // Validar que el archivo sea XML basado en su extensión
                string fileExtension = Path.GetExtension(file.FileName).ToLower();
                if (fileExtension != ".xml")
                {
                    respuesta.Titulo = "Ocurrio un error mientras se Parseaba el archivo";
                    respuesta.Detalle = "El archivo no es valido, enviar un XML";
                    respuesta.Codigo = 400;
                    //respuesta.Errores = TODO crear un diccionario y enviar los errores por este atributo
                    return respuesta;
                }

                // Validar que el archivo no exceda los 8 MB (8 MB = 8 * 1024 * 1024 bytes)
                if (file.Length > 8.0 * 1024.0 * 1024.0) // parciarlo
                {
                    respuesta.Titulo = "Ocurrio un error mientras se Parseaba el archivo";
                    respuesta.Detalle = "El archivo excede el tamaño máximo permitido de 8 MB.";
                    respuesta.Codigo = 400;
                    //respuesta.Errores = TODO crear un diccionario y enviar los errores por este atributo
                    return respuesta;
                }

                // Calcular el tamaño en megabytes
                double sizeInMB = file.Length / (1024.0 * 1024.0);
                // Formatear el tamaño
                string sizeFormatted = $"{file.Length} bytes ({sizeInMB:F2} MB)";


                // Asignar el nombre del archivo
                fileResponse.Name = file.FileName;

                // Asignar el tamaño del archivo
                // fileResponse.Size = sizeFormatted;

                // Leer el contenido del archivo XML
                //using (var reader = new StreamReader(file.OpenReadStream()))
                //{
                //    fileResponse.XmlContent = reader.ReadToEnd(); // Leer el contenido completo del archivo
                //}

                // Asignar la extensión del archivo
                fileResponse.Extension = fileExtension;

                respuesta.Data = fileResponse;
                respuesta.Codigo = 200;
                return respuesta;
            }
            catch (Exception exec)
            {
                respuesta.Titulo = "Ocurrio un error mientras se Parseaba el archivo";
                respuesta.Detalle = exec.ToString();
                respuesta.Codigo = 500;
                //respuesta.Errores = TODO crear un diccionario y enviar los errores por este atributo
                return respuesta;
            }
            
        }

        // funcion modificar name 
        public async Task<StatusResponse<FileResponse>> ModifyFileName(IFormFile file)
        {
            StatusResponse<FileResponse> respuesta = new StatusResponse<FileResponse>();
            StatusResponse<string> cadena = new StatusResponse<string>();
            cadena = await this.ProcesoComplejo(() => this.DevolverCadena(), "");
            respuesta.Titulo = cadena.Data;
            try
            {
                FileResponse fileResponse = new FileResponse();

                string nuevoNombre = $"Modificadoyei_{file.FileName}";

                // Asignar el nuevo nombre y otros detalles al objeto FileResponse
                fileResponse.Name = nuevoNombre;
                fileResponse.Extension = Path.GetExtension(file.FileName); // Mantener la extensión original

                // Asignar la respuesta con el nuevo nombre de archivo
                respuesta.Data = fileResponse;
                respuesta.Satisfactorio = true;
                respuesta.Titulo = "Nombre del archivo modificado exitosamente";
                respuesta.Codigo = 200;

                return respuesta; // ir registrando nulo cuando se genere la excepcion

            }

            catch (Exception exec)
            {
                respuesta.Titulo = "Ocurrio un error mientras se cambiaba el nombre del archivo";
                respuesta.Detalle = exec.ToString();
                respuesta.Codigo = 500;
                //respuesta.Errores = TODO crear un diccionario y enviar los errores por este atributo
                return respuesta;
            }

        }

        public async Task<StatusResponse<FileResponse>> ModifyRedondearPeso(IFormFile file)
        {
            StatusResponse<FileResponse> respuesta = new StatusResponse<FileResponse>();
            StatusResponse<string> cadena = new StatusResponse<string>();
            cadena = await this.ProcesoComplejo(() => this.DevolverCadena(), "");
            respuesta.Titulo = cadena.Data;
            try
            {
                FileResponse fileResponse = new FileResponse();
                double sizeInMB = file.Length / (1024.0 * 1024.0);
                decimal formato = Math.Round((decimal)sizeInMB, 3);
                fileResponse.Size = formato;

                // Asignar la respuesta con el nuevo nombre de archivo
                respuesta.Data = fileResponse;
                respuesta.Satisfactorio = true;
                respuesta.Titulo = "Peso del archivo modificado exitosamente";
                respuesta.Codigo = 200;

                return respuesta; // ir registrando nulo cuando se genere la excepcion

            }

            catch (Exception exec)
            {
                respuesta.Titulo = "Ocurrio un error mientras se cambiaba el peso del archivo";
                respuesta.Detalle = exec.ToString();
                respuesta.Codigo = 500;
                //respuesta.Errores = TODO crear un diccionario y enviar los errores por este atributo
                return respuesta;
            }
        }
        public async Task<StatusResponse<FileResponse>> AddCharactersFile(IFormFile file)
        {
            StatusResponse<FileResponse> respuesta = new StatusResponse<FileResponse>();
            StatusResponse<string> cadena = new StatusResponse<string>();
            cadena = await this.ProcesoComplejo(() => this.DevolverCadena(), "");
            respuesta.Titulo = cadena.Data;
            try
            {
                FileResponse fileResponse = new FileResponse();
                // Obtener el nombre del archivo
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                int numberOfCharacters = fileName.Length;
                fileResponse.Name = numberOfCharacters.ToString();

                // Asignar la respuesta con el nuevo nombre de archivo
                respuesta.Data = fileResponse;
                respuesta.Satisfactorio = true;
                respuesta.Titulo = "Los caracteres del nombre del archivo han sido sumados exitosamente";
                respuesta.Codigo = 200;

                return respuesta; // ir registrando nulo cuando se genere la excepcion

            }

            catch (Exception exec)
            {
                respuesta.Titulo = "Ocurrio un error mientras se sumaba la cantidad de caracteres del nombre del archivo";
                respuesta.Detalle = exec.ToString();
                respuesta.Codigo = 500;
                //respuesta.Errores = TODO crear un diccionario y enviar los errores por este atributo
                return respuesta;
            }
        }
        public async Task<StatusResponse<FileResponse>> SumaNumerosPeso(IFormFile file)
        {
            StatusResponse<FileResponse> respuesta = new StatusResponse<FileResponse>();
            StatusResponse<string> cadena = new StatusResponse<string>();
            cadena = await this.ProcesoComplejo(() => this.DevolverCadena(), "");
            respuesta.Titulo = cadena.Data;
            try
            {
                FileResponse fileResponse = new FileResponse();
                // Obtener el tamaño del archivo en bytes
                double sizeInMB = file.Length / (1024.0 * 1024.0);

                // Convertir la cadena a un array de caracteres
                char[] arrayNumeros = sizeInMB.ToString().ToCharArray();

                int suma = 0;

                foreach (char c in arrayNumeros)
                {
                    if ( char.IsDigit(c)) 
                    {
                        suma += int.Parse(c.ToString());
                    }
                }
                fileResponse.Size = (decimal)suma;

                respuesta.Data = fileResponse;
                respuesta.Satisfactorio = true;
                respuesta.Titulo = "Los numeros del peso del archivo estan sumados exitosamente";
                respuesta.Codigo = 200;

                return respuesta; 

            }

            catch (Exception exec)
            {
                respuesta.Titulo = "Ocurrio un error mientras se sumaba la cantidad de caracteres del nombre del archivo";
                respuesta.Detalle = exec.ToString();
                respuesta.Codigo = 500;
                //respuesta.Errores = TODO crear un diccionario y enviar los errores por este atributo
                return respuesta;
            }
        }

        public async Task<StatusResponse<Factura>> LeerXml(IFormFile file)
        { 
            StatusResponse<Factura> respuesta = new StatusResponse<Factura>();
            respuesta.Codigo = 200;
            respuesta.Titulo = "Operación exitosa.";

            Factura factura = new Factura();
            XmlSerializer serializer = new XmlSerializer(typeof(InvoiceType));
            try

            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string s = Convert.ToBase64String(fileBytes);
                }
                InvoiceType resultXML = null;
                using (TextReader reader = new StreamReader(file.OpenReadStream()))
                    resultXML = (InvoiceType)serializer.Deserialize(reader);

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

                    Detraccion = resultXML.PaymentTerms[0].PaymentMeansID[0].Value;

                }
                catch (Exception ex)
                {
                    respuesta.Codigo = 500;
                    respuesta.Titulo = "Ocurrio un error al leer los datos del proveedor y del cliente.";
                    respuesta.Detalle = ex.Message;
                    return respuesta;

                }

                factura.CodigoDetraccion = Detraccion;
                factura.Proveedor_NroIdentificacion = rucEmisor;
                factura.Cliente_RazonSocial = Cliente_RazonSocial;
                factura.Proveedor_RazonSocial = Proveedor_RazonSocial;
                factura.FechaEmision = resultXML.IssueDate.Value;
                respuesta.Data = factura;

                StatusResponse<Factura> regsitrar = await this.ProcesoComplejo(() => this._comprobanteRepository.Obtener(),"");

            }
            catch (Exception ex)
            {
                respuesta.Codigo = 500;
                respuesta.Titulo = "Ocurrio un error.";
                respuesta.Detalle = ex.Message;

            }

            return respuesta;


        }

        public async Task<StatusResponse<Factura?>> Obtener() {
            return await this.ProcesoComplejo(() => this._comprobanteRepository.Obtener(), "");
        }


    }
}

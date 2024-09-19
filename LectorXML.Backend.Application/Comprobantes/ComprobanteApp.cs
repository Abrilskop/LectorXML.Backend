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
using static System.Runtime.InteropServices.JavaScript.JSType;

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

                Decimal porcentajeIVA = 0;
                // GENERAR LA CLASE FACTURA VALIDAR LOS CAMPOS
                var monto = string.Empty;
                var rucEmisor = string.Empty;
                var rucCliente = string.Empty;

                try
                {
                    factura = new Factura();
                    factura.Nro = resultXML.ID.Value;
                    factura.TipoDocumento = resultXML.InvoiceTypeCode.Value;
                    int? lengthEmi = resultXML.AccountingSupplierParty.Party.PartyTaxScheme?.Length;
                    int? lengthEmi2 = resultXML.AccountingSupplierParty.Party.PartyIdentification?.Length;
                    int? lengthCli = resultXML.AccountingCustomerParty.Party.PartyTaxScheme?.Length;
                    int? lengthCli2 = resultXML.AccountingCustomerParty.Party.PartyIdentification?.Length;
                    int? lengthTotTe = resultXML.Note?.Length;

                    if (lengthEmi != null)
                    {
                        if (resultXML.AccountingSupplierParty.Party.PartyTaxScheme[0].CompanyID != null
                            && !string.IsNullOrEmpty(resultXML.AccountingSupplierParty.Party.PartyTaxScheme[0].CompanyID.Value))
                            rucEmisor = resultXML.AccountingSupplierParty.Party.PartyTaxScheme[0].CompanyID.Value;
                    }
                    if (lengthEmi2 != null)
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
                    if (lengthCli2 != null)
                    {
                        if (resultXML.AccountingCustomerParty.Party.PartyIdentification[0].ID != null
                            && !string.IsNullOrEmpty(resultXML.AccountingCustomerParty.Party.PartyIdentification[0].ID.Value))
                            rucCliente = resultXML.AccountingCustomerParty.Party.PartyIdentification[0].ID.Value;
                    }
                    for (int a = 0; a < lengthTotTe; a++)
                    {
                        if (resultXML.Note[a].languageLocaleID != null)
                        {
                            var varLocal = resultXML.Note[a].languageLocaleID.ToString();
                            if (varLocal == "1000")
                            {
                                factura.TotalTexto = resultXML.Note[a].Value;
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    respuesta.Satisfactorio = false;
                    respuesta.Detalle = "El archivo ingresado no es un documento válido de SUNAT";
                    respuesta.Titulo = ex.Message;
                    return respuesta;

                }

                try
                {
                    factura.FechaVencimientoPago = resultXML.IssueDate.Value;
                    DateTime fechaLimiteObligatorioParaCuotas = new DateTime(2021, 12, 1);
                    factura.FechaEmision = resultXML.IssueDate.Value;//Necesario para excluir

                    if (factura.FechaEmision > fechaLimiteObligatorioParaCuotas)
                    {
                        List<string> DetalleCuota = new List<string>();

                        int? lengthPaymentTerms = resultXML.PaymentTerms?.Length;
                        if (lengthPaymentTerms != null)
                        {
                            for (int i = 0; i < lengthPaymentTerms; i++)
                            {

                                if (resultXML.PaymentTerms[i].ID != null)
                                {

                                    if (resultXML.PaymentTerms[i].ID != null || resultXML.PaymentTerms[i].ID.Value.ToString() == "Detraccion")
                                    {
                                        int? lengthPaymentMeansID = resultXML.PaymentTerms[i].PaymentMeansID?.Length;

                                        if (lengthPaymentMeansID != null)
                                        {

                                            if (resultXML.PaymentTerms[i].PaymentMeansID[0] != null)
                                                factura.Codigo_Detraccion = resultXML.PaymentTerms[i].PaymentMeansID[0].Value;

                                            if (resultXML.PaymentTerms[i].PaymentMeansID[0] == null)
                                                factura.Codigo_Detraccion = "";

                                        }

                                        if (resultXML.PaymentTerms[i].PaymentPercent != null)
                                            factura.PorcentajeDetraccion = resultXML.PaymentTerms[i].PaymentPercent.Value;

                                        if (resultXML.PaymentTerms[i].PaymentPercent == null)
                                            factura.PorcentajeDetraccion = 0;


                                        if (resultXML.PaymentTerms[i].Amount != null)
                                            factura.MontoDetraccion = resultXML.PaymentTerms[i].Amount.Value;

                                        if (resultXML.PaymentTerms[i].Amount == null)
                                            factura.MontoDetraccion = 0;

                                    }

                                    if (resultXML.PaymentTerms[i].PaymentMeansID != null)
                                    {

                                        if (resultXML.PaymentTerms[i].PaymentMeansID[0].Value != null)
                                        {

                                            if (resultXML.PaymentTerms[i].PaymentMeansID[0].Value.ToLower().Contains("cuota"))
                                            {
                                                string Cuota = resultXML.PaymentTerms[i].PaymentMeansID[0].Value;
                                                int Largo = Cuota.Length;
                                                string NroCuota = Cuota.Substring(5, Largo - 5).Replace("0", "");

                                                string montoCuota = resultXML.PaymentTerms[i].Amount?.Value.ToString();
                                                string descripcionCuota = resultXML.PaymentTerms[i].PaymentMeansID[0]?.Value;
                                                DateTime? fechaCuota = resultXML.PaymentTerms[i].PaymentDueDate?.Value;

                                                if (NroCuota == "1")
                                                {
                                                    factura.FechaVencimientoPago = fechaCuota;
                                                }


                                                DetalleCuota.Add((montoCuota == null ? "No se encontro el monto" : montoCuota) +
                                                                  " - " + (descripcionCuota == null ? "No se encontro la descripcion" : descripcionCuota) +
                                                                  " - " + (fechaCuota == null ? "No se encontro la fecha" : fechaCuota.ToString()));

                                            }

                                        }


                                    }

                                }


                            }

                            if (DetalleCuota.Count > 0)
                                factura.CuotasDetalle = DetalleCuota;
                        }

                    }

                    if (factura.Codigo_Detraccion == null)
                    {
                        int? lentResultXML = resultXML.Note?.Length;

                        if (lentResultXML != null)
                        {
                            for (int i = 0; i < resultXML.Note.Length; i++)
                            {
                                if (resultXML.Note[i].Value != null)
                                {
                                    if (resultXML.Note[i].Value.Contains("DETRACCION"))
                                    {
                                        factura.Codigo_Detraccion = resultXML.Note[i].Value;
                                    }
                                }
                            }
                        }

                    }



                }
                catch (System.Exception ex)
                {
                    respuesta.Satisfactorio = false;
                    respuesta.Detalle = $"La factura tiene una fecha de emisión {factura.FechaEmision.ToString("dd/MM/yyyy")} y debería tener la sección de términos de pago el cual no tiene. Por lo cual el archivo ingresado no es un documento válido de SUNAT";
                    respuesta.Titulo = ex.Message;
                    return respuesta;
                }




                string Proveedor_RazonSocial = string.Empty;
                string Cliente_RazonSocial = string.Empty;
                try
                {
                    int? lengthEmi = resultXML.AccountingSupplierParty.Party.PartyTaxScheme?.Length;
                    int? lengthEmi2 = resultXML.AccountingSupplierParty.Party.PartyLegalEntity?.Length;
                    int? lengthCli = resultXML.AccountingCustomerParty.Party.PartyTaxScheme?.Length;
                    int? lengthCli2 = resultXML.AccountingCustomerParty.Party.PartyLegalEntity?.Length;

                    if (lengthEmi != null)
                    {
                        if (resultXML.AccountingSupplierParty.Party.PartyTaxScheme[0].RegistrationName != null
                            && !string.IsNullOrEmpty(resultXML.AccountingSupplierParty.Party.PartyTaxScheme[0].RegistrationName.Value))
                            Proveedor_RazonSocial = resultXML.AccountingSupplierParty.Party.PartyTaxScheme[0].RegistrationName.Value;
                    }
                    if (lengthEmi2 != null)
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
                    if (lengthCli2 != null)
                    {
                        if (resultXML.AccountingCustomerParty.Party.PartyLegalEntity[0].RegistrationName != null
                            && !string.IsNullOrEmpty(resultXML.AccountingCustomerParty.Party.PartyLegalEntity[0].RegistrationName.Value))
                            Cliente_RazonSocial = resultXML.AccountingCustomerParty.Party.PartyLegalEntity[0].RegistrationName.Value;
                    }
                }
                catch (System.Exception ex)
                {
                    respuesta.Satisfactorio = false;
                    respuesta.Detalle = "El archivo ingresado no es un documento válido de SUNAT";
                    respuesta.Titulo = ex.Message;
                    return respuesta;

                }

                factura.Proveedor_NroIdentificacion = rucEmisor;
                factura.Cliente_RazonSocial = Cliente_RazonSocial;
                factura.Proveedor_RazonSocial = Proveedor_RazonSocial;
                factura.FechaEmision = resultXML.IssueDate.Value;



                factura.Cliente_NroIdentificacion = rucCliente;
                factura.Moneda_Id = resultXML.DocumentCurrencyCode.Value;
                if (resultXML.LegalMonetaryTotal.ChargeTotalAmount != null)
                    factura.OtroCargo = resultXML.LegalMonetaryTotal.ChargeTotalAmount.Value;




                StatusSimpleResponse regsitrar = await this.ProcesoSimple(() => this._comprobanteRepository.Registrar(factura),"");

                if (!regsitrar.Satisfactorio)
                {
                    respuesta.Codigo = 500;
                    respuesta.Titulo = "Ocurrio un error.";
                    respuesta.Detalle = regsitrar.Detalle;
                    return respuesta;
                }
                respuesta.Data = factura; // aqui

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

using LectorXML.Backend.Application.Comun;
using LectorXML.Backend.Infraestructure.Comprobante.DTO;
using LectorXML.Backend.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LectorXML.Backend.Application.Comprobantes
{
    public class ComprobanteApp:BaseApp<ComprobanteApp> {
    
        public ComprobanteApp() 
        { 
            
        }
        
        public async Task <string> DevolverCadena()
        {
            string cadena = "Operación exitosa";
            return cadena;
        }

        ////public FileResponse ParciarDocumentoAObjeto(IFormFile file)
        ////{
        ////    FileResponse response = new FileResponse();
        ////    response.Name = file.FileName;
        ////    return response;
        ////}

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
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    fileResponse.XmlContent = reader.ReadToEnd(); // Leer el contenido completo del archivo
                }

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

    }
}

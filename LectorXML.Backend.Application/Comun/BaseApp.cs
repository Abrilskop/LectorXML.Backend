using LectorXML.Backend.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorXML.Backend.Application.Comun
{
    public class BaseApp<T>
    {

        private readonly string _connectionString;
        //public BaseApp(ILogger<BaseApp<T>> logger)
        //{
        //    _logger = logger;

        //}
        public BaseApp()
        { 

        }

        protected async Task<StatusSimpleResponse> ProcesoSimple(Func<Task> callback, string titulo)
        {
            var response = new StatusSimpleResponse();

            try
            {
                await callback();

                response.Satisfactorio = true;
                response.Titulo = titulo;
            }
            catch (Exception ex)
            {
                response.Satisfactorio = false;
                response.Titulo = "Sucedió un error inesperado.";
                response.Detalle = ex.ToString();
            }

            return response;
        }


        protected async Task<StatusResponse<T>> ProcesoComplejo<T>(Func<Task<T>> callbackData, string titulo = "")
        {
            var response = new StatusResponse<T>();

            try
            {
                response.Data = await callbackData();

                response.Titulo = titulo;
                response.Satisfactorio = true;
            }
            
            catch (Exception ex)
            {
                response.Titulo = "Sucedió un error inesperado.";
                response.Detalle = ex.ToString();
                response.Satisfactorio = false;
            }

            return response;
        }



    }
}

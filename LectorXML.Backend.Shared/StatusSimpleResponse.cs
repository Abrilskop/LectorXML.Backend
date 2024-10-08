﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectorXML.Backend.Shared
{
    public class StatusSimpleResponse
    {
        public Guid Id { get; set; }
        public bool Satisfactorio { get; set; }
        public string Titulo { get; set; }
        public string Detalle { get; set; }
        public int Codigo { get; set; }
        public Dictionary<string, List<string>> Errores { get; set; }

        public StatusSimpleResponse() : this(true, "")
        {
            this.Id = Guid.NewGuid();
            this.Titulo = null;
            this.Detalle = null;
        }

        public StatusSimpleResponse(bool satisfactorio, string titulo)
        {
            this.Id = Guid.NewGuid();
            this.Satisfactorio = satisfactorio;
            this.Titulo = titulo;
        }

        public StatusSimpleResponse(bool satisfactorio, string titulo, string detalle)
        {
            this.Id = Guid.NewGuid();
            this.Satisfactorio = satisfactorio;
            this.Titulo = titulo;
            this.Detalle = detalle;
        }

        public StatusSimpleResponse(string titulo, Dictionary<string, List<string>> errores)
        {
            this.Id = Guid.NewGuid();
            this.Satisfactorio = false;
            this.Titulo = titulo;
            this.Detalle = null;
            this.Errores = errores;
        }

        public StatusSimpleResponse(string titulo, string detalle, Dictionary<string, List<string>> errores)
        {
            this.Id = Guid.NewGuid();
            this.Satisfactorio = false;
            this.Titulo = titulo;
            this.Detalle = detalle;
            this.Errores = errores;
        }
    }
}

﻿using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Discos
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public  int Canciones { get; set; }
        public string URLimagenTapa{ get; set; }
        //public string idEstilo { get; set; }
        public Estilos Genero { get; set; }
        public Estilos RegionOrigen { get; set; }
        public TiposEdicion Tipo { get; set; }

    }
}
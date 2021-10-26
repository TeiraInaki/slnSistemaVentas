using Datos.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class Vendedor : Persona
    {
        public decimal Comision { get; set; }
    }
}

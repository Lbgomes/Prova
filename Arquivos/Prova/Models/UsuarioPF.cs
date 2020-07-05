using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Models
{
    public class UsuarioPF
    {
        public int IdUsuarioPf { get; set; }

        public string NomeUsuario { get; set; }
        public int IdTipo { get; set; }
        public int NumeroCpf { get; set; }
        public int Telefone { get; set; }
    }
}

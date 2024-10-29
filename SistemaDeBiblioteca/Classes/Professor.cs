using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBiblioteca.Classes
{
    internal class Professor : Usuario
    {
        private string NomeDeLogin { get; set; }
        private int SenhaDeAcesso { get; set; }
        private string CPF { get; set; }
    }
}

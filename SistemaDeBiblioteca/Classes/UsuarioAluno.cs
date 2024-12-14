 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeBiblioteca.Classes
{
    internal class UsuarioAluno : Usuario
    {
        private string NomeDeLogin { get;set; }
        private int SenhaDeAcesso { get; set; }
        private int NumeroDeMatricula { get; set; }
        
        // relacionamento 1:1:
        public Exemplar ExemplarRetirado { get; set; }
    }
}

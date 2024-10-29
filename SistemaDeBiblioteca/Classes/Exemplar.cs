using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace SistemaDeBiblioteca.Classes
{
    internal class Exemplar
    {
        private DateTime DataEmprestimo { get; set; }
        private DateTime DataDevolucao { get; set; }

        // relacionamento 1:1:
        private UsuarioExterno UsuarioQueRetirou { get; set; }

        public static void CalculaDataDevolucao()
        {

        }

        public static void IdentificarAtraso()
        {

        }
    }
}

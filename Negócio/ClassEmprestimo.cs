using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca
{
    public class ClassEmprestimo
    {
        public string codEmpre
        {
            get;
            set;
        }
        public DateTime dataEmprestimo
        {
            get; set;
        }
        public int codCliente
        { 
            get; set;
        }
        public int codLivro
        {
            get; set;
        }

        //construtores
        public ClassEmprestimo() { }

        public ClassEmprestimo(DateTime dataEmprestimo, int codCliente, int codLivro) 
        {
            this.dataEmprestimo = dataEmprestimo;
            this.codCliente = codCliente;
            this.codLivro = codLivro;

            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Negócio
{
    public class ClassCliente
    {
        public string CodClie
        {
            get;
            set;
        }

        public string NomeClie
        {
            set;
            get;
        }


        //Construtores

        public ClassCliente(){}

        public ClassCliente(string NomeClie)
        {
            this.NomeClie = NomeClie;
        }


        
    }
}
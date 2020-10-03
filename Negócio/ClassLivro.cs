using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.Negócio
{
    public class ClassLivro
    {
        public string cod_liv { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public string edicao { get; set; }
        public string editora { get; set; }

        public ClassLivro() { }

        public ClassLivro(string titulo, string autor, string edicao, string editora)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.edicao = edicao;
            this.editora = editora;
        }
       

    }
}
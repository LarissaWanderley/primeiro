using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicial.Models
{
    public class Produto
    {
        
        public int Id { get; set; }

        public String Nome { get; set; }

        public int Preco { get; set; }

      //  public CategoriaDoProduto Categoria { get; set; }

        public int? IdCategoria { get; set; }

        public String Descricao { get; set; }

        public int Quantidade { get; set; }
    }
   
}
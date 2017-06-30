using DBBroker.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inicial.Dominio
{
    [DBBroker.Mapping.DBMappedClass(Table = "ZProduto", PrimaryKey = "IdProduto")]
    public class Produto
    {
        [DBMappedTo(Column ="IdProduto")]
        public int Id { get; set; }

        [StringLengthAttribute(30),Required]
        public string Nome { get; set; }

        [Range(0.0, 10000.0)]
        public decimal Preco { get; set; }

    //    public CategoriaDoProduto Categoria { get; set; }

        public int? IdCategoria { get; set; }

        [StringLengthAttribute(50)]
        public string Descricao { get; set; }

        public int Quantidade { get; set; }
    }
}
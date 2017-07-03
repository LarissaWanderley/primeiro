using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBBroker.Mapping;
using System.ComponentModel.DataAnnotations;

namespace Inicial.Dominio
{
    [DBMappedClass(Table = "ZCategoria", PrimaryKey = "IdCategoria")]
    public class CategoriaDoProduto
    {
        public int Id { get; set; }

        [StringLengthAttribute(50)]
        public string Nome { get; set; }

        [StringLengthAttribute(50)]
        public String Descricao { get; set; }

    }
}
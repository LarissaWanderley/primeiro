using DBBroker.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inicial.Dominio
{
    [DBBroker.Mapping.DBMappedClass(Table = "ZUsuario", PrimaryKey = "IdUsuario")]
    public class Usuario
    {
        [DBMappedTo(Column = "IdUsuario")]
        public int Id { get; set; }

        [StringLengthAttribute(50),Required]
        public string Nome { get; set; }

        [StringLengthAttribute(10), Required]
        public string Senha { get; set; }

        [DBReadOnly(DBDefaultValue ="GETDATE()")]
        public DateTime Cadastro { get;  set; }

        [StringLengthAttribute(50), Required,EmailAddress]
        public string Email { get; set; }

    }
   
}
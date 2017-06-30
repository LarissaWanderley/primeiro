using DBBroker.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicial.Dominio
{
    [DBBroker.Mapping.DBMappedClass(Table = "ZUsuario", PrimaryKey = "IdUsuario")]
    public class Usuario
    {
        [DBMappedTo(Column = "IdUsuario")]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        [DBReadOnly(DBDefaultValue ="GETDATE()")]
        public DateTime Cadastro { get;  set; }
    }
}
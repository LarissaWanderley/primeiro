using DBBroker.Engine;
using Inicial.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inicial.Persistencia
{
    public class DBCategoriaDoProduto : DBBroker<CategoriaDoProduto>
    {
        public static List<CategoriaDoProduto> GetByNome(string nome)
        {
            return ExecCmdSQL(cmdText: "SELECT * FROM ZCategoria WHERE Nome = @Nome "
                , parameters: new List<DbParameter>() { new SqlParameter("@Nome", nome) });
        }
        
    }
}
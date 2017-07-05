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
    public class DBProduto : DBBroker<Produto>
    {
        public static List<Produto> GetByNome(string nome)
        {
            return ExecCmdSQL(cmdText: "SELECT * FROM ZProduto WHERE Nome = @Nome "
                ,parameters: new List<DbParameter>() { new SqlParameter("@Nome", nome) });
        }
        public static List<Produto> PesqProdutoPorCategoria(int idCategoria)
        {
            return ExecCmdSQL(cmdText: "SELECT * FROM ZProduto WHERE IdCategoria = @IdCategoria "
                , parameters: new List<DbParameter>() { new SqlParameter("@IdCategoria", idCategoria) });
        }
    }
}
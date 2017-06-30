using DBBroker.Engine;
using Inicial.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;

namespace Inicial.Persistencia
{
    public class DBUsuario : DBBroker<Usuario>
    {
        public static Usuario ValidaLogin(string login, string senha)
        {
            var paramentros = new List<DbParameter>()
            {
                new SqlParameter("@Nome", login),
                new SqlParameter("@Senha", senha)
            };

            return ExecCmdSQL("SELECT * FROM ZUsuario WHERE Nome = @Nome AND Senha = @Senha ", parameters: paramentros).FirstOrDefault();
                           
        }
        public static Usuario ValidaLogin(string login, string senha)
        {
            var paramentros = new List<DbParameter>()
            {
                new SqlParameter("@Nome", login),
                new SqlParameter("@Senha", senha)
            };

            return ExecCmdSQL("SELECT * FROM ZUsuario WHERE Nome = @Nome AND Senha = @Senha ", parameters: paramentros).FirstOrDefault();

        }
    }
}
using CSharpSeleniumLarissaBicalho.Helpers;
using CSharpSeleniumTemplate.Queries;

namespace CSharpSeleniumLarissaBicalho.DataBaseSteps
{
    public class UsuariosDBSteps
    {
        public static string RetornaSenhaDoUsuario(string username)
        {
            string query = UsuariosQueries.RetornaSenhaUsuario.Replace("$username", username);

            return DataBaseHelpers.RetornaDadosQuery(query)[0];
        }
    }
}

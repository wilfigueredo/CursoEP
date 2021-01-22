using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Eventos.IO.Infra.CrossCutting.Identity.Models.AccountViewModels;
using Eventos.IO.Tests.API.Integration_Tests.DTO;
using Newtonsoft.Json;

namespace Eventos.IO.Tests.API.Integration_Tests
{
    public class UserUtils
    {
        public static async Task<Result> RealizarLoginOrganizador(HttpClient client)
        {
            var user = new LoginViewModel
            {
                Email = "contato@eduardopires.net.br",
                Senha = "Teste@123"
            };

            var postContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("api/v1/conta", postContent);

            var postResult = await response.Content.ReadAsStringAsync();
            var userResult = JsonConvert.DeserializeObject<UserReturnJson>(postResult);

            return userResult.data.result;
        }
    }
}
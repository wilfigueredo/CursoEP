using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Eventos.IO.Services.Api.ViewModels;
using Eventos.IO.Tests.API.Integration_Tests.DTO;
using Newtonsoft.Json;
using Xunit;

namespace Eventos.IO.Tests.API.Integration_Tests
{
    public class EventosControllerIntegrationTests
    {
        public EventosControllerIntegrationTests()
        {
            Environment.CriarServidor();
        }

        [Fact(DisplayName = "Evento registrado com sucesso")]
        [Trait("Category", "Testes de integração API")]
        public async Task EventosController_RegistrarNovoEvento_RetornarComSucesso()
        {
            // Arrange
            var login = await UserUtils.RealizarLoginOrganizador(Environment.Client);

            var evento = new EventoViewModel
            {
                Nome = "DevXperience",
                DescricaoCurta = "Um evento de tecnologia",
                DescricaoLonga = "Um evento de tecnologia",
                CategoriaId = new Guid("ac381ba8-c187-482c-a5cb-899ad7176137"),
                DataInicio = DateTime.Now.AddDays(1),
                DataFim = DateTime.Now.AddDays(2),
                Gratuito = false,
                Valor = 500,
                NomeEmpresa = "DevX",
                Online = true,
                Endereco = new EnderecoViewModel(),
                OrganizadorId = new Guid(login.user.id)
            };

            // Act
            var response = await Environment.Server
                .CreateRequest("api/v1/eventos")
                .AddHeader("Authorization", "Bearer " + login.access_token)
                .And(
                    request =>
                        request.Content =
                            new StringContent(JsonConvert.SerializeObject(evento), Encoding.UTF8, "application/json"))
                //.And(request => request.Method = HttpMethod.Put)
                .PostAsync();

            var eventoResult = JsonConvert.DeserializeObject<EventoReturnJson>(await response.Content.ReadAsStringAsync());

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.IsType<EventoDTO>(eventoResult.data);
        }
    }
}
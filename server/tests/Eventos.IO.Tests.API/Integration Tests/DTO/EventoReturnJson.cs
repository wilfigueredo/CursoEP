using System;

namespace Eventos.IO.Tests.API.Integration_Tests.DTO
{
    public class EventoReturnJson
    {
        public bool success { get; set; }
        public EventoDTO data { get; set; }
    }

    public class EventoDTO
    {
        public Endereco endereco { get; set; }
        public string id { get; set; }
        public string nome { get; set; }
        public string descricaoCurta { get; set; }
        public string descricaoLonga { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public bool gratuito { get; set; }
        public float valor { get; set; }
        public bool online { get; set; }
        public string nomeEmpresa { get; set; }
        public string organizadorId { get; set; }
        public string categoriaId { get; set; }
        public DateTime timestamp { get; set; }
        public string messageType { get; set; }
        public string aggregateId { get; set; }
    }

    public class Endereco
    {
        public string id { get; set; }
        public object logradouro { get; set; }
        public object numero { get; set; }
        public object complemento { get; set; }
        public object bairro { get; set; }
        public object cep { get; set; }
        public object cidade { get; set; }
        public object estado { get; set; }
        public string eventoId { get; set; }
        public DateTime timestamp { get; set; }
        public string messageType { get; set; }
        public string aggregateId { get; set; }
    }
}
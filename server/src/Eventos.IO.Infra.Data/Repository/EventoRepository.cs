using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Eventos.IO.Domain.Eventos;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Eventos.IO.Infra.Data.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(EventosContext context) : base(context)
        {
            
        }

        public override IEnumerable<Evento> ObterTodos()
        {
            var sql = "SELECT * FROM EVENTOS E " +
                      "WHERE E.EXCLUIDO = 0 " +
                      "ORDER BY E.DATAFIM DESC ";

            return Db.Database.GetDbConnection().Query<Evento>(sql);
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            Db.Enderecos.Add(endereco);
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            Db.Enderecos.Update(endereco);
        }

        public Endereco ObterEnderecoPorId(Guid id)
        {
            var sql = @"SELECT * FROM Enderecos E " +
                      "WHERE E.Id = @uid";

            var endereco = Db.Database.GetDbConnection().Query<Endereco>(sql, new { uid = id });

            return endereco.SingleOrDefault();
        }

        public IEnumerable<Evento> ObterEventoPorOrganizador(Guid organizadorId)
        {
            var sql = @"SELECT * FROM EVENTOS E " +
                       "WHERE E.EXCLUIDO = 0 " +
                       "AND E.ORGANIZADORID = @oid " +
                       "ORDER BY E.DATAFIM DESC";

            return Db.Database.GetDbConnection().Query<Evento>(sql, new {oid = organizadorId});
        }

        public Evento ObterMeuEventoPorId(Guid id, Guid organizadorId)
        {
            var sql = @"SELECT * FROM EVENTOS E " +
                      "LEFT JOIN Enderecos EN " +
                      "ON E.Id = EN.EventoId " +
                      "WHERE E.EXCLUIDO = 0 " +
                      "AND E.ORGANIZADORID = @oid " +
                      "AND E.ID = @eid";

            var evento = Db.Database.GetDbConnection().Query<Evento, Endereco, Evento>(sql,
                (e, en) =>
                {
                    if (en != null)
                        e.AtribuirEndereco(en);

                    return e;
                },
                new {oid = organizadorId, eid = id});

            return evento.FirstOrDefault();
        }

        public IEnumerable<Categoria> ObterCategorias()
        {
            var sql = @"SELECT * FROM Categorias";
            return Db.Database.GetDbConnection().Query<Categoria>(sql);
        }

        public override Evento ObterPorId(Guid id)
        {
            var sql = @"SELECT * FROM Eventos E " +
                      "LEFT JOIN Enderecos EN " +
                      "ON E.Id = EN.EventoId " +
                      "WHERE E.Id = @uid";

            var evento = Db.Database.GetDbConnection().Query<Evento, Endereco, Evento>(sql,
                (e, en) =>
                {
                    if (en != null)
                        e.AtribuirEndereco(en);

                    return e;
                }, new {uid = id});

            return evento.FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            var evento = ObterPorId(id);
            evento.ExcluirEvento();
            Atualizar(evento);
        }
    }
}
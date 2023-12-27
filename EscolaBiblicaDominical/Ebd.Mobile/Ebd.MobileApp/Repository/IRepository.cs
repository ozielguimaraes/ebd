using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ebd.Mobile.Repository
{
    public interface IRepository
    {
        T Adicionar<T>(T item);
        bool AdicionarItens<T>(IEnumerable<T> itens);
        bool Atualizar<T>(T item);
        bool Deletar<T>(BsonValue id);
        int DeleteAll<T>();
        bool Upsert<T>(BsonValue id, T item);
        bool Upsert<T>(IEnumerable<T> itens);
        T ObterPorId<T>(BsonValue id);
        IEnumerable<T> ObterTodos<T>();
        IEnumerable<T> Filtrar<T>(Expression<Func<T, bool>> expression);
        bool Exist<T>(Expression<Func<T, bool>> expression);
        int Count<T>(Expression<Func<T, bool>> expression);
    }
}

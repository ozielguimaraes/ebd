using Ebd.Mobile.Constants;
using Ebd.Mobile.Infrastructure;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Ebd.Mobile.Repository
{
    public sealed class Repository : IRepository
    {
        private static LiteDatabase dataBase;
        private static LiteDatabase DataBase
        {
            get
            {
                var dataFile = DependencyService.Get<IFilePath>().GetFullPath(ConfigurationConstant.DatabaseName);
                if (dataBase is null)
                    dataBase = new LiteDatabase(dataFile);

                return dataBase;
            }
        }

        public T Adicionar<T>(T item)
        {
            _ = DataBase.GetCollection<T>().Insert(item);
            return item;
        }

        public bool AdicionarItens<T>(IEnumerable<T> itens)
        {
            var count = DataBase.GetCollection<T>().InsertBulk(itens);
            return count > 0;
        }

        public bool Atualizar<T>(T item)
        {
            if (item is null) return true;

            return DataBase.GetCollection<T>().Update(item);
        }

        public int Count<T>() => DataBase.GetCollection<T>().Count();

        public int Count<T>(Expression<Func<T, bool>> expression) => DataBase.GetCollection<T>().Count(expression);

        public bool Deletar<T>(BsonValue id)
        {
            var isDeleted = DataBase.GetCollection<T>().Delete(id);
            return isDeleted;
        }

        public bool Exist<T>(Expression<Func<T, bool>> expression)
            => DataBase.GetCollection<T>().Exists(expression);

        public bool Any<T>(Expression<Func<T, bool>> expression) => Count<T>() > 0;

        public IEnumerable<T> Filtrar<T>(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public T ObterPorId<T>(BsonValue id) => DataBase.GetCollection<T>().FindById(id);

        public IEnumerable<T> ObterTodos<T>() => DataBase.GetCollection<T>().FindAll();

        public bool Upsert<T>(BsonValue id, T item)
        {
            bool ret = DataBase.GetCollection<T>().Upsert(id, item);
            return ret;
        }

        public bool Upsert<T>(IEnumerable<T> itens)
        {
            var count = DataBase.GetCollection<T>().Upsert(itens);
            return count > 0;
        }

        public bool DeleteItems<T>(Expression<Func<T, bool>> predicate)
        {
            return DataBase.GetCollection<T>().DeleteMany(predicate) > 0;
        }

        public IEnumerable<T> FiltrarItens<T>(Query query, int limit = int.MaxValue)
        {
            return DataBase
                ?.GetCollection<T>()
                ?.Find(query: Query.All(Query.Descending), limit: limit)
                ?.Take(limit);
        }

        public IEnumerable<T> FiltrarItens<T>(Expression<Func<T, bool>> predicate) => DataBase.GetCollection<T>().Find(predicate);

        public int DeleteAll<T>() => DataBase.GetCollection<T>()?.DeleteAll() ?? 0;
    }
}
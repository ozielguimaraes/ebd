using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;

namespace Ebd.Infra.Data.Repositories
{
    public class BairroRepository : BaseRepository<Bairro>, IBairroRepository
    {
        public Bairro Adicionar(Bairro bairro)
        {
            Db.Set<Bairro>().Add(bairro);
        }

        public void Atualizar(Bairro bairro)
        {
            throw new System.NotImplementedException();
        }

        public Bairro ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Bairro> ObterTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}

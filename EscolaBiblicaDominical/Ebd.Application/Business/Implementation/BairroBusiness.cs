using Ebd.Application.Business.Interfaces;
using Ebd.Application.Mappers;
using Ebd.Application.Responses;
using Ebd.Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Implementation
{
    public class BairroBusiness : IBairroBusiness
    {
        private readonly IBairroRepository _bairroRepository;

        public BairroBusiness(IBairroRepository bairroRepository)
        {
            _bairroRepository = bairroRepository;
        }

        public async Task<IEnumerable<BairroResponse>> ObterTodos()
        {
            var result = await _bairroRepository.ObterTodos();

            return BairroMapper.FromEntityToResponse(result);
        }
    }
}

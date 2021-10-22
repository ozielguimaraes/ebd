using Ebd.Mobile.Services.Responses.Aluno;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoResponse>> ObterTodosAsync();
    }
}

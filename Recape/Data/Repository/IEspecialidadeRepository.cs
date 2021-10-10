using Recape.Models;
using System.Collections.Generic;

namespace Recape.Data.Repository
{
    public interface IEspecialidadeRepository
    {
        List<Especialidade> GetEspecialidades();
    }
}

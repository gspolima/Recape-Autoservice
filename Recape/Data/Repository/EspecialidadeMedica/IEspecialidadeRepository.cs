using Recape.Models;
using System.Collections.Generic;

namespace Recape.Data.Repository.Especialidades
{
    public interface IEspecialidadeRepository
    {
        List<Especialidade> GetEspecialidades();
    }
}

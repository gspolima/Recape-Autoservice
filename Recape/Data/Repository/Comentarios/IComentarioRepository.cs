using Recape.Models;
using System.Linq;

namespace Recape.Data.Repository.Comentarios
{
    public interface IComentarioRepository
    {
        bool Insert(Comentario comentario);
        public IQueryable<Comentario> GetComentarios();
    }
}

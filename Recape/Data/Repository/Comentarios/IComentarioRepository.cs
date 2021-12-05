namespace Recape.Data.Repository.Comentarios;

public interface IComentarioRepository
{
    bool Insert(Comentario comentario);
    public IQueryable<Comentario> GetComentarios();
}

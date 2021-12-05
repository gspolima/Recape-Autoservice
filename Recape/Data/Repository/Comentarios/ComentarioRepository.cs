namespace Recape.Data.Repository.Comentarios;

public class ComentarioRepository : IComentarioRepository
{

    private readonly RecapeDbContext dbContext;

    public ComentarioRepository(RecapeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public bool Insert(Comentario comentario)
    {
        dbContext.Comentarios.Add(comentario);
        return dbContext.SaveChanges() > 0;
    }

    public IQueryable<Comentario> GetComentarios()
    {
        var comentarios = dbContext.Comentarios
            .Include(c => c.OrdemDeServico)
            .ThenInclude(o => o.Servico)
            .Include(c => c.OrdemDeServico)
            .ThenInclude(o => o.Cliente)
            .Where(c =>
                c.OrdemDeServico.Avaliado == true &&
                c.OrdemDeServico.Finalizado == true);

        return comentarios;
    }
}

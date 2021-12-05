namespace Recape.Data.Repository.Horarios;

public interface IHorarioRepository
{
    public IQueryable<Horario> GetHorarios();
}

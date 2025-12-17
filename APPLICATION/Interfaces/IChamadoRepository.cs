using DOMAIN.Entities;



namespace APPLICATION.Interfaces
{
    public interface IChamadoRepository
    {
        Task<Chamado> GetByIdAsync(Guid id);
        Task<IEnumerable<Chamado>> GetAllAsync();
        Task<Chamado> AddAsync(Chamado chamado);
        Task UpdateAsync(Chamado chamado);
        Task DeleteAsync(Guid id);
    }
}
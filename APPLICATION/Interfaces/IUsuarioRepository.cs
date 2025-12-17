
using DOMAIN.Entities;

namespace APPLICATION.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByIdAsync(Guid id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Guid id);
    }
}
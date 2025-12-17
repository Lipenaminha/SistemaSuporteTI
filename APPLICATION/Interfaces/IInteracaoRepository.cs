
using DOMAIN.Entities;

namespace APPLICATION.Interfaces
{
    public interface IInteracaoRepository
    {
        Task<Interacao> AddAsync(Interacao interacao);
        Task<IEnumerable<Interacao>> GetByChamadoIdAsync(Guid chamadoId);
    }
}
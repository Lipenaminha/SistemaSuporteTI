
using DOMAIN.Entities;
using APPLICATION.Interfaces;


namespace APPLICATION.UseCases
{
    public class ChamadoService
    {
        private readonly IChamadoRepository _chamadoRepository;

        public ChamadoService(IChamadoRepository chamadoRepository)
        {
            _chamadoRepository = chamadoRepository;
        }

        public async Task<Chamado> GetChamadoByIdAsync(Guid id)
        {
            return await _chamadoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Chamado>> GetAllChamadosAsync()
        {
            return await _chamadoRepository.GetAllAsync();
        }

        public async Task<Chamado> CreateChamadoAsync(Chamado chamado)
        {
            return await _chamadoRepository.AddAsync(chamado);
        }

        public async Task UpdateChamadoAsync(Chamado chamado)
        {
            await _chamadoRepository.UpdateAsync(chamado);
        }

        public async Task DeleteChamadoAsync(Guid id)
        {
            await _chamadoRepository.DeleteAsync(id);
        }
    }
}
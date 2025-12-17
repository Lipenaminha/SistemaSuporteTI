
using DOMAIN.Entities;
using APPLICATION.Interfaces;



namespace APPLICATION.UseCases
{
    public class InteracaoService
    {
        private readonly IInteracaoRepository _interacaoRepository;

        public InteracaoService(IInteracaoRepository interacaoRepository)
        {
            _interacaoRepository = interacaoRepository;
        }

        public async Task<Interacao> CreateInteracaoAsync(Interacao interacao)
        {
            return await _interacaoRepository.AddAsync(interacao);
        }

        public async Task<IEnumerable<Interacao>> GetInteracoesByChamadoIdAsync(Guid chamadoId)
        {
            return await _interacaoRepository.GetByChamadoIdAsync(chamadoId);
        }
    }
}
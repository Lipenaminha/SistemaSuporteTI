using APPLICATION.Interfaces;
using DOMAIN.Entities;
using INFRAESTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRAESTRUCTURE.Repositories
{
    public class InteracaoRepository : IInteracaoRepository
    {
        private readonly AppDbContext _context;

        public InteracaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Interacao> AddAsync(Interacao interacao)
        {
            _context.Interacoes.Add(interacao);
            await _context.SaveChangesAsync();
            return interacao;
        }

        public async Task<IEnumerable<Interacao>> GetByChamadoIdAsync(Guid chamadoId)
        {
            return await _context.Interacoes
                .Where(i => i.ChamadoId == chamadoId)
                .ToListAsync();
        }
    }
}
using APPLICATION.Interfaces;
using DOMAIN.Entities;
using INFRAESTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRAESTRUCTURE.Repositories
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly AppDbContext _context;

        public ChamadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Chamado> AddAsync(Chamado chamado)
        {
            _context.Chamados.Add(chamado);
            await _context.SaveChangesAsync();
            return chamado;
        }

        public async Task<IEnumerable<Chamado>> GetAllAsync()
        {
            return await _context.Chamados.ToListAsync();
        }

        public async Task<Chamado> GetByIdAsync(Guid id)
        {
            return await _context.Chamados.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Chamado chamado)
        {
            _context.Chamados.Update(chamado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var chamado = await GetByIdAsync(id);
            if (chamado == null) return;

            _context.Chamados.Remove(chamado);
            await _context.SaveChangesAsync();
        }
    }
}
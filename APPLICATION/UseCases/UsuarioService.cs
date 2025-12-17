using DOMAIN.Entities;
using APPLICATION.Interfaces;



namespace APPLICATION.UseCases
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(Guid id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            return await _usuarioRepository.AddAsync(usuario);
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteUsuarioAsync(Guid id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }
    }
}
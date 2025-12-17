using DOMAIN.Enums;



namespace DOMAIN.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string SenhaHash { get; private set; }
        public TipoUsuario Tipo { get; private set; }

        protected Usuario() { }

        public Usuario(string nome, string email, string senhaHash, TipoUsuario tipo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Tipo = tipo;
        }
    }
}


using DOMAIN.Enums;


namespace DOMAIN.Entities
{
    public class Chamado
    {
        public Guid Id { get; private set; }
        public Guid UsuarioId { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public PrioridadeChamado Prioridade { get; private set; }
        public StatusChamado Status { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public DateTime? DataFechamento { get; private set; }

        public ICollection<Interacao> Interacoes { get; private set; } = new List<Interacao>();

        protected Chamado() { }

        public Chamado(Guid usuarioId, string titulo, string descricao, PrioridadeChamado prioridade)
        {
            Id = Guid.NewGuid();
            UsuarioId = usuarioId;
            Titulo = titulo;
            Descricao = descricao;
            Prioridade = prioridade;
            Status = StatusChamado.Aberto;
            DataAbertura = DateTime.UtcNow;
        }

        public void Finalizar()
        {
            Status = StatusChamado.Finalizado;
            DataFechamento = DateTime.UtcNow;
        }
    }
}
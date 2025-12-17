 
 using DOMAIN.Enums;
 
 namespace API.DTOs

{
    public class CriarChamadoRequest
    {
        public Guid UsuarioId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

         public PrioridadeChamado Prioridade { get; set; }
    }
}
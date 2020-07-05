namespace CursoAspNetCore.Domain.Models
{
    public class SecretIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HeroId { get; set; }
        public Hero Hero { get; set; }
    }
}

namespace CursoAspNetCore.Domain.Models
{
    public class HeroBattles
    {
        public int Id { get; set; }
        public int HeroId { get; set; }
        public int BattleId { get; set; }
        public Hero Hero { get; set; }
        public Battle Battle { get; set; }
    }
}

using System.Collections.Generic;

namespace CursoAspNetCore.Domain.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<HeroBattles> HeroBattles { get; set; }
        public List<Weapon> Weapons { get; set; }
        public SecretIdentity SecretIdentity { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CursoAspNetCore.Domain.Models
{
    public class Battle
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateFinish { get; set; }
        public List<HeroBattles> HeroBattles { get; set; }
    }
}

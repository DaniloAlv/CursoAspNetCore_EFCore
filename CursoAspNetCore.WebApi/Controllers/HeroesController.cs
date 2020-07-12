using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CursoAspNetCore.Domain.Models;
using CursoAspNetCore.WebApi.Data;
using CursoAspnetCore.Data.Interfaces;

namespace CursoAspNetCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroRepository _heroRepository;

        public HeroesController(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetHeroes()
        {
            IEnumerable<Hero> heroes = await _heroRepository.GetAllHeroes();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHero(int id)
        {
            Hero hero = await _heroRepository.HeroById(id);

            if (hero == null)
            {
                return NotFound("Herói não encontrado!");
            }

            return Ok(hero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(int id, Hero hero)
        {
            Hero heroSearch = await _heroRepository.HeroById(id);

            if(heroSearch != null)
            {
                try
                {
                    _heroRepository.Update(hero);
                    await _heroRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            
                return Ok("Herói alterado com sucesso!");
            }

            return NotFound("Herói não encontrado!");
        }
                
        [HttpPost]
        public async Task<IActionResult> PostHero(Hero hero)
        {
            if(hero != null)
            {
                try
                {
                    await _heroRepository.Add(hero);
                    await _heroRepository.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
                
                return CreatedAtAction("Herói adicionado com sucesso!", hero);
            }

            return BadRequest("Você precisa informar dados para cadastrar um novo herói.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            Hero hero = await _heroRepository.HeroById(id);

            if (hero == null)
            {
                return NotFound("Herói não encontrado!");
            }

            try
            {
                _heroRepository.Remove(hero);
                await _heroRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return Ok($"{hero.Name} removido com sucesso.");
        }
    }
}

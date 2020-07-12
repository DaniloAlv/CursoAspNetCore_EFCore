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
    public class BattlesController : ControllerBase
    {
        private readonly IBattleRepository _battleRepository;

        public BattlesController(IBattleRepository battleRepository)
        {
            _battleRepository = battleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBattles()
        {
            IEnumerable<Battle> battles = await _battleRepository.GetAllBattles();
            return Ok(battles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBattle(int id)
        {
            Battle battle = await _battleRepository.BattleById(id);

            if (battle == null)
            {
                return NotFound("Batalha não encontrada!");
            }

            return Ok(battle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattle(int id, Battle battle)
        {
            Battle battleSearch = await _battleRepository.BattleById(id);

            if(battleSearch != null)
            {
                try
                {
                    _battleRepository.Update(battle);
                    await _battleRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return BadRequest($"Erro: {ex.Message}");
                }

                return Ok("Batalha alterada com sucesso!");
            }

            return NotFound("Batalha não encontrada!");
        }

        [HttpPost]
        public async Task<IActionResult> PostBattle(Battle battle)
        {
            try
            {
                await _battleRepository.Add(battle);
                await _battleRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return CreatedAtAction("Batalha criada com sucesso!", battle);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBattle(int id)
        {
            Battle battleSearch = await _battleRepository.BattleById(id);

            if (battleSearch == null)
            {
                return NotFound("Batalha não encontrada!");
            }

            try
            {
                _battleRepository.Remove(battleSearch);
                await _battleRepository.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return Ok("Batalha removida com sucesso!");
        }
    }
}

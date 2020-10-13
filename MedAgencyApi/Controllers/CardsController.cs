using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedAgencyDataAccess.Data;
using MedAgencyDataAccess.Entities;
using MedAgencyApi.Services;

namespace MedAgencyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly СardService _cardService;

        public CardsController(СardService cardService)
        {
            _cardService = cardService;
        }

        // GET: api/Cards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards()
        {
            
            return  Ok(await _cardService.GetCard());
        }

        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            var card = await _cardService.GetCard(id);

            if (card == null)
            {
                return NotFound();
            }

            return card;
        }

        // PUT: api/Cards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }

            

            try
            {
                _cardService.PutCard(id, card);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_cardService.CardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Card>> CreateCard(Card card)
        {
            await _cardService.CreateCard(card);

            return await _cardService.GetCard(card.Id);
        }



        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Card>> DeleteCard(int id)
        {
            var card = await _cardService.GetCard(id);
            if (card == null)
            {
                return NotFound();
            }


            return await _cardService.DeleteCard(card.Id);
        }

        private bool CardExists(int id)
        {
            return _cardService.CardExists(id);
        }
    }
}

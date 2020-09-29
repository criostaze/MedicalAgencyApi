using MedAgencyApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedAgencyApi.Services
{
	public class СardService
	{
		private readonly MedAgencyApiContext _context;
		public СardService(MedAgencyApiContext context)
		{
			_context = context;
		}


        public async Task<IEnumerable<Card>> GetCard()
        {
            return await _context.Card.ToListAsync();
        }

        public async Task<Card> GetCard(int id)
        {
            var card = await _context.Card.FindAsync(id);

            if (card == null)
            {
                return null;
            }

            return card;
        }

        public async void PutCard(int id, Card card)
        {
            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
                {
                    //return null;
                }
                else
                {
                   throw;
                }
            }
        }

        public async Task<Card> CreateCard(Card card)
        {
            _context.Card.Add(card);
            await _context.SaveChangesAsync();

            return null;
        }


        public async Task<Card> DeleteCard(int id)
        {
            var card = await _context.Card.FindAsync(id);
            if (card == null)
            {
                return null;
            }

            _context.Card.Remove(card);
            await _context.SaveChangesAsync();

            return card;
        }

        public bool CardExists(int id)
        {
            return _context.Card.Any(e => e.Id == id);
        }
    }
}

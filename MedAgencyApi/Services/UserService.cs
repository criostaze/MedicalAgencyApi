using MedAgencyApi.Data;
using MedAgencyApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedAgencyApi.Services
{
	public class UserService
	{
		private readonly MedAgencyApiContext _context;

		public UserService(MedAgencyApiContext context)
		{
			_context = context;
		}

        public async Task<IEnumerable<User>> GetUser()
        {
            return await _context.User.ToListAsync();
        }


        public async Task<User> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            return user;
        }


        public async void PutUser(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }

            return;
        }


        public async Task<User> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }


        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }


    }
}

using DAL.DataContext;
using DAL.Entites;
using DAL.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.implementation
{
    public class EmailRepo_DAL : IEmailRepo_DAL
    {
        private readonly DatabaseContext _context;

        public EmailRepo_DAL(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<Email>> GetAll()
        {
            try
            {
                var result = await _context.Emails.ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Email> GetEmail(int id)
        {
            try
            {
                var result = await _context.Emails.FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> New(Email email)
        {
            try
            {
                await _context.Emails.AddAsync(email);
                bool result = await _context.SaveChangesAsync() > 0;
                return result;

            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}

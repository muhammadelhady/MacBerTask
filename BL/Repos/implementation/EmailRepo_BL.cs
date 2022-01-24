using BL.Repos.Interfaces;
using DAL.Entites;
using DAL.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repos.implementation
{
    public class EmailRepo_BL : IEmailRepo_BL
    {
        private readonly IEmailRepo_DAL _emailRepo_DAL;

        public EmailRepo_BL(IEmailRepo_DAL emailRepo_DAL)
        {
            _emailRepo_DAL = emailRepo_DAL;
        }
        public async Task<List<Email>> GetAll()
        {
            try
            {
                var result = await _emailRepo_DAL.GetAll();
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
                var result = await _emailRepo_DAL.GetEmail(id);
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
                string subject = email.Subject;
                string message = email.Message;

                if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))
                    return false; 

                email.CreatedAt = DateTime.UtcNow;
                email.ModifiedAt = DateTime.UtcNow;

                bool result = await _emailRepo_DAL.New(email);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

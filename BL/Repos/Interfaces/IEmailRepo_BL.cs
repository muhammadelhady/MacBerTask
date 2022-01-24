using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repos.Interfaces
{
    public interface IEmailRepo_BL
    {
        public Task<bool> New(Email email);
        public Task<List<Email>> GetAll();
        public Task<Email> GetEmail(int id);

    }
}

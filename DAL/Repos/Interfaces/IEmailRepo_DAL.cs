using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Interfaces
{
    public interface IEmailRepo_DAL
    {
        public Task<bool> New(Email email);
        public Task<List<Email>> GetAll();
        public Task<Email> GetEmail(int id);

    }
}

using CRUD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Project.DAL.Repositories
{
    public class ContactRepository : IGenericRepository<Contact>
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Contact>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(Contact model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Contact model)
        {
            throw new NotImplementedException();
        }
    }
}

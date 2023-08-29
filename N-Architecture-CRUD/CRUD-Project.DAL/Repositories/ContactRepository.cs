using CRUD_Project.DAL.DataContext;
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
        private readonly DBCRUDTESTContext _dbcontext;

        public ContactRepository(DBCRUDTESTContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Delete(int id)
        {
            Contact model = _dbcontext.Contacts.First(c => c.ContactId == id);
            _dbcontext.Contacts.Remove(model);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<Contact> Get(int id)
        {
            return await _dbcontext.Contacts.FindAsync(id);
        }

        public async Task<IQueryable<Contact>> GetAll()
        {
            IQueryable<Contact> queryContactSQL = _dbcontext.Contacts;
            return queryContactSQL;
        }

        public async Task<bool> Insert(Contact model)
        {
            _dbcontext.Contacts.Add(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Contact model)
        {
            _dbcontext.Update(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}

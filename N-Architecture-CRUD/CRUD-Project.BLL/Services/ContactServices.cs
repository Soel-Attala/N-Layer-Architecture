using CRUD_Project.DAL.Repositories;
using CRUD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Project.BLL.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IGenericRepository<Contact> _contactRepo;
        public ContactServices(IGenericRepository<Contact> contactRepo)
        {
            _contactRepo = contactRepo;
        }

        //ahora tenemos conexion con la interfaz de IGenericRepositories, y podemos acceder a sus metodos

        public async Task<bool> Delete(int id)
        {
            return await _contactRepo.Delete(id);
        }

        public async Task<Contact> Get(int id)
        {
            return await _contactRepo.Get(id);
        }

        public async Task<IQueryable<Contact>> GetAll()
        {
            return await _contactRepo.GetAll();
        }

        public async Task<Contact> GetByName(string contactName)
        {
            IQueryable<Contact> queryContactSQL = await _contactRepo.GetAll();
            Contact contact = queryContactSQL.Where(c => c.Name == contactName).FirstOrDefault();
            return contact;
        }

        public async Task<bool> Insert(Contact model)
        {
            return await _contactRepo.Insert(model);
        }

        public async Task<bool> Update(Contact model)
        {
            return await _contactRepo.Update(model);
        }
    }
}

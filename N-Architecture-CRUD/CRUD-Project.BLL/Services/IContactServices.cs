using CRUD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Project.BLL.Services
{
    public interface IContactServices
    {
        Task<bool> Insert(Contact model);
        Task<bool> Update(Contact model);
        Task<bool> Delete(int id);
        Task<Contact> Get(int id);
        Task<IQueryable<Contact>> GetAll();
        Task<Contact> GetByName(string contactName);
    }
}

/*
 * aqui usamos las operaciones basicas del generic que creamos en la capa de dal
 * pero, al ser un servicio podemos agregar mas metodos que necesitemos.
 * incluso podemos hacer un metodo que nos devuelva los inner joins si la tabla de contacto
 * se relaciona con otra tabla
 */


/*
 * Here we use the basic operations of the generic we created in the dal layer.
 * but, being a service, we can add more methods as we need them.
 * we can even make a method that will return the inner joins if the contact table
 * is related to another table
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Project.DAL.Repositories
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class  //definimos que t entity models es una clase
    {
        Task<bool> Insert(TEntityModel model);
        Task<bool> Update(TEntityModel model);
        Task<bool> Delete(int id);
        Task<TEntityModel> Get(int id);
        Task<IQueryable<TEntityModel>> GetAll();
        //cuando trabajamos con recurtsos de la base de datos es necesario usar IQueriable
        ////when working with database resources it is necessary to use IQueriable
    }
}

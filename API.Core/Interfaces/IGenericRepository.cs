using API.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
   public interface IGenericRepository<T> where T:BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        // IReadOnlyList yazarak performanstan kazanç sağlamış oluyorum.Normalde ef bu listenin bir kopyasını alır ve bir değişiklik yapıldığında ikisini karşılaştırır.
        Task<IReadOnlyList<T>> ListAllAsync();
    }
}

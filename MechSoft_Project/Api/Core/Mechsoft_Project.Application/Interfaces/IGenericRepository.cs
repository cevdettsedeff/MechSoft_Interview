using Mechsoft_Project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        // Ekleme İşlemleri
        Task<bool> AddAsync(TEntity model);
        Task<bool> AddRangeAsync(List<TEntity> models);


        // Silme İşlemleri
        bool Remove(TEntity model); 
        bool RemoveRange(List<TEntity> models); // Birden fazla veriyi silmek için Range kullanırız.
        Task<bool> RemoveAsync(int id);
        // Ekleme, silme gibi işlemler başarılı olduğunda bize true değer döndürecektir.


        // Güncelleme İşlemleri
        bool Update(TEntity model);
        Task<int> SaveAsync(); //Kaydetme işlemi için gereklidir.


        // Listeleme İşlemleri
        IQueryable<TEntity> GetAll(bool tracking = true); //list kullanırsak(IEnumerable) memory'yi kullanır. Best practices açısından IQueryable kullanılır. Ayrıca tracking işlemini daha sonra kapatmak için tracking parametresi oluşturuyoruz.
        Task<TEntity> GetByIdAsync(int id, bool tracking = true); //id'ye göre getirme işlemi yapıyoruz. Ayrıca tracking işlemini daha sonra kapatmak için tracking parametresi oluşturuyoruz.
        // Buraya ayrıca şartlı listeleme'de eklenebilir. Fakat bu projede gerekli olmadığı için eklemedim.
    }
}

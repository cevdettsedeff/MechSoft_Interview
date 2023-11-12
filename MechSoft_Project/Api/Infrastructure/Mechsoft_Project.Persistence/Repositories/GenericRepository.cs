using Mechsoft_Project.Application.Interfaces;
using Mechsoft_Project.Domain.Models;
using Mechsoft_Project.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
         readonly MeetingDbContext _context;

        public DbSet<TEntity> Table => _context.Set<TEntity>(); // Dbset TEntity türünde entity alacaktır. TEntity yerine hangi entity gelirse o entity'e ait tabloyu bizlere verecektir.

        public GenericRepository(MeetingDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(TEntity model)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added; // bu işlem sayesinde sonuç olarak true yada false dönecektir.
        }

        public async Task<bool> AddRangeAsync(List<TEntity> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public IQueryable<TEntity> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            //Burada tracking işlemini kapatarak gereksiz bir maliyetten kurtuluyoruz.
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<TEntity> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == id);
            //await query.FindAsync(Guid.Parse(id)); -> Burada bunu kullanamayız. Çünkü query de FindAsync metodu yoktur. Bu yüzden marker kullanarak baseEntity üzerinden bulma işlemini gerçekleştiririz.
        }

        public bool Remove(TEntity model)
        {
            EntityEntry entityEntry = Table.Remove(model); //Silme işlemi için bunu yapmamız yeterli.
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            TEntity model = await Table.FirstOrDefaultAsync(data => data.Id == id); // önce silinmesi için veriyi bulmamız gerekiyor.
            return Remove(model); // Kendi fonksiyonumuzu çağırıyoruz. (Daha profosyonelce)
        }

        public bool RemoveRange(List<TEntity> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public bool Update(TEntity model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified; // Güncelleme işleminin sonucu true yada false döner.
        }

    }
}


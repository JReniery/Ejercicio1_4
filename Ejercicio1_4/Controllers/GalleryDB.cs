using Ejercicio1_4.Models;
using Ejercicio1_4.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4.Controllers
{
    public class GalleryDB
    {
        readonly SQLiteAsyncConnection db;

        public GalleryDB(string dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);
            db.CreateTableAsync<Fotos>();
        }

        public Task<int> SavePhoto(Fotos foto)
        {
            if (foto.Id != 0)
            {
                return db.UpdateAsync(foto);
            }
            else
            {
                return db.InsertAsync(foto);
            }
        }

        public Task<List<Fotos>> GetPhotoList()
        {
            return db.Table<Fotos>().ToListAsync();
        }

        public Task<Fotos> GetPhoto(int pId)
        {
            return db.Table<Fotos>()
                .Where(i => i.Id == pId)
                .FirstOrDefaultAsync();
        }

        public Task<int> DeletePhoto(Fotos foto)
        {
            return db.DeleteAsync(foto);
        }
    }
}

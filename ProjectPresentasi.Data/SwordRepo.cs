using Microsoft.EntityFrameworkCore;
using ProjectPresentasi.Data.Interfaces;
using ProjectPresentasi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPresentasi.Data
{
    public class SwordRepo : ISword
    {
        private readonly AppDbContext _context;
        public SwordRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteSword = await GetById(id);
                _context.Swords.Remove(deleteSword);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Sword>> GetAll()
        {
            var result = await _context.Swords.OrderBy(sw => sw.Name).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Sword> GetById(int id)
        {
            var result = await _context.Swords.FirstOrDefaultAsync(sw => sw.Id == id);
            if (result == null) throw new Exception($"Data Pedang dengan Id: {id} tidak ditemukan");
            return result;
        }

        public async Task<Sword> Insert(Sword obj) // add sword saja
        {
            try
            {
                _context.Swords.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public async Task<Sword> InsertSwordWithElement(Sword sword, Element element)
        //{
        //    try
        //    {
        //        var newSword = new Sword
        //        {
        //            // Id = sword.Id,
        //            Name = sword.Name,
        //            Elements = new List<Element>
        //            {
        //                new Element {ElementName = element.ElementName }
        //            }
        //        };

        //        _context.Swords.Add(newSword);
        //        await _context.SaveChangesAsync();
        //        return newSword;
        //    }
        //    catch (DbUpdateConcurrencyException dbEx)
        //    {
        //        throw new Exception(dbEx.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<Sword> Update(int id, Sword obj)
        {
            try
            {
                var updateSword = await GetById(id);

                updateSword.Name = obj.Name;
                await _context.SaveChangesAsync();
                return updateSword;
            }
            catch (DbUpdateConcurrencyException dbEx)
            {
                throw new Exception(dbEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

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
    public class SamuraiRepo : ISamurai
    {
        private readonly AppDbContext _context;
        public SamuraiRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteSamurai = await GetById(id);
                _context.Samurais.Remove(deleteSamurai);
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

        public async Task<IEnumerable<Samurai>> GetAll()
        {
            var result = await _context.Samurais.OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Samurai> GetById(int id)
        {
            var result = await _context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Samurai dengan Id: {id} tidak ditemukan");
            return result;
        }

        public async Task<Samurai> Insert(Samurai obj)
        {
            try
            {
                _context.Samurais.Add(obj);
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

        public async Task<List<Samurai>> Insertlist(List<Samurai> obj)
        {
            try
            {
                _context.Samurais.AddRange(obj);
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
        public async Task<Samurai> Update(int id, Samurai obj)
        {
            try
            {
                var updateSamurai = await GetById(id);

                updateSamurai.Name = obj.Name;
                await _context.SaveChangesAsync();
                return updateSamurai;
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


        //public async Task<Samurai> CreateSamuraiWithSwords(Samurai obj, Sword sword)
        //{
        //    try
        //    {
        //        //var newSamurai = _context.Samurais.Add(obj);



        //        var newSamurai = new Samurai
        //        {
        //            // Id = samurai.Id,
        //            Name = obj.Name,
        //            Swords = new List<Sword>
        //            {
        //               new Sword {Name = obj.Name, ProductionYear = sword.ProductionYear,
        //                            Weight = sword.Weight}
        //            }
        //        };

        //        _context.Samurais.Add(newSamurai);
        //        await _context.SaveChangesAsync();
        //        return newSamurai;
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

        public async Task<Samurai> GetSamuraiWithSwordById(int id)
        {
            var result = await _context.Samurais.Include(s => s.Swords).FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Samurai dengan Id: {id} tidak ditemukan");
            return result;
        }

        public async Task<Samurai> GetSamuraiWithSwordAndElementById(int id)
        {
            var result = await _context.Samurais.Include(s => s.Swords)
                .ThenInclude(sw => sw.Elements).FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Samurai dengan Id: {id} tidak ditemukan");
            return result;
        }
    }
}

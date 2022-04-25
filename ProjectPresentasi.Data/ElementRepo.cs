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
    public class ElementRepo : IElement
    {
        private readonly AppDbContext _context;
        public ElementRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteElement = await GetById(id);
                _context.Elements.Remove(deleteElement);
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

        public async Task<IEnumerable<Element>> GetAll()
        {
            var result = await _context.Elements.OrderBy(el => el.ElementName).AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<Element> GetById(int id)
        {
            var result = await _context.Elements.FirstOrDefaultAsync(el => el.Id == id);
            if (result == null) throw new Exception($"Data Elemen dengan Id: {id} tidak ditemukan");
            return result;
        }

        public async Task<Element> Insert(Element obj)
        {
            try
            {
                _context.Elements.Add(obj);
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

        public async Task<Element> Update(int id, Element obj)
        {
            try
            {
                var updateElement = await GetById(id);

                updateElement.ElementName = obj.ElementName;
                await _context.SaveChangesAsync();
                return updateElement;
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

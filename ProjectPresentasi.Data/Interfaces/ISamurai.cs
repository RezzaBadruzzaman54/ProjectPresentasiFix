using ProjectPresentasi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPresentasi.Data.Interfaces
{
    public interface ISamurai : ICRUD<Samurai>
    {
        //Task<Samurai> CreateSamuraiWithSwords(Samurai samurai, Sword sword);
        Task<Samurai> GetSamuraiWithSwordById(int id);
        Task<Samurai> GetSamuraiWithSwordAndElementById(int id);
    }
}

using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AutoMapper;
using DataModels.Database;
using DataModels.Response;
using ProductHelper.Database;

namespace ProductHelper.Services
{
    public interface IAilmentsService
    {
        Task<Ailment> GetById(int id);
        Task<List<AilmentResponse>> GetList();
    }

    public class AilmentsService : IAilmentsService
    {
        public AilmentsService()
        {
            
        }

        public async Task<Ailment> GetById(int id)
        {
            using (var db = new PhDbContext())
            {
                var ailment = await db.Ailments
                    .SingleOrDefaultAsync(p => p.Id == id);

                return ailment;
            }
        }

        public async Task<List<AilmentResponse>> GetList()
        {
            using (var db = new PhDbContext())
            {
                var ailments = await db.Ailments.ToListAsync();
                return Mapper.Map<List<AilmentResponse>>(ailments);
            }
        }
    }
}
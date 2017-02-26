using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using DataModels.Database;
using DataModels.Response;
using ProductHelper.Services;

namespace ProductHelper.Controllers.Api
{
    public class AilmentController : ApiController
    {
        private readonly IAilmentsService _ailmentsService;

        public AilmentController()
        {
            _ailmentsService = new AilmentsService();    
        }

        public Task<Ailment> Get(int id)
        {
            return _ailmentsService.GetById(id);
        }

        public Task<List<AilmentResponse>> Get()
        {
            return _ailmentsService.GetList();
        }
    }
}

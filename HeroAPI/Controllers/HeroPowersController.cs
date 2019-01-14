using HeroAPI.DbContextClass;
using HeroAPI.Messages;
using HeroAPI.Models;
using HeroAPI.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HeroAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HeroPowersController : ApiController
    {
        private ResourceManager _powerMessages = PowerMessages.ResourceManager;

        // GET: api/HeroPowers
        public async Task<IHttpActionResult> Get()
        {
            List<PowerInfo> result = new List<PowerInfo>();
            using (HeroDbContext context = new HeroDbContext())
            {
                var powers = await context.Powers.Where(h => true).ToListAsync();

                foreach (Power power in powers)
                {
                    await context.Entry(power).Collection(h => h.PowerDetails).LoadAsync();
                    result.Add(new PowerInfo(power));
                }
            }

            return Json(result);
        }

        // GET: api/HeroPowers/5
        public async Task<IHttpActionResult> Get(int id)
        {
            using (HeroDbContext context = new HeroDbContext())
            {
                Power power = await context.Powers.FirstOrDefaultAsync(p => p.PowerId == id);
                if (power != null)
                {
                    PowerInfo powerInfo = new PowerInfo(power);
                    return Json(powerInfo);
                }
            }

            return BadRequest(string.Format(GeneralMessages.NotFound, ModelNames.Power, _powerMessages.GetString("PowerId"), id));
        }

        // POST: api/HeroPowers
        public async Task<IHttpActionResult> Post([FromBody]PowerCreate power)
        {
            if (power == null || string.IsNullOrEmpty(power.PowerName) || string.IsNullOrWhiteSpace(power.PowerName))
                return BadRequest(string.Format(GeneralMessages.InvalidData, ModelNames.Power));

            using (HeroDbContext context = new HeroDbContext())
            {
                context.Powers.Add(new Power(power));
                await context.SaveChangesAsync();

                return Ok(new CMessage(string.Format(GeneralMessages.CreateSuccess, ModelNames.Power)));
            }
        }

        // PUT: api/HeroPowers/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]PowerCreate power)
        {
            if (power == null || string.IsNullOrEmpty(power.PowerName) || string.IsNullOrWhiteSpace(power.PowerName))
                return BadRequest(string.Format(GeneralMessages.InvalidData, ModelNames.Power));

            using (HeroDbContext context = new HeroDbContext())
            {
                Power findPower = await context.Powers.FirstOrDefaultAsync(p => p.PowerId == id);

                if (findPower == null)
                    return BadRequest(string.Format(GeneralMessages.NotFound, ModelNames.Power, _powerMessages.GetString("PowerId"), id));

                findPower.PowerName = power.PowerName;
                await context.SaveChangesAsync();

                return Ok(new CMessage(string.Format(GeneralMessages.UpdateSuccess, ModelNames.Power, _powerMessages.GetString("PowerId"), id)));
            }
        }

        // DELETE: api/HeroPowers/5
        public void Delete(int id)
        {
        }
    }
}

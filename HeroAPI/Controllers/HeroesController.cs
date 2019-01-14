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
    public class HeroesController : ApiController
    {
        private ResourceManager _heroMessages = HeroMessages.ResourceManager;

        // GET: api/Heroes
        public async Task<IHttpActionResult> Get()
        {
            List<HeroInfo> result = new List<HeroInfo>();
            using (HeroDbContext context = new HeroDbContext())
            {
                var heroes = await context.Heroes.Where(h => true).ToListAsync();

                foreach(Hero hero in heroes)
                {
                    await context.Entry(hero).Collection(h => h.PowerDetails).LoadAsync();
                    result.Add(new HeroInfo(hero));
                }
            }

            return Json(result);
        }

        // GET: api/Heroes/5
        public async Task<IHttpActionResult> Get(int id)
        {
            using (HeroDbContext context = new HeroDbContext())
            {
                Hero hero = await context.Heroes.FirstOrDefaultAsync(h => h.HeroId == id);
                if(hero != null)
                {
                    HeroInfo heroInfo = new HeroInfo(hero);
                    return Json(heroInfo);
                }
            }

            return BadRequest(string.Format(GeneralMessages.NotFound, ModelNames.Hero, _heroMessages.GetString("HeroId"), id));
        }

        // POST: api/Heroes
        public async Task<IHttpActionResult> Post([FromBody]HeroCreate hero)
        {
            if (hero == null || string.IsNullOrEmpty(hero.HeroName) || string.IsNullOrWhiteSpace(hero.HeroName))
                return BadRequest(string.Format(GeneralMessages.InvalidData, ModelNames.Hero));

            using (HeroDbContext context = new HeroDbContext())
            {
                context.Heroes.Add(new Hero(hero));
                await context.SaveChangesAsync();

                return Ok(new CMessage(string.Format(GeneralMessages.CreateSuccess, ModelNames.Hero)));
            }
        }

        // PUT: api/Heroes/5
        public async Task<IHttpActionResult> Put(int id, [FromBody]HeroCreate hero)
        {
            if (hero == null || string.IsNullOrEmpty(hero.HeroName) || string.IsNullOrWhiteSpace(hero.HeroName))
                return BadRequest(string.Format(GeneralMessages.InvalidData, ModelNames.Hero));

            using (HeroDbContext context = new HeroDbContext())
            {
                Hero findHero = await context.Heroes.FirstOrDefaultAsync(h => h.HeroId == id);

                if (findHero == null)
                    return BadRequest(string.Format(GeneralMessages.NotFound, ModelNames.Hero, _heroMessages.GetString("HeroId"), id));

                findHero.HeroName = hero.HeroName;
                await context.SaveChangesAsync();
                
                return Ok(new CMessage(string.Format(GeneralMessages.UpdateSuccess, ModelNames.Hero, _heroMessages.GetString("HeroId"), id)));
            }
        }

        // DELETE: api/Heroes/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            using (HeroDbContext context = new HeroDbContext())
            {
                Hero findHero = await context.Heroes.FirstOrDefaultAsync(h => h.HeroId == id);

                if (findHero == null)
                    return BadRequest(string.Format(GeneralMessages.NotFound, ModelNames.Hero, _heroMessages.GetString("HeroId"), id));

                context.Heroes.Remove(findHero);
                await context.SaveChangesAsync();

                return Ok(new CMessage(string.Format(GeneralMessages.DeleteSuccess, ModelNames.Hero, _heroMessages.GetString("HeroId"), id)));
            }
        }
    }
}

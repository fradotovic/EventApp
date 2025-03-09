## 1. Kreiraj bazni kontroler kojeg će svi drugi nasljeđivati

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
      


    }
}


## 2. zatim možeš kreirati kontrolere kao klasu i da nasljeđuju bazni kontroller

I da bi Dependency Injection instancirao to sve može se koristiti primary konstruktor


### public class ActivitiesController(AppDbContext context) : BaseApiController
{

}

## 3. Zatim možes početi slagati Http metode

-- Task<ActionResult> za dohvaćanje Http zahtjeva


        [HttpGet]

        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await context.Activities.ToListAsync();
        }
#### --za dohvaćanje svih

### best practice je raditi s async i await kada radimo s upitima u bazi podataka 

#### *** KADA KREIRAMO NOVI KONTROLLER POTREBNO JE RESETIRATI NAŠ API SERVER



### 4. Za dohvaćanje samo jednog zapisa entiteta


        [HttpGet("{id}")]  -->ovaj parametar id mora se isto zvati i u argumentu funkcije

        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            var activity = await context.Activities.FindAsync(id);

            if (activity == null) return NotFound();

            return activity;
           
        }

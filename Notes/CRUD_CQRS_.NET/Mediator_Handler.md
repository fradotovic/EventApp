## Da bi povezao API s Application da mogu izmjenjivat objekte

## 1. Treba instalirati nuget MediatR u Applicaton.csproj projekt

## 2. Iskoristit ćemo handlere ua naše use caseove u application layeru

## 3. U application projektu ćemo kreirati folder za svaki entitet posebno gjde će za njega biit querji i commande

-- Kreiras glavni folder Activities -> podfolder Queries -> i u njemu se kreira klasa GetActivityList 

-- u toj klasi zatim dodajes klasu unutar klase i nazivas je Query i ona nasljeđuje IRequest<List<Activity>> 

-- također imas i drugu klasu Handler koja nasljeđuje IRequestHandler i prima dva parametra Query i što vraća List<Activity>{}, ova
klasa pošto vučemo podatke iz baze ima i primary construktor (AppDbContext)

-- imas ctrl-i da implementiras taj task za handlera

----------------------------
public class GetActivityList
{

    public class Query : IRequest<List<Activity>> { }

    public class Handler(AppDbContext context): IRequestHandler<Query, List<Activity>>
    {
        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.Activities.ToListAsync(cancellationToken);

        }
    }
}
------------------------

### zatim odes u Activites kontroler u API projektu i tamo upotrijebis taj Mediator

--tamo u primary constructor dodas parametar IMediator mediator

public class ActivitiesController(AppDbContext context, IMediator mediator) : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await mediator.Send(new GetActivityList.Query());
    }
}



### zatim još treba otići u program.cs i registrirati ovo kao uslugu

builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>());

#### u mediatoru ne možeš koristiti notfound

---slicno je i dok radis da dobijes samo jedan activity 

### Handler Class
public class GetActivityDetail
{
    public class Query: IRequest<Activity> 
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
    {
        public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            var actitivity = await context.Activities.FindAsync([request.Id], cancellationToken);

            if (actitivity == null) throw new Exception("Activity not found");
           
            return actitivity;

        }
    }
}


### Kontroler clasa sa handlerima


    public class ActivitiesController(IMediator mediator) : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await mediator.Send(new GetActivityList.Query());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            return await mediator.Send(new GetActivityDetail.Query {Id=id});
           
        }
    }



### Thinning Controller na način da u BaseApiControlleru injectamo IMediator service koju ostali kontroleri kasnije nasljeđuju


    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {

        private IMediator? _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("IMediator service is unvailable");


    }

### Cancellation token se koristi ukoliko imamo query koji se dugo izvađa a korisnik u međuvremenu prekine zahtjev tj. napusti app



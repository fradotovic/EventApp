using DOMAIN;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Queries
{
    public class GetActivityDetail
    {
        public class Query: IRequest<Activity> 
        {
            public required string id { get; set; }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Query, Activity>
        {
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var actitivity = await context.Activities.FindAsync([request.id], cancellationToken);

                if (actitivity == null) throw new Exception("Activity not found");
               
                return actitivity;
            }
        }
    }
}

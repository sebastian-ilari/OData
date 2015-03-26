using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.ServiceModel.Web;
using MovieLibrary;

namespace OData.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ActorService : DataService<ActorProvider>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.UseVerboseErrors = true;
            
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.SetServiceOperationAccessRule("GetLameActors", ServiceOperationRights.All);
            config.SetServiceOperationAccessRule("GetActorsWithRating", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }

        [WebGet]
        //http://localhost:1606/Services/ActorService.svc/GetLameActors
        public IQueryable<Actor> GetLameActors()
        {
            return CurrentDataSource.Actors.Where(a => a.Rating < 5);
        }

        [WebGet]
        //http://localhost:1606/Services/ActorService.svc/GetActorsWithRating?rating='3'
        public IQueryable<Actor> GetActorsWithRating(string rating)
        {
            int intRating = int.Parse(rating);
            return CurrentDataSource.Actors.Where(a => a.Rating.Equals(intRating));
        }

        [QueryInterceptor("Actors")]
        public Expression<System.Func<Actor, bool>> FilterActors()
        {
            return a => a.Visible;
        }

        [ChangeInterceptor("Actors")]
        //Has to be called through Fiddler
        public void FilterFakeRatings(Actor actor, UpdateOperations operations)
        {
            if (operations.Equals(UpdateOperations.Add) && actor.Rating > 10)
            {
                throw new DataServiceException(500, "Rating must be lower than 10");
            }
        }
    }
}
namespace ValYou.Api.ServiceInterface
{
    using System.Collections.Generic;
    using System.Linq;

    using Akka.Actor;

    using ServiceStack;

    using ValYou.Api.Data;
    using ValYou.Api.Operation;
    using ValYou.Api.Response;

    [DefaultRequest(typeof(GetShapes))]
    public class ShapesService : Service
    {
        public object Get(GetShapes request)
        {
            var features = Global.ActorSystem.ActorSelection("/user/coord").Ask<IList<Shape>>("all").Result;
            return new ShapesResponse { features = features.Select(ToFeature).ToList() };
        }

        private static FeatureResponse ToFeature(Shape shape)
        {
            return new FeatureResponse(shape);
        }
    }
}
namespace ValYou.Api.ServiceInterface
{
    using ServiceStack;

    using ValYou.Api.Data;
    using ValYou.Api.Operation;

    [DefaultRequest(typeof(GetShapes))]
    public class ShapesService : Service
    {
        public IShapeRepository ShapeRepository { get; set; }

        public object Get(GetShapes request)
        {
            return this.ShapeRepository.Get();
        }
    }
}
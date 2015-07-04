namespace ValYou.Api.Data
{
    using System.Collections.Generic;

    using ValYou.Api.Data;

    public interface IShapeRepository
    {
        IList<Shape> Get();

        IList<Shape> Get(string type);
    }
}

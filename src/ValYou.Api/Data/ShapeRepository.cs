namespace ValYou.Api.Data
{
    using System.Collections.Generic;

    using ServiceStack.Data;
    using ServiceStack.OrmLite;

    public class ShapeRepository : IShapeRepository
    {
        public ShapeRepository(IDbConnectionFactory dbfFactory)
        {
            DbFactory = dbfFactory;
        }

        public IDbConnectionFactory DbFactory { get; private set; }

        public IList<Shape> Get()
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                return db.Select<Shape>();
            }
        }

        public IList<Shape> Get(string type)
        {
            using (var db = DbFactory.OpenDbConnection())
            {
                return db.Select<Shape>();
            }
        }
    }
}
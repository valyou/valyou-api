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
                return
                    db.Select<Shape>(
                        @"SELECT sa.gid, sa.objectid,
                              sa.sa2_main11, sa.sa2_5dig11, sa.sa2_name11,
                              sa.sa3_code11, sa.sa3_name11,
                              sa.sa4_code11, sa.sa4_name11,
                              sa.gcc_code11, sa.gcc_name11,
                              sa.ste_code11, sa.ste_name11,
                              sa.shape_leng, sa.shape_area,
                              ST_AsText(sa.geom) geom_text
                          FROM sa2_cutdown sa"
                    );
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
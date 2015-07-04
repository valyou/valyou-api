namespace ValYou.Api.Data
{
    using ServiceStack.DataAnnotations;

    [Alias("sa2_cutdown")]
    public class Shape
    {
        [Alias("gid")]
        public int GId { get; set; }

        [Alias("objectid")]
        public int ObjectId { get; set; }

        [Alias("sa2_main11")]
        public string Sa2Main11 { get; set; }

        [Alias("sa2_5dig11")]
        public string Sa25Dig11 { get; set; }

        [Alias("sa2_name11")]
        public string Sa2Name11 { get; set; }

        [Alias("sa3_code11")]
        public string Sa3Code11 { get; set; }

        [Alias("sa3_name11")]
        public string Sa3Name11 { get; set; }

        [Alias("sa4_code11")]
        public string Sa4Code11 { get; set; }

        [Alias("sa4_name11")]
        public string Sa4Name11 { get; set; }

        [Alias("gcc_code11")]
        public string GccCode11 { get; set; }

        [Alias("gcc_name11")]
        public string GccName11 { get; set; }

        [Alias("ste_code11")]
        public string SteCode11 { get; set; }

        [Alias("ste_name11")]
        public string SteName11 { get; set; }

        [Alias("shape_leng")]
        public float ShapeLeng { get; set; }

        [Alias("shape_area")]
        public float ShapeArea { get; set; }

        [Alias("geom")]
        [Ignore]
        public string Geometry { get; set; }

        [Alias("geom_text")]
        public string GeometryText { get; set; }
    }
}
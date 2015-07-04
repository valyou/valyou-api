namespace ValYou.Api.Response
{
    using System.Runtime.Serialization;

    using ValYou.Api.Data;

    public class FeatureResponse
    {
        public FeatureResponse(Shape shape)
        {
            this.properties =
                new FeatureResponseProperties
                    {
                        OBJECTID = shape.ObjectId,
                        SA2_MAIN11 = shape.Sa2Main11,
                        SA2_5DIG11 = shape.Sa25Dig11,
                        SA2_NAME11 = shape.Sa2Name11,
                        SA3_CODE11 = shape.Sa3Code11,
                        SA3_NAME11 = shape.Sa3Name11,
                        SA4_CODE11 = shape.Sa4Code11,
                        SA4_NAME11 = shape.Sa4Name11,
                        GCC_CODE11 = shape.GccCode11,
                        GCC_NAME11 = shape.GccName11,
                        STE_CODE11 = shape.SteCode11,
                        STE_NAME11 = shape.SteName11,
                        Shape_Leng = shape.ShapeLeng,
                        Shape_Area = shape.ShapeArea
                    };

            this.geometry = new FeatureResponseGeometry();
            this.see = shape.GeometryText;
        }

        [DataMember]
        public string type { get { return "Feature"; } }

        [DataMember]
        public FeatureResponseProperties properties { get; set; }

        [DataMember]
        public FeatureResponseGeometry geometry { get; set; }

        [DataMember]
        public string see { get; set; }
    }

    public class FeatureResponseProperties
    {
        [DataMember]
        public int OBJECTID { get; set; }

        [DataMember]
        public string SA2_MAIN11 { get; set; }

        [DataMember]
        public string SA2_5DIG11 { get; set; }

        [DataMember]
        public string SA2_NAME11 { get; set; }

        [DataMember]
        public string SA3_CODE11 { get; set; }

        [DataMember]
        public string SA3_NAME11 { get; set; }

        [DataMember]
        public string SA4_CODE11 { get; set; }

        [DataMember]
        public string SA4_NAME11 { get; set; }

        [DataMember]
        public string GCC_CODE11 { get; set; }

        [DataMember]
        public string GCC_NAME11 { get; set; }

        [DataMember]
        public string STE_CODE11 { get; set; }

        [DataMember]
        public string STE_NAME11 { get; set; }

        [DataMember]
        public float Shape_Leng { get; set; }

        [DataMember]
        public float Shape_Area { get; set; }
    }

    public class FeatureResponseGeometry
    {
        public FeatureResponseGeometry()
        {
            this.coordinates = new [] { new [] { new [] { new [] { 115.182, -34.425 } } } };
        }

        [DataMember]
        public string type { get { return "MultiPolygon"; } }

        [DataMember]
        public double[][][][] coordinates { get; set; }
    }
}
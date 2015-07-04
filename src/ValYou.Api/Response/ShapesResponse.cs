namespace ValYou.Api.Response
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "Shape")]
    public class ShapesResponse
    {
        [DataMember]
        public string type { get { return "FeatureCollection"; } }

        [DataMember]
        public Crs crs { get { return new Crs(); } }

        [DataMember]
        public IList<FeatureResponse> features { get; set; }
    }

    public class Crs
    {
        [DataMember]
        public string type { get { return "name"; } }

        [DataMember]
        public CrsProperties properties { get {  return new CrsProperties(); } }
    }

    public class CrsProperties
    {
        [DataMember]
        public string name { get { return "urn:ogc:def:crs:EPSG::4283"; } }
    }
}
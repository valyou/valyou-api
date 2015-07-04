namespace ValYou.Api.Response
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using ValYou.Api.Data;

    [DataContract(Name = "Shape")]
    public class ShapesResponse
    {
        [DataMember(Name = "type")]
        public string Type { get { return "FeatureCollection"; } }

        [DataMember(Name = "crs")]
        public Crs Crs { get { return new Crs(); } }
        
        [DataMember(Name = "features")]
        public IList<Shape> Features { get; set; }
    }

    public class Crs
    {
        [DataMember(Name = "type")]
        public string Type { get { return "name"; } }

        [DataMember(Name = "properties")]
        public CrsProperties Properties { get {  return new CrsProperties(); } }
    }

    public class CrsProperties
    {
        [DataMember(Name = "name")]
        public string Name { get { return "urn:ogc:def:crs:EPSG::4283"; } }
    }
}
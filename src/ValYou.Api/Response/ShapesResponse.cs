namespace ValYou.Api.Response
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Shape")]
    public class ShapesResponse
    {
        [DataMember]
        public string Name { get; set; }
    }
}
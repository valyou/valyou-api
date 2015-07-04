namespace ValYou.Api.Operation
{
    using System.Runtime.Serialization;

    using ServiceStack;

    using ValYou.Api.Request;
    using ValYou.Api.Response;

    [Api("Get the weighted GeoJSON records.")]
    [DataContract]
    [Route("/shapes", "GET", Summary = @"Get the weighted GeoJSON records.")]
    public class GetShapes : IGetShapes, IReturn<ShapesResponse>
    {
        [ApiMember(Name = "Ecology",
            AllowMultiple = false,
            DataType = "int",
            IsRequired = false,
            Description = "Ecology weighting.",
            ParameterType = "query")]
        [DataMember]
        public int Ecology { get; set; }
    }
}
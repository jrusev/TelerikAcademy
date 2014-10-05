namespace SubstringCounter.Service
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ISubstringCounter
    {
        [OperationContract]
        int GetOccurrences(string toBeMatched, string toCountFrom);
    }
}

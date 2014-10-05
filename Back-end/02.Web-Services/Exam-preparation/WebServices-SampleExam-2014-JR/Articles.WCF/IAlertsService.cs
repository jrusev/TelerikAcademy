namespace Articles.WCF
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using Articles.WCF.DataModels;

    [ServiceContract]
    public interface IAlertsService
    {
        [OperationContract]
        [WebGet(UriTemplate = "api/alerts")]
        IEnumerable<AlertDataModel> GetAlerts();
    }
}

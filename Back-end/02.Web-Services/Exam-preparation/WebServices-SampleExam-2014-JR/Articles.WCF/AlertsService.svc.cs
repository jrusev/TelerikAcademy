namespace Articles.WCF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Articles.Data;
    using Articles.WCF.DataModels;

    // You can test the service by selecting the .svc file and pressing F5,
    // this will open the WCF Test Client (invoke GetAlerts)
    public class AlertsService : IAlertsService
    {
        private AlertsData data;

        public AlertsService()
        {
            this.data = new AlertsData(ArticlesDbContext.Create());
        }

        public IEnumerable<AlertDataModel> GetAlerts()
        {
            var alerts = this.data.Alerts.All()
                .Where(a => a.ExpirationDate > DateTime.Now)
                .OrderBy(a => a.ExpirationDate)
                .Select(AlertDataModel.FromAlert).ToList();

            return alerts;
        }
    }
}

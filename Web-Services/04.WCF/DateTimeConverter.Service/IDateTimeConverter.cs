namespace DateTimeConverter.Service
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDateTimeConverter
    {
        [OperationContract]
        string GetDayOfWeek(DateTime date);
    }
}

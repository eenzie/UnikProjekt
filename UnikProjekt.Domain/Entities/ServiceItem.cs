using System.ComponentModel.DataAnnotations;
using UnikProjekt.Domain.Shared;

namespace UnikProjekt.Domain.Entities
{
    public class ServiceItem : Entity
    {
        internal ServiceItem() : base(Guid.NewGuid())
        {
        }

        public ServiceItem(Guid id, string serviceName, string serviceType,
            int serviceInterval, DateTime openTime, DateTime closeTime) : base(id)
        {
            ServiceName = serviceName;
            ServiceType = serviceType;
            ServiceInterval = serviceInterval;
            OpenTime = openTime;
            CloseTime = closeTime;
        }

        public string ServiceName { get; private set; }
        public string ServiceType { get; private set; }
        public int ServiceInterval { get; private set; }
        public DateTime OpenTime { get; private set; }
        public DateTime CloseTime { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; protected set; } = [];
    }
}

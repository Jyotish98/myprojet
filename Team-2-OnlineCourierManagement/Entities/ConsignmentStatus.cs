using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team_2_OnlineCourierManagement.Entities
{
    //Different Status for a Consignment
    public enum ConsignmentStatus
    {
        Booked,
        Dispatched,
        InTransit,
        Atdestination,
        Outfordelivery,
        Delivered,
        Cancelled
    }
}


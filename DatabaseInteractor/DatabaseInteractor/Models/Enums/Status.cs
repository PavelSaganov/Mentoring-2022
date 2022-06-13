using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseInteractor.Models.Enums
{
    public enum Status
    {
        NotStarted,
        Loading,
        InProgress,
        Arrived,
        Unloading,
        Cancelled,
        Done
    }
}

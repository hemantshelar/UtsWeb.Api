using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtsWebApi.Models;
using UtsWebApi.Models.RequestResponse;

namespace UtsWebApi.Interfaces
{
    public interface IStaffService
    {
        StaffServiceFindResponse Find(StaffServiceFindRequest findRequest);
        StaffServiceFindResponse Get(int id);
        void Update(Employee updated);
        Task LikeReceived(int employeeId);
    }
}

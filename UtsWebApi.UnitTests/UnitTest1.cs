using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtsWebApi.Interfaces;
using UtsWebApi.Models.RequestResponse;
using UtsWebApi.Services;

namespace UtsWebApi.UnitTests
{
    [TestClass]
    public class UnitTestStaffService
    {
        IStaffService _service = null;
        
        [TestInitialize]
        public void Init()
        {
            _service = new StaffServiceJsonImpl();
            ((StaffServiceJsonImpl)_service).Init();

        }
        [TestMethod]
        public void it_should_return_one_record_for_search_operation()
        {
            StaffServiceFindRequest req = new StaffServiceFindRequest();
            req.FirstName = "John";
            req.LastName = "Smith";
            var result = _service.Find(req);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void it_should_increment_like_count()
        {

            var employee = _service.Get(1);
            int oldLikeCount = employee.Employee.Likes;

            _service.LikeReceived(1).Wait();
            var updatedEmployeee = _service.Get(1);
            int newLikeCount = updatedEmployeee.Employee.Likes;
            Assert.AreEqual(oldLikeCount, newLikeCount - 1);
        }
    }
}

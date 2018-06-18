using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtsWebApi.Interfaces;
using UtsWebApi.Models;
using Newtonsoft.Json;
using System.IO;
using UtsWebApi.Models.RequestResponse;

namespace UtsWebApi.Services
{
    public class StaffServiceJsonImpl : IStaffService
    {
        public const string fileName = "db.json";

        public List<Employee> _db = new List<Employee>();

        public StaffServiceJsonImpl()
        {
            this.Init();
        }

        public async Task SaveAsync()
        {
            if ( File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (var db = File.Open(fileName, FileMode.CreateNew))
            {

                var json = JsonConvert.SerializeObject(_db);
                StreamWriter sw = new StreamWriter(db);
                await sw.WriteAsync(json);
                sw.Close();
            }

        }

        public void Init()
        {
            using (var db = File.Open(fileName, FileMode.Open))
            {
                StreamReader sr = new StreamReader(db);
                var jsonData = sr.ReadToEnd();
                _db = JsonConvert.DeserializeObject<List<Employee>>(jsonData);
                sr.Close();
            }
        }

        public Employee Find(string searchTerm)
        {
            Employee result = null;
            try
            {
               
                
                //Employee e = new Employee();
                //e.ContactInfo = new ContactInfo();
                //e.ContactInfo.CellPhone = "cell phone";
                //e.ContactInfo.Email = "email";
                //e.ContactInfo.OfficePhone = "officephone";
                //e.Id = 1;
                //e.FirstName = "first name";
                //e.LastName = "last name";
                //e.Likes = 10;
                //e.ManagerId = 1;
                //e.Designation = "CEO";


                //string obj = JsonConvert.SerializeObject(e);
                //if ( File.Exists(fileName) == true )
                //{
                //    File.Delete(fileName);
                //}
                //var fs = File.Open(fileName, FileMode.CreateNew);
                //StreamWriter sw = new StreamWriter(fs);
                //sw.Write(obj);
                //sw.Close();
                //fs.Close();


            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public void Update(Employee updated)
        {
            throw new NotImplementedException();
        }

        public StaffServiceFindResponse Find(StaffServiceFindRequest findRequest)
        {
            StaffServiceFindResponse result = new StaffServiceFindResponse();
            var employee = _db.Where(e => e.FirstName == findRequest.FirstName || e.LastName == findRequest.LastName).FirstOrDefault();

            result = this.Get(Int32.Parse(employee.Id.ToString()));

            return result;
        }

        public StaffServiceFindResponse Get(int id)
        {
            StaffServiceFindResponse result = new StaffServiceFindResponse();
            var employee = _db.Where(e => e.Id == id).FirstOrDefault();

            result.Employee = employee;

            var manager = _db.Where(e => e.Id == employee.ManagerId).FirstOrDefault();
            result.Manager = manager;

            var directReports = _db.Where(e => e.ManagerId == employee.Id).ToList();
            result.DirectReports = directReports;

            return result;
        }
        public async Task LikeReceived(int employeeId)
        {
            var employee = this._db.Where(e => e.Id == employeeId).FirstOrDefault();
            employee.Likes++;
            await this.SaveAsync();
        }
       
    }
}

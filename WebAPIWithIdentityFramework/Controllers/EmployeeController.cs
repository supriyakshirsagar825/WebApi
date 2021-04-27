using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIWithIdentityFramework.Models;

namespace WebAPIWithIdentityFramework.Controllers
{
    [Authorize]
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult /*IEnumerable<DBEmployee>*/ Get()
        {
            using (WEBAPIDATABASEEntities db = new WEBAPIDATABASEEntities())
            {
                // return db.DBEmployees.ToList();
                return Ok(db.DBEmployees.ToList()); //Request.CreateResponse(HttpStatusCode.OK, db.DBEmployees.ToList());
            }

        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(DBEmployee employee)
        {
            using (WEBAPIDATABASEEntities db = new WEBAPIDATABASEEntities())
            {
                db.DBEmployees.Add(employee);
                db.SaveChanges();
            }

            return Created(new Uri(Url.Link("GetEmployeeByID", new { Id = employee.Id })),employee);//Request.CreateResponse(HttpStatusCode.Created, employee.Id);
           // response.Headers.Location = new Uri(Url.Link("GetEmployeeByID",new { Id = employee.Id })); //new Uri(Request.RequestUri + "" + employee.Id.ToString());
          //  return response;
        }
        [HttpGet]
        [Route("{id:int:min(1):max(10000)}",Name ="GetEmployeeByID")]
        public IHttpActionResult Get(int Id)
        {
            using (WEBAPIDATABASEEntities db = new WEBAPIDATABASEEntities())
            {
                // return db.DBEmployees.ToList();
                return Ok(db.DBEmployees.FirstOrDefault(x => x.Id == Id)); //Request.CreateResponse(HttpStatusCode.OK, db.DBEmployees.FirstOrDefault(x=>x.Id==Id));
            }

        }
        [HttpGet]
        [Route("{name:alpha}")]
        public IHttpActionResult Get(string name)
        {
            using (WEBAPIDATABASEEntities db = new WEBAPIDATABASEEntities())
            {
                // return db.DBEmployees.ToList();
                return Ok(db.DBEmployees.FirstOrDefault(x => x.FirstName == name)); //Request.CreateResponse(HttpStatusCode.OK, db.DBEmployees.FirstOrDefault(x => x.FirstName == name));
            }

        }

        [Route("{id}/courses")]
        public IEnumerable<string> GetCourses(int id)
        {
            if(id==1)
            {
                return new List<string>() { "c#", "ASp", "EF" };
            }
            else
            {
                return new List<string>() { "c", "c++", "css" };

            }
        }
        [HttpGet]
        [Route("~/api/person")]
        public IEnumerable<person> GetPerson()
        {
            List<person> personlist = new List<person>()
            {
                new person{id=1,name="abc"},
                new person{id=2,name="xyz"}
            };
            return personlist;
           
        }


    }
}

using API_CRUD_FINAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_CRUD_FINAL.Controllers
{
	
	public class ApiFinalController : ApiController
    {
		public api_crud_final_dbEntities ob = new api_crud_final_dbEntities();
		[HttpGet]
		public IHttpActionResult getemp()
		{
			List<apitbl> data = ob.apitbls.ToList();
			return Ok(data);
		}

		[HttpPost]
		public IHttpActionResult empcreate(apitbl emp)
		{
			ob.apitbls.Add(emp);
			ob.SaveChanges();
			return Ok();
		}

		[HttpGet]
		public IHttpActionResult empretrv(int id)
		{
			var ret = ob.apitbls.Where(model => model.id == id).FirstOrDefault();
			ob.SaveChanges();
			return Ok(ret);
		}

		[HttpPut]
		public IHttpActionResult empedit(apitbl eestore)
		{
			ob.Entry(eestore).State= System.Data.Entity.EntityState.Modified;
			ob.SaveChanges();
			return Ok();
		}

		[HttpDelete]
		public IHttpActionResult empdel(int id)
		{
			var empdelt = ob.apitbls.Where(model => model.id==id).FirstOrDefault();
			ob.Entry(empdelt).State = System.Data.Entity.EntityState.Deleted;
			ob.SaveChanges();
			return Ok();
		}
	}
}

using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employee.Controllers
{
    [RoutePrefix("Api/Employee")]
    public class EmployeeAPIController : ApiController
    {
        EmployeeDBEntities objEntity = new EmployeeDBEntities();

        [HttpPost]
        [Route("InsertEmployee")]
        public IHttpActionResult InsertEmployee(EmployeeDetail employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            try
            {
                int lastId = objEntity.EmployeeDetail.ToList<EmployeeDetail>().Last().Id;
                employee.Id =lastId +1;

                objEntity.EmployeeDetail.Add(employee);
                objEntity.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            return Ok(employee);
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public IHttpActionResult UpdateEmployee(EmployeeDetail employee)
        {
            if (ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            try
            {
                objEntity.EmployeeDetail.Add(employee);
                objEntity.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(employee);
        }



        [HttpGet]
        [Route("GetEmployees")]
        public IQueryable<EmployeeDetail> GetEmaployee()
        {
            try
            {
                return objEntity.EmployeeDetail;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public IQueryable<EmployeeDetail> GetEmployeeById(int id)
        {
            try
            { var employee= objEntity.EmployeeDetail.Where(e => e.Id == id);
                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}

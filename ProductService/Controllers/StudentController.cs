using Microsoft.AspNet.OData;
using ProductService.Models;
using ProductService.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProductService.Controllers
{
    public class StudentController : ODataController
    {
        SchoolContext db = new SchoolContext();
        private bool ProductExists(int key)
        {
            return db.Students.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<Student> Get()
        {
            return db.Students;
        }
        [EnableQuery]
        public SingleResult<Student> Get([FromODataUri] int key)
        {
            IQueryable<Student> result = db.Students.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return Created(student);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Student> student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Students.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            student.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Student update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var student = await db.Students.FindAsync(key);
            if (student == null)
            {
                return NotFound();
            }
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
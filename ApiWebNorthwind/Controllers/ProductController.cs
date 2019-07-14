using ConectData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiWebNorthwind.Controllers
{
    public class ProductController : ApiController
    {
        private ProductsEntities dbContext = new ProductsEntities();
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            using (ProductsEntities productsEntities = new ProductsEntities())
            {
                return productsEntities.Products.ToList();
            }
        }
        [HttpGet]
        public Product Get(int id)
        {
            using (ProductsEntities productsEntities = new ProductsEntities())
            {
                return productsEntities.Products.FirstOrDefault(e => e.ProductID == id);
            }
        }

        [HttpPost]
        public IHttpActionResult CreateProduct([FromBody]Product us)
        {
            if (ModelState.IsValid)
            {
                dbContext.Products.Add(us);
                dbContext.SaveChanges();
                return Ok(us);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IHttpActionResult UpdateEmployee(int id, [FromBody]Product us)
        {
            if (ModelState.IsValid)
            {
                var UserExist = dbContext.Products.Count(c => c.ProductID == id) > 0;
                if (UserExist)
                {
                    dbContext.Entry(us).State = EntityState.Modified;
                    dbContext.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }


        }

        [HttpDelete]
        public IHttpActionResult DeliteProdu(int id)
        {
            var emp = dbContext.Products.Find(id);
            if (emp != null)
            {
                dbContext.Products.Remove(emp);
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


    }
}

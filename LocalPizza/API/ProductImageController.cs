using LocalPizza.Core;
using LocalPizza.Core.Menu;
using LocalPizza.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LocalPizza.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IWebHostEnvironment webHost;
        private readonly IDataAccess dataAccess;

        public ProductImageController(IWebHostEnvironment webHost, IDataAccess dataAccess)
        {
            this.webHost = webHost;
            this.dataAccess = dataAccess;
        }
        [HttpGet]
        public async Task<ActionResult> GetNothing()
        {
            return NoContent();
        }
        // POST: api/ProductImage
        [HttpPost]
        public async Task<ActionResult> PostImage([FromBody]IFormFile image,[FromQuery]int id, [FromQuery]ProductRange range)
        {
            //if (image != null)
            {
                string folder = Path.Combine(webHost.WebRootPath, "images");
                //string fileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                //string filePath = Path.Combine(folder, fileName);
                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    image.CopyTo(fileStream);
                //}
                //var product = dataAccess.ProductImage(id, range, fileName);
                //return CreatedAtAction("PostImage", fileName);
            }

            
            return NoContent();
        }
    }
}

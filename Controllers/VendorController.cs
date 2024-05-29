using System.Web.Http;
using VendorsWebService.Models;

namespace VendorsWebService.Controllers
{
    public class VendorController : ApiController
    {
        private readonly IVendorLoader _vendorLoader;
        public VendorController()
        {
        }
        public VendorController(IVendorLoader vendorLoader)
        {
            _vendorLoader = vendorLoader;
        }

        [HttpGet]
        public IHttpActionResult LoadVendor(string id)
        {
            var vendor = _vendorLoader.LoadVendor(id);
            if (vendor == null)
            {
                return NotFound();
            }
            return Ok(vendor);
        }

        [HttpGet]
        public IHttpActionResult LoadVendors()
        {
            return Ok(_vendorLoader.LoadVendors());
        }

        [HttpPut]
        public IHttpActionResult UpdateVendor(string id, Vendor vendor)
        {
            if (id != vendor.Id)
            {
                return BadRequest("ID mismatch");
            }
            var existingVendor = _vendorLoader.LoadVendor(id);

            if (existingVendor == null)
            {
                return NotFound();
            }
            _vendorLoader.UpdateVendor(vendor);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var vendor = _vendorLoader.LoadVendor(id);
            if (vendor == null)
            {
                return NotFound();
            }
            _vendorLoader.DeleteVendor(id);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}
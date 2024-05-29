using FileLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorsWebService.Models;

namespace VendorsWebService
{
    public interface IVendorLoader
    {
        Vendor LoadVendor(string id);
        IEnumerable<Vendor> LoadVendors();
        void InsertVendor(Vendor vendor);
        void UpdateVendor(Vendor vendor);
        void DeleteVendor(string id);

    }
}

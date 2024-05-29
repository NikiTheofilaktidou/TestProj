using FileLoader;
using System.Collections.Generic;
using System.Linq;
using VendorsWebService.Models;

namespace VendorsWebService
{
    public class SupplierLoaderAdapter : IVendorLoader
    {
        private readonly Loader _supplierLoader;

        public SupplierLoaderAdapter(Loader supplierLoader)
        {
            _supplierLoader = supplierLoader;
        }
        public Vendor LoadVendor(string id)
        {
            var supplier = _supplierLoader.LoadSupplier(id);
            return new Vendor
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Address = supplier.Address,
                Type = "Supplier"
            };
        }
        public IEnumerable<Vendor> LoadVendors()
        {
            return _supplierLoader.LoadSuppliers().Select(s => new Vendor
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Type = "Supplier"
            });
        }
        public void InsertVendor(Vendor vendor)
        {
            var supplier = new Supplier
            {
                Id = vendor.Id,
                Name = vendor.Name,
                Address = vendor.Address
            };
            _supplierLoader.InsertSupplier(supplier);
        }
        public void UpdateVendor(Vendor vendor)
        {
            var supplier = new Supplier
            {
                Id = vendor.Id,
                Name = vendor.Name,
                Address = vendor.Address
            };
            _supplierLoader.UpdateSupplier(supplier);
        }
        public void DeleteVendor(string id)
        {
            _supplierLoader.DeleteSupplier(id);
        }
    }
}
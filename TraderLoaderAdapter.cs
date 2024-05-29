using SqlServerLoader;
using System.Collections.Generic;
using System.Linq;
using VendorsWebService.Models;

namespace VendorsWebService
{
    public class TraderLoaderAdapter : IVendorLoader
    {
        private readonly DataLoader _traderLoader;

        public TraderLoaderAdapter(DataLoader traderLoader)
        {
            _traderLoader = traderLoader;
        }

        public Vendor LoadVendor(string id)
        {
            var trader = _traderLoader.LoadTrader(id);

            return new Vendor
            {
                Id = trader.Code,
                Name = trader.Description,
                Address = trader.Street,
                Type = "Trader"
            };
        }
        public IEnumerable<Vendor> LoadVendors()
        {
            return _traderLoader.LoadTraders().Select(t => new Vendor
            {
                Id = t.Code,
                Name = t.Description,
                Address = t.Street,
                Type = "Trader"
            });
        }
        public void InsertVendor(Vendor vendor)
        {
            var trader = new Trader
            {
                Code = vendor.Id,
                Description = vendor.Name,
                Street = vendor.Address
            };
            _traderLoader.InsertTrader(trader);
        }

        public void UpdateVendor(Vendor vendor)
        {
            var trader = new Trader
            {
                Code = vendor.Id,
                Description = vendor.Name,
                Street = vendor.Address
            };
            _traderLoader.UpdateTrader(trader);
        }
        public void DeleteVendor(string id)
        {
            _traderLoader.DeleteTrader(id);
        }

    }
}
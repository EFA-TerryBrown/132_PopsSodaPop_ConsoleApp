using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Vendor_Repository
    {
         private readonly List<Vendor> _vendorDatabase = new List<Vendor>();
        private int _count; 
        public bool AddVendorToDatabase(Vendor vendor)
        {
            if(vendor != null)
            {
                _count++;
                vendor.ID=_count;
                _vendorDatabase.Add(vendor);
                return true;
            }
            else
            {
                return false;
            }
        }
    
        public List<Vendor> GetAllVendors()
        {
            return _vendorDatabase;
        }
        public Vendor GetVendorByID(int id)
        {
            foreach(var vendor in _vendorDatabase)
            {
                if(vendor.ID==id)
                {
                    return vendor;
                }
            }
            return null;
        }
    
        //Challenge: do update and delet methods
    }

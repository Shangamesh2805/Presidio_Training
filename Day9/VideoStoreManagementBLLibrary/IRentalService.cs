using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video_Store_Management_Models;

namespace VideoStoreManagementBLLibrary
{
    public interface IRentalService
    {
        Rental RentVideo(int customerId, int videoId);
        bool ReturnVideo(int rentalId);
        List<Rental> GetAllRentals();
        List<Rental> GetRentalsByCustomer(int customerId);
        List<Rental> GetRentalsByVideo(int videoId);
    }

}

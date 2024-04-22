using System;
using System.Collections.Generic;
using System.Linq;
using Video_Store_Management_Models;

namespace VideoStoreManagmentDALLibrary
{
    public class RentalRepository : IRepository<int, Rental>
    {
        private readonly Dictionary<int, Rental> _rentals;

        public RentalRepository()
        {
            _rentals = new Dictionary<int, Rental>();
        }

        public Rental Add(Rental rental)
        {
            try
            {
                // Check if the rental already exists
                if (_rentals.ContainsValue(rental))
                {
                    throw new InvalidOperationException("Rental already exists in the repository.");
                }

                // Check if the rental already has an ID
                if (rental.Id == 0)
                {
                    rental.Id = GenerateId();
                }

                _rentals.Add(rental.Id, rental);
                return rental;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the rental: {ex.Message}");
                return null;
            }
        }

        public Rental Delete(int key)
        {
            try
            {
                if (_rentals.ContainsKey(key))
                {
                    var rental = _rentals[key];
                    _rentals.Remove(key);
                    return rental;
                }
                else
                {
                    throw new KeyNotFoundException($"Rental with ID {key} does not exist in the repository.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the rental: {ex.Message}");
                return null;
            }
        }

        public Rental Get(int key)
        {
            try
            {
                if (_rentals.ContainsKey(key))
                {
                    return _rentals[key];
                }
                else
                {
                    throw new KeyNotFoundException($"Rental with ID {key} does not exist in the repository.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the rental: {ex.Message}");
                return null;
            }
        }

        public List<Rental> GetAll()
        {
            return _rentals.Values.ToList();
        }

        public Rental Update(Rental rental)
        {
            try
            {
                if (_rentals.ContainsKey(rental.Id))
                {
                    _rentals[rental.Id] = rental;
                    return rental;
                }
                else
                {
                    throw new KeyNotFoundException($"Rental with ID {rental.Id} does not exist in the repository.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the rental: {ex.Message}");
                return null;
            }
        }

        private int GenerateId()
        {
            if (_rentals.Count == 0)
            {
                return 1;
            }
            int id = _rentals.Keys.Max();
            return ++id;
        }
    }
}

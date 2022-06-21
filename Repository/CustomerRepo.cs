
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Helpers;
using Test_App.Models;
using Test_App.RequestModels;
using Test_App.ResponseModels;

namespace Test_App.Repository
{
  public interface ICustomerRepo
  {
    Task<GenericResponseModel> CreateCustomer(CreateRequestModel obj);
    Task<GenericResponseModel> GetAllCustomers();
    Task<GenericResponseModel> getCustomerById(long courseId);
     Task<GenericResponseModel> getCustomerbyFullName(string Firstname, string LastName);

    }
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<GenericResponseModel> GetAllCustomers()
        {
            try
            {
                var result = from vh in _db.Customers
                             select new
                             {
                                 vh.Id,
                                 vh.Email,
                                 vh.FirstName,
                                 vh.LastName,
                                 vh.LgaId,
                                 vh.StateId,
                             };
                if (!result.Any())
                {
                    return new GenericResponseModel { StatusCode = 200, StatusMessage = "Successful, No Record Available", };
                }
                return new GenericResponseModel { StatusCode = 200, StatusMessage = "Successful", Data = result.ToList<object>(), };
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public async Task<GenericResponseModel> CreateCustomer(CreateRequestModel obj)
        {
            try
            {
                //var g = 
                User model = new()
                {
                    Email = obj.Email,
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    StateId = obj.StateId,
                    LgaId = obj.LgaId,
                    PhoneNumber = obj.PhoneNumber,
                    PhoneNumberConfirmed = false,
                };
                if (!string.IsNullOrWhiteSpace(obj.Password))
                   // model.Password = GenerateHash(obj.Password);

                await _db.Customers.AddAsync(model);
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public async Task<GenericResponseModel> getCustomerById(long cusId)
        {
            try
            {
                var result = from cus in _db.Customers.Where(x => x.Id == cusId)
                             select new
                             {
                                 cus.FirstName,
                                 cus.LastName,
                                 cus.PhoneNumber,

                             };

                if (result.Count() > 0)
                {
                    return new GenericResponseModel { StatusCode = 200, StatusMessage = "Successful!", Data = result.FirstOrDefault() };
                }

                return new GenericResponseModel { StatusCode = 409, StatusMessage = "No Customer Found!" };
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }
        public async Task<GenericResponseModel> getCustomerbyFullName(string Firstname, string Lastname)
        {
            try
            {
                var result = from cus in _db.Customers.Where(x => x.FirstName == Firstname && x.LastName == Lastname)
                             select new
                             {
                                 cus.FirstName,
                                 cus.LastName,
                                 cus.PhoneNumber
                             };
                if (result.Count() > 0)
                {
                    return new GenericResponseModel { StatusCode = 200, StatusMessage = "Successful!", Data = result.FirstOrDefault() };
                }

                return new GenericResponseModel { StatusCode = 409, StatusMessage = "No Customer with this name found!" };
            }
            catch (Exception)
            {

                throw;
           
            }
            throw new NotImplementedException();



        }
    }
}

﻿using Customers;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersMangement
{
    public class CustomerService
    {
        public readonly CustomerDBConnector Context = new CustomerDBConnector();

        public int getLatestCustomerId()
        {
            var c = Context.Customers.AsQueryable().Count();
            return c == 0 ? 1 : Context.Customers.AsQueryable().OrderByDescending(r => r.CustomerId).FirstOrDefault().CustomerId;

        }
        public string RegisterCustomer(string first_name, string last_name, string password, string email, string driving_licence_number, string mobile, string state, string city, string country, string zipcode, string phone, DateTime registrationDate)
        {
            try
            {
                
                //var isCustomerRegistered = await _CustomerRepository.CustomerAlreadyRegistered(email);

                //if (isCustomerRegistered)
                {
                    var errorMessage = $"There is already a customer registered with the e-mail {email}";

                    //return new CustomerResponseDto(new Exception(errorMessage), false);
                }

                byte[] passwordHash, passwordSalt;

                Utilities.Utilities.GeneratePasswordHash(password, out passwordHash, out passwordSalt);

                var customerToCreate = new Customer()
                {
                    CustomerId = getLatestCustomerId() + 1,
                    FirstName = first_name,
                    LastName = last_name,
                    Email = email,
                    Password = password,
                    DrivingLicenseNumber = driving_licence_number,
                    Mobile = mobile,
                    State = state,
                    City = city,
                    Country = country,
                    Zipcode = zipcode,
                    Phone = phone,
                    RegistrationDate = registrationDate
                };

                Context.Customers.Insert(customerToCreate);

                //    await _CustomerRepository.Create(customerToCreate);

                //    return RegisterCustomerToResponseConverter.EntityToResponse(customerToCreate);
            }
            catch (Exception ex)
            {
                var errorMessage = $"{ex.Message} : {ex.InnerException}";
                return (JsonConvert.SerializeObject(false));
                //return new CustomerResponseDto(new Exception(errorMessage), false);
            }

            return (JsonConvert.SerializeObject(true));
        }


        public string CustomerLogin(string email, string password)
        {
            bool isLogin = false;
            try
            {
                byte[] passwordHash, passwordSalt;

                Utilities.Utilities.GeneratePasswordHash(password, out passwordHash, out passwordSalt);

                var customers = Context.Customers.AsQueryable().ToList();
                isLogin = customers.Where(s => s.Password == password && s.Email == email).Count() > 0 ? true : false;
                //Context.Customers.Insert(customerToCreate);

                //    await _CustomerRepository.Create(customerToCreate);

                //    return RegisterCustomerToResponseConverter.EntityToResponse(customerToCreate);
            }
            catch (Exception ex)
            {
                var errorMessage = $"{ex.Message} : {ex.InnerException}";
                return (JsonConvert.SerializeObject(isLogin));
                
            }

            return (JsonConvert.SerializeObject(isLogin));
        }

        public string DeleteUserByDocumentID(string id)
        {
            try
            {
                Context.Customers.Remove(Query.EQ("_id", new ObjectId(id)));
                
            }
            catch (Exception ex)
            {
                return (JsonConvert.SerializeObject(false));
            }
            return (JsonConvert.SerializeObject(true));
        }

        public string DeleteUserByCustomerID(int customerId)
        {
            try
            {
                Context.Customers.Remove(Query.EQ("CustomerId", customerId));

            }
            catch (Exception ex)
            {
                return (JsonConvert.SerializeObject(false));
            }
            return (JsonConvert.SerializeObject(true));
        }

    }
}

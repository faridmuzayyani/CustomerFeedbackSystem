﻿using FeedbackReview.Models;

namespace FeedbackReview.DAL
{
    public class CustomerEF : ICustomer
    {
        private readonly CustomerFeedbackDBContext _dbContext;

        public CustomerEF(CustomerFeedbackDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Customer Add(Customer entity)
        {
            try
            {
                _dbContext.Customers.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var customer = _dbContext.Customers.Find(id);
                if (customer != null)
                {
                    _dbContext.Customers.Remove(customer);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Customer not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting customer: " + ex.Message);
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            var result = from c in _dbContext.Customers
                         select c;
            return result.ToList();
        }

        public Customer GetById(int id)
        {
            var result = (from c in _dbContext.Customers
                          where c.CustomerId == id
                          select c).FirstOrDefault();
            return result;
        }

        public Customer Update(Customer entity)
        {
            _dbContext.Customers.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}

using EFCodeFirstTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTutorial.Controllers {
    public class CustomerController {

        private readonly AppDbContext _context;

        public async Task<IEnumerable<Customer>> GetAll() {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetByPk(int id) {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> Create(Customer customer) {
            if(customer == null) {
                throw new Exception("Customer cannot be Null");
            }
            if(customer.Id != 0) {
                throw new Exception("Customer.Id has to be zero");
            }
            _context.Customers.Add(customer);
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1) {
                throw new Exception("Create failed");
            }
            return customer;
        } 

        public async Task<Customer> Change(Customer customer) {
            if(customer == null) {
                throw new Exception("Customer cannot be NULL");
            }
            if(customer.Id <= 0) {
                throw new Exception("Customer.Id has to be greater than zero");
            }
            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = await _context.SaveChangesAsync();
            if(rowsAffected != 1) {
                throw new Exception("Change failed");
            }
            return customer;
        }

        public async Task<Customer> Remove(int Id) {
            var customer = _context.Customers.Find(Id);
            if(customer == null) {
                return null;
            }
            _context.Customers.Remove(customer);
            var rowsAffected = await _context.SaveChangesAsync();
            if(rowsAffected != 1) {
                throw new Exception("Delete Failed");
            }
            return customer;
        }




        public CustomerController() {
            _context = new AppDbContext();
        }
    }
}

using EFCodeFirstTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTutorial.Controllers {
    public class OrdersController {

        private readonly AppDbContext _context;

        public async Task<IEnumerable<Order>> GetAll() {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetByPK(int id) {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> Create(Order order) {
            if (order == null) {
                throw new Exception("Order cannot be null");
            }
            if (order.Id != 0) {
                throw new Exception("Order.Id must be zero");
            }
            _context.Orders.Add(order);
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1) {
                throw new Exception("Create Failed");
            }
            return order;
        }

        public async Task<Order> Change(Order order) {
            if (order == null) {
                throw new Exception("Order cannot be null");
            }
            if (order.Id <= 0) {
                throw new Exception("Order.Id must be greater than zero");
            }
            _context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1) {
                throw new Exception("Change failed");
            }
            return order;
        }

        public async Task<Order> Remove(int id) {
            var order = _context.Orders.Find(id);
            if(order == null) {
                return null;
            }
            _context.Orders.Remove(order);
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1) {
                throw new Exception("Delete Failed");
            }
            return order;
        }



        public OrdersController() {
            _context = new AppDbContext();
        }
            
        
    
    }

}

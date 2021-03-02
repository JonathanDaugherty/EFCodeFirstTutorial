using EFCodeFirstTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTutorial.Controllers {
    public class OrderLinesController {

        private readonly AppDbContext _context;

        public async Task<IEnumerable<OrderLine>> GetAll() {
            return await _context.orderLines.ToListAsync();
        }

        public async Task<OrderLine> GetByPK(int id) {
            return await _context.orderLines.FindAsync(id);
        }

        public async Task<OrderLine> Create(OrderLine orderline) {
            if(orderline == null) {
                throw new Exception("Orderline cannot be null");
            }
            if(orderline.Id != 0) {
                throw new Exception("Orderline.Id must be zero");
            }
            _context.orderLines.Add(orderline);
            var rowsAffected = await _context.SaveChangesAsync();
            if(rowsAffected != 1) {
                throw new Exception("Create Failed");
            }
            return orderline;
        }

        public async Task<OrderLine> Change(OrderLine orderline) {
            if(orderline == null) {
                throw new Exception("orderline cannot be NULL");
            }
            if(orderline.Id <= 0 ) {
                throw new Exception("Orderline.Id must be greater than zero");
            }
            _context.Entry(orderline).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1) {
                throw new Exception("Change failed");
            }
            return orderline;
        } 

        public async Task<OrderLine> Remove(int id) {
            var orderline = _context.orderLines.Find(id);
            if(orderline == null) { 
                return null;
            }
            _context.orderLines.Remove(orderline);
            var rowsAffected = await _context.SaveChangesAsync();
            if(rowsAffected != 1) {
                throw new Exception("Delete Failed");
            }
            return orderline;
        }

        public OrderLinesController() {
            _context = new AppDbContext();
        }

    }
}

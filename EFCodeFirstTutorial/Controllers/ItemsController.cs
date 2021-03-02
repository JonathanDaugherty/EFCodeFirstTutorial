using EFCodeFirstTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTutorial.Controllers {
    public class ItemsController {

        private readonly AppDbContext _context;

        public async Task<IEnumerable<Item>> GetAll() {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetByPK(int id) {
            return await _context.Items.FindAsync(id);
        }

        public async Task<Item> Create(Item item) {
            if(item == null) {
                throw new Exception("Item cannot be NULL");
            }
            if(item.Id != 0) {
                throw new Exception("item.Id must be zero");
            }
            _context.Items.Add(item);
            var rowsAffected = await _context.SaveChangesAsync();
            if(rowsAffected != 1) {
                throw new Exception("Create failed");
            }
            return item;
        }
        public async Task<Item> Change(Item item) {
            if (item == null) {
                throw new Exception("Item cannot be NULL");
            }
            if (item.Id <= 0) {
                throw new Exception("item.Id must be zero");
            }
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1) {
                throw new Exception("Change failed");
            }
            return item;
        }
        public async Task<Item> Remove(int Id) {
            var item = _context.Items.Find(Id);
            if (item == null) {
                return null;
            }
            _context.Items.Remove(item);
            var rowsAffected = await _context.SaveChangesAsync();
            if (rowsAffected != 1) {
                throw new Exception("Delete Failed");
            }
            return item;
        }

        public ItemsController() {
            _context = new AppDbContext();
        }

    }
}


using EFCodeFirstTutorial.Controllers;
using EFCodeFirstTutorial.Models;
using System;
using System.Threading.Tasks;

namespace EFCodeFirstTutorial {
    class Program {
        static async Task Main(string[] args) {










            var octrl = new OrdersController();

            var neworder = new Order {
                Id = 0, Description = "4000 boxes", Status = "Delivered", Total = 8000.00m, CustomerId = 1
            };
            var WALorder1 = await octrl.Create(neworder);

            var neworder2 = new Order {
                Id = 0, Description = "2000 labels", Status = "Delivered", Total = 2500.00m, CustomerId = 1
            };
            var WALorder2 = await octrl.Create(neworder2);

            var allorders = await octrl.GetAll();
            foreach (var o in allorders) {
                Console.WriteLine($"{o.Description} | {o.Total}");
            }

            var oup = await octrl.GetByPK(2);
            oup.Status = "In Transit";
            await octrl.Change(oup);

            var findorder = await octrl.GetByPK(2);
            if (findorder == null) {
                Console.WriteLine($"Order could not be found");
            } else {

                Console.WriteLine($"{findorder.Description}");
            }

            var orderdelete = await octrl.Remove(findorder.Id);












            var ictrl = new ItemsController();

            var newitem = new Item {
                Id = 0, Name = "Box", Price = 2.00m
            };
            var box = await ictrl.Create(newitem);

            var newitem2 = new Item {
                Id = 0, Name = "Packing Tape", Price = 1.50m
            };
            var tape = await ictrl.Create(newitem2);

            var items = await ictrl.GetAll();
            foreach (var i in items) {
                Console.WriteLine($"{i.Name}");
            }

            var itup = await ictrl.GetByPK(4);
            itup.Name = "Label";
            itup.Price = 1.25m;
            await ictrl.Change(itup);


            var find4 = await ictrl.GetByPK(4);
            if (find4 == null) {
                Console.WriteLine("Is Null");
            } else {
                Console.WriteLine($"{find4.Name} | {find4.Price}");
            }

            var itemdeleted = await ictrl.Remove(3);


















            //var cctrl = new CustomerController();
            //var newcust = new Customer {
            //    Id = 0, Code = "WAL", Name = "Walmart", Sales = 250000.00m,
            //    Created = new DateTime(2010, 02, 01)
            //};
            ////var walmart = await cctrl.Create(newcust);

            ////Console.WriteLine($"{walmart.Id}| {walmart.Code}");

            //var newcust2 = new Customer {
            //    Id = 0, Code = "AMAZ", Name = "Amazon", Sales = 400000.00m,
            //    Created = new DateTime(2012, 04, 01)
            //};
            ////var amazon = await cctrl.Create(newcust2);
            ////Console.WriteLine($"{amazon.Id} | {amazon.Code}");

            //var allcust = await cctrl.GetAll();
            //foreach(var c in allcust) {
            //    Console.WriteLine($"{c.Name} | {c.Created} | {c.Sales}");
            //}

            //var amazchange = await cctrl.GetByPk(2);
            //amazchange.Sales = 450000.00m;
            ////await cctrl.Change(amazchange);

            ////Console.WriteLine($"{amazchange.Sales}");

            //var findamaz = await cctrl.GetByPk(2);
            ////if(findamaz == null) {
            ////    Console.WriteLine($"Not Found");
            ////}else {
            ////    Console.WriteLine($"{findamaz.Code} | {findamaz.Name}");
            ////}

            ////var custdeleted = await cctrl.Remove(findamaz.Id);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookAPP.Controllers
{
    public class BooksListController : Controller
    {
        private List<BooksDetails> Books = new List<BooksDetails>()
        {
           new BooksDetails{Name="Book1",Quantity=2},
           new BooksDetails{Name="Book2",Quantity=4},
           new BooksDetails{Name="Book3",Quantity=5},
           new BooksDetails{Name="Book4",Quantity=6},

        };
        public IActionResult Index()
        {
            return View(Books);
        }
        public IActionResult BorrowBooks()
        {
            return View();
        }
        public IActionResult AddBooks()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BorrowBooks(BooksDetails Book)
        {
            foreach(var item in Books)
            {
                if(item.Name==Book.Name)
                {
                    item.Quantity = item.Quantity - Book.Quantity;
                }
              //foreach (var quant in Books)
                  //  if (item.Quantity == 0)
                Books.Remove(Books.Single(x => x.Quantity == 0));
                return View("index", Books);

                //if(item.Quantity==0)
                //{
                //    Books.Remove(item.Name);
                //}
            }
            return View("index", Books);

            
        }
        [HttpPost]
        public IActionResult AddBooks(BooksDetails BookName)
        {
            Books.Add(new BooksDetails() {Name=BookName.Name,Quantity=BookName.Quantity });
            return View("index",Books);
        }
        
    }
}
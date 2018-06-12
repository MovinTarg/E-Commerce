using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        private ECommerceContext _eCommerceContext;
        public HomeController (ECommerceContext context)
        {
            _eCommerceContext = context;
        }
        public IActionResult Index()
        {
            List<Product> RecentProducts = _eCommerceContext.Product
                .OrderByDescending(p => p.CreatedAt)
                .Take(5)
                .ToList();
            List<Order> RecentOrders = _eCommerceContext.Order
                .Include(c => c.Customer)
                .Include(p => p.Product)
                .OrderByDescending(o => o.CreatedAt)
                .Take(3)
                .ToList();
            List<Customer> RecentCustomers = _eCommerceContext.Customer
                .OrderByDescending(c => c.CreatedAt)
                .Take(3)
                .ToList();
            ViewBag.RecentProducts = RecentProducts;
            ViewBag.RecentOrders = RecentOrders;
            ViewBag.RecentCustomers = RecentCustomers;
            return View();
        }
        public IActionResult Products()
        {
            List<Product> AllProducts = _eCommerceContext.Product
                .ToList();
            ViewBag.AllProducts = AllProducts;
            return View();
        }
        public IActionResult Orders()
        {
            List<Product> AllProducts = _eCommerceContext.Product
                .ToList();
            List<Customer> AllCustomers = _eCommerceContext.Customer
                .ToList();
            List<Order> AllOrders = _eCommerceContext.Order
                .Include(c => c.Customer)
                .Include(p => p.Product)
                .ToList();
            ViewBag.AllProducts = AllProducts;
            ViewBag.AllCustomers = AllCustomers;
            ViewBag.AllOrders = AllOrders;
            return View();
        }
        public IActionResult Customers()
        {
            List<Customer> AllCustomers = _eCommerceContext.Customer
                .ToList();
            ViewBag.AllCustomers = AllCustomers;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Customer model)
        {
            if (ModelState.IsValid)
            {
                var customerCheck = _eCommerceContext.Customer.Any(Customer => Customer.Name == model.Name);
                if (customerCheck == false)
                {
                    Customer newCustomer = new Customer
                    {
                        Name = model.Name,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    _eCommerceContext.Add(newCustomer);
                    _eCommerceContext.SaveChanges();
                    return RedirectToAction("Customers");
                }
                else
                {
                    ViewBag.Messages = "Customer already registered!";
                }
            }
            List<Customer> AllCustomers = _eCommerceContext.Customer
                .ToList();
            ViewBag.AllCustomers = AllCustomers;
            return View("Customers");
        }
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                Product newProduct = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Quantity = model.Quantity,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _eCommerceContext.Add(newProduct);
                _eCommerceContext.SaveChanges();
                return RedirectToAction("Products");
            }
            List<Product> AllProducts = _eCommerceContext.Product
                .ToList();
            ViewBag.AllProducts = AllProducts;
            return View("Products");
        }
        public IActionResult Purchase(Order model)
        {
            if (ModelState.IsValid)
            {
                Product orderedproduct = _eCommerceContext.Product
                    .Where(p => p.ProductId == model.ProductId)
                    .SingleOrDefault();
                if (orderedproduct.Quantity >= model.Quantity)
                {
                    Order newOrder = new Order
                    {
                        Quantity = model.Quantity,
                        CustomerId = model.CustomerId,
                        ProductId = model.ProductId,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    orderedproduct.Quantity = orderedproduct.Quantity - model.Quantity;
                    _eCommerceContext.Update(orderedproduct);
                    _eCommerceContext.Add(newOrder);
                    _eCommerceContext.SaveChanges();
                    return RedirectToAction("Orders");
                }
                else
                {
                    ViewBag.Messages = "Not enough product to complete order!";
                }
            }
            List<Product> AllProducts = _eCommerceContext.Product
                .ToList();
            List<Customer> AllCustomers = _eCommerceContext.Customer
                .ToList();
            List<Order> AllOrders = _eCommerceContext.Order
                .Include(c => c.Customer)
                .Include(p => p.Product)
                .ToList();
            ViewBag.AllProducts = AllProducts;
            ViewBag.AllCustomers = AllCustomers;
            ViewBag.AllOrders = AllOrders;
            return View("Orders");
        }
        public IActionResult Remove(int CustomerId)
        {
            Customer deleteCustomer = _eCommerceContext.Customer
                .Where(c => c.CustomerId == CustomerId)
                .SingleOrDefault();
            _eCommerceContext.Customer.Remove(deleteCustomer);
            _eCommerceContext.SaveChanges();
            return RedirectToAction("Customers");
        }
    }
}

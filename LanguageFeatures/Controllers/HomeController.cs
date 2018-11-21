using System;
using System.Collections.Generic;
using System.Linq;
using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        { 
            //Extension
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            Product[] productArray =
            {
                new Product{ Name = "Kayak", Price = 275M },
                new Product{ Name = "LifeJacket", Price = 48.95M },
                new Product{ Name = "Soccer Ball", Price = 15.8M }
            };
            decimal cartTotal = cart.TotalPrices(); //Llamada a extension
            decimal arrayTotal = productArray.TotalPrices(); //Llamada porque implementa interfaz IEnumerable<Products>
            decimal filterdArrayTotal = productArray.FilterByPrice(100).FilterByName("Kay").TotalPrices();//Implementacion filtrando con yield

            decimal priceFilterTotal = productArray.Filter(p => (p?.Price ?? 0) >= 20).TotalPrices(); //Filtrado con lambda
            decimal nameFilterTotal = productArray.Filter(p => p?.Name?[0] == 'K').TotalPrices();
            decimal otherPriceFilter = productArray.Filter(p => (p?.Price ?? 0) > 100).TotalPrices(); //Filter devuelve lista de productos
            
            //Index notation
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
                ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M }
            };
            List<string> results = new List<string>();
            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "No name";
                decimal? price = p?.Price ?? 0M;
                string relatedName = p?.Related?.Name ?? "No related";
                results.Add($"{name}, {price}, {relatedName}");
            }



            //return View("Index", new string[] 
            //    {
            //        $"Total del carrito {cartTotal:C2}",
            //        $"Total del array {arrayTotal:C2}",
            //        $"Total del array yield {filterdArrayTotal:C2}", 
            //        $"Total del array yield con lambda 1 => {priceFilterTotal:C2}", 
            //        $"Total del array yield con lamda 2 => {nameFilterTotal:C2}", 
            //    });
            return View("Index", Product.GetProducts().Select(p => p?.Name));
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AgnusCrm.Data;
using AgnusCrm.Helpers;
using AgnusCrm.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgnusCrm.Controllers
{
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _env;
        private readonly IEmailSender _emailSender;
      

        public CartController(ApplicationDbContext context,
           IEmailSender emailSender,
           IHostingEnvironment env)
        {
            _context = context;
            _emailSender = emailSender;
            _env = env;
        }

        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session,
                "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(i => i.price * i.quantity);

            foreach (var item in cart)
            {
                item.Product = _context.Product.Single(p => p.productId == item.productCode);
            }

            return View(cart);
        }

        [Route("AddItem/{id}")]
        public IActionResult AddItem(string id, [FromQuery] int quantity, [FromQuery] double price)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            if (cart == null)
            {
                cart = new List<Item>
                {
                    new Item()
                    {
                        productCode = id,
                        quantity = quantity,
                        price = price
                    }
                };


            }
            else
            {
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(
                        new Item()
                        {
                            productCode = id,
                            quantity = quantity,
                            price = price
                        }
                    );
                }
                else
                {
                    cart[index].quantity = quantity;
                    cart[index].price = price;
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return new JsonResult(cart);
        }

        private int Exists(List<Item> cart, string id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].productCode == id)
                {
                    return i;
                }
            }
            return -1;
        }

        [Route("RemoveItem/{id}")]
        public IActionResult RemoveItem(string id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            if (cart != null)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].productCode == id)
                    {
                        cart.RemoveAt(i);
                        break;
                    }
                }
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return new JsonResult(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session,
                "cart");

            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(i => i.price * i.quantity);

            string linhas = "";

            foreach (var item in cart)
            {
                item.Product = _context.Product.Single(p => p.productId == item.productCode);
                linhas +=
                    string.Format(
                    @"<tr> 
                        <td>{0}</td>
                        <td>{1}</td>
                        <td>{2}</td>
                        <td>{3}</td>
                        <td>{4}</td>
                     </tr>", item.Product.productCode, item.Product.description, Math.Round(item.price, 2),
                        item.quantity, Math.Round(item.price * item.quantity, 2));
            }

            var pathToFile = _env.ContentRootPath + Path.DirectorySeparatorChar.ToString()
                            + "Templates"
                            + Path.DirectorySeparatorChar.ToString()
                            + "Email"
                            + Path.DirectorySeparatorChar.ToString()
                            + "PriceList.html";

            //_emailSender.SendEmailInvoice(
            //    string.Format("Price List/Encomenda - {0}",cliente) , 
            //    user.e, 
            //    pathToFile, 
            //    linhas
            // );

            return RedirectToAction(nameof(Index), "PriceList");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgnusCrm.Web.Helpers;
using AgnusCrm.Web.Models;
using AgnusCrm.Web.Data;

namespace AgnusCrm.Web.Controllers
{
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session,
                "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(i => i.price * i.quantity);

            foreach(var item in cart)
            {
                item.Product = _context.Product.Single(p => p.id == item.productId);
            }

            return View(cart);
        }

        [Route("AddItem/{id}")]
        public IActionResult AddItem(int id,[FromQuery] int quantity, [FromQuery] double price )
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(
                    new Item()
                    {
                        productId = id,
                        quantity = quantity,
                        price = price
                    }
                );

                
            }
            else
            {
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(
                        new Item()
                        {
                            productId = id,
                            quantity = quantity,
                            price = price
                        }
                    );
                }
                else
                {
                    cart[index].quantity=quantity;
                    cart[index].price = price;
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return new JsonResult(cart);
            //return RedirectToAction("Index");
        }

        private int Exists(List<Item> cart,int id)
        {
            for(int i = 0;i < cart.Count; i++)
            {
                if(cart[i].productId == id)
                {
                    return i;
                }
            }
            return -1;
        }

        [Route("RemoveItem/{id}")]
        public IActionResult RemoveItem(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            if (cart != null)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].productId == id)
                    {
                        cart.RemoveAt(i);
                        break;
                    }
                }
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return new JsonResult(cart);
        }

    }
}
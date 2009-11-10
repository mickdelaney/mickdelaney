﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MD.Samples.CQRS.Orders.Domain;
using MD.Samples.CQRS.Orders.WebApp.Models;
using NServiceBus;
using MD.Samples.CQRS.Orders.Messages;
using MD.Mvc2.WebApp.Core;

namespace MD.Samples.CQRS.Orders.WebApp.Controllers
{
    public class ProductController : Controller
    {
         IBus _bus;

        public ProductController(IBus bus) 
        {
            _bus = bus;
        } 

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View(new CreateProductCommand());
        } 

        //
        // POST: /Product/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(CreateProductCommand createProduct)
        {
            try
            {

                var token = Guid.NewGuid();
                _bus.Send(new CreateProductMessage { Id = token, Name = createProduct.Name, Price = createProduct.Price });

                return this.RedirectToAction<HomeController>(c => c.Index());
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Product/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
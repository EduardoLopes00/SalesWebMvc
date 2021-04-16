﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellersService _sellersService;
        private readonly DepartmentService _departmentService;


        public SellersController(SellersService sellersService, DepartmentService departmentService)
        {
            _sellersService = sellersService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellersService.FindAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel(departments);
            return View(viewModel);
        }

        [HttpPost] //Indica que o método é post
        [ValidateAntiForgeryToken] //Proteção contra ataques na mesma autenticaçãoi
        public IActionResult Create(Seller seller) {
            _sellersService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}

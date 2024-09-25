using AutoMapper;
using Demo.BLL.Interface;
using Demo.DAL.Models;
using Demo.PL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Demo.PL.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderInterface P;
        private readonly IMapper mapper;

        public OrderController(IOrderInterface P, IMapper mapper)
        {
            this.P = P;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {   var x = P.GetAll();
            var ViewModel = mapper.Map<IEnumerable<OrderVM>>(x);
            return View(ViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( OrderVM viewmodel)
        { if (ModelState.IsValid)
            {
                var model = mapper.Map<Order>(viewmodel);
                P.Add(model);
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }

        public IActionResult Details(int ?id)
        {    if (id is null)
            {
                return BadRequest();
            }
            var x = P.Get(id.Value);
            if(x is null)
            {
                return NotFound();
            }
            return View(x);
        }


        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var order = P.Get(id.Value);

            if (order is null)
            {
                return NotFound();
            }
            var orderVM = mapper.Map<OrderVM>(order);
            return View(orderVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                var model = mapper.Map<Order>(viewmodel);
                P.Update(model);
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
            public IActionResult Delete (int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var D = P.Get(id.Value);
            if (D is null)
            {
                return NotFound();
            }
            P.Delete(D);
            return RedirectToAction(nameof(Index));

        }
    }
}

using E_Commerce.Model;
using E_Commerce.MVC.Models;
using E_Commerce.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: User
        public async Task<ActionResult> Index()
        {
            var model = await _unitOfWork.CustomerRepository.GetAll();
            return View(model);
        }
        [HttpGet]
        public  ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.UserRepository.Add(customer as User);
                _unitOfWork.CustomerRepository.Add(customer);
                _unitOfWork.SaveChanges();
                return View();
            }
           
            return View();
        }
        [HttpGet]
        public ActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(CustomerLoginViewModel customer)
        {
            if(ModelState.IsValid)
            {
                var user = await _unitOfWork.UserRepository.Get(u => u.Email == customer.UserName);
                if(user == null) 
                {
                    return View();
                }
                if(user.Password != customer.Password)
                {
                    return View();
                }
                user.isActive = true;
                _unitOfWork.UserRepository.Update(user);
            }
            return View();
        }
    }
}
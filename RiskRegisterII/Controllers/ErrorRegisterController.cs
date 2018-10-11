using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiskRegister.Models;
using RiskRegisterII.Models;
using RiskRegisterII.Models.ViewModels;
using RiskRegisterII.Services;

namespace RiskRegisterII.Controllers
{
    [Route("ErrorRegister/[controller]")]
    public class ErrorRegisterController : Controller
    {

        private readonly IErrorRegister _errorRegister;
        private readonly IDepartment _department;
        private readonly ICompany _company;
        private readonly IRiskType _riskType;
        private readonly IUserManager _userManager;

        public ErrorRegisterController(IErrorRegister errorRegister, IDepartment department, ICompany company, IRiskType riskType, IUserManager userManager)
        {
            _errorRegister = errorRegister; _company = company; _department = department; _riskType = riskType; _userManager = userManager;

        }

        // [Route("/ErrorRegister")]
        // GET: ErrorRegister
        public ActionResult Index()
        {

            var userId = User.Identity.Name;
          
            //var loggedInUser = _appUserService.GetAppUser(t => t.Id == userId).FirstOrDefault();

            var _returnRegisters = _errorRegister.AllErrorRegisters();
            var _companyList = _company.AllCompanies();
            var _departmentList = _department.AllDepartments();
            var _riskList = _riskType.AllRiskTypes();

            var query = from errors in _returnRegisters
                        join companylist in _companyList on errors.CompanyId equals companylist.Id
                        join departmentlist in _departmentList on errors.DepartmentId equals departmentlist.Id
                        join risklist in _riskList on errors.RiskTypeId equals risklist.Id
                        select new ErrorRegisterVM
                        {
                            Id = errors.Id,
                            DateCreated = errors.DateCreated,
                            ErrorType = errors.ErrorType,
                            Narration = errors.Narration,
                            Officer = errors.Officer,
                            Status = errors.Status,
                            ErrorStatus = errors.ErrorStatus,
                            Remark = errors.Remark,
                            RiskType = risklist.Name,
                            Company = companylist.Name,
                            Department = departmentlist.Name,
                            DateUpdated = errors.DateUpdated,
                            UpdatedBy = userId

                        };

            return View(query);
        }

        // GET: ErrorRegister/Details/5
        [Route("/ErrorRegister/Details/{id}")]
        public ActionResult Details(int id)
        {
            var _getErrorRegisters = _errorRegister.GetErrorRegister(id);
            return View(_getErrorRegisters);
        }

        // GET: ErrorRegister/Create
        [Route("/ErrorRegister/Create")]
        public ActionResult Create()
        {
            List<Company> companyList = new List<Company>();
            List<Department> departmentlist = new List<Department>();
            List<RiskType> riskTypeList = new List<RiskType>();

            companyList = _company.AllCompanies().ToList();
            companyList.Insert(0, new Company { Id = 0, Name = "Select" });

            departmentlist = _department.AllDepartments().ToList();
            departmentlist.Insert(0, new Department { Id = 0, Name = "Select"});

            riskTypeList = _riskType.AllRiskTypes().ToList();
            riskTypeList.Insert(0, new RiskType { Id=0, Name = "Select"});

            ViewBag.CompanyDetails = companyList;
            ViewBag.DepartmentDetails = departmentlist;
            ViewBag.RiskTypeDetails = riskTypeList;




            return View();
        }

        // POST: ErrorRegister/Create
        [HttpPost]
        [Route("/ErrorRegister/Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ErrorRegisterModel errorRegister, IFormCollection collection)
        {
            try
            {
                
                // TODO: Add insert logic here
                _errorRegister.AddErrorRegister(errorRegister);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ErrorRegister/Edit/5
         [Route("/ErrorRegister/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            List<Company> companyList = new List<Company>();
            List<Department> departmentlist = new List<Department>();
            List<RiskType> riskTypeList = new List<RiskType>();

            companyList = _company.AllCompanies().ToList();
            companyList.Insert(0, new Company { Id = 0, Name = "Select" });

            departmentlist = _department.AllDepartments().ToList();
            departmentlist.Insert(0, new Department { Id = 0, Name = "Select" });

            riskTypeList = _riskType.AllRiskTypes().ToList();
            riskTypeList.Insert(0, new RiskType { Id = 0, Name = "Select" });

            ViewBag.CompanyDetails = companyList;
            ViewBag.DepartmentDetails = departmentlist;
            ViewBag.RiskTypeDetails = riskTypeList;

            var _getErrorRegisters = _errorRegister.GetErrorRegister(id);
            return View(_getErrorRegisters);
        }

        // POST: ErrorRegister/Edit/5
        [HttpPost]
        [Route("/ErrorRegister/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Save(int id, ErrorRegisterModel errorRegister, IFormCollection collection)
        {
            try
            {         
                // TODO: Add update logic here
                _errorRegister.UpdateErrorRegister(id, errorRegister);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ErrorRegister/Delete/5
        [Route("/ErrorRegister/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var _getErrorRegisters = _errorRegister.GetErrorRegister(id);
            return View(_getErrorRegisters);
        }

        // POST: ErrorRegister/Delete/5
        [HttpPost]
        [Route("/ErrorRegister/Delete/{Id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _errorRegister.DeleteErrorRegister(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
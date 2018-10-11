using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiskRegister.Models;
using RiskRegisterII.Models;
using RiskRegisterII.Models.ViewModels;
using RiskRegisterII.Services;

namespace RiskRegisterII.Controllers
{
    public class RegisterRiskController : Controller
    {

        private readonly IErrorRegister _errorRegister;
        private readonly IDepartment _department;
        private readonly ICompany _company;
        private readonly IRiskType _riskType;
        private readonly IRegisterRisk _registerRisk;
        private readonly IComplaintRegister _complaintRegister;


        public RegisterRiskController(IErrorRegister errorRegister, IDepartment department,
            ICompany company, IRiskType riskType, IRegisterRisk registerRisk, IComplaintRegister complaintRegister)
        {
            _errorRegister = errorRegister;
            _department = department;
            _company = company;
            _riskType = riskType;
            _registerRisk = registerRisk;
            _complaintRegister = complaintRegister;

        }

        
        // GET: RegisterRisk
        public ActionResult Index()
        {
            //ViewBag.SessionEmail =  HttpContext.Session.GetString("SessionEmail");
            var _registerRisks = _registerRisk.AllRiskRegisters();
            var _riskTypes = _riskType.AllRiskTypes();

            var query = from regRisks in _registerRisks
                        join riskTypes in _riskTypes on regRisks.RiskTypeId equals riskTypes.Id
                        select new RegisterRiskVM
                        {
                            Id = regRisks.Id,
                           Activity = regRisks.Activity,
                           InherentRisk = regRisks.InherentRisk,
                           LoggedBy = regRisks.LoggedBy,
                           RiskTypeName = riskTypes.Name,
                           Mitigants = regRisks.Mitigants,
                           DateCreated = regRisks.DateCreated

                        };

            return View(query);
        }



        //[AllowAnonymous]
        public IActionResult TestDB()
        {
            var testresult = _registerRisk.AllRiskRegisters();
            return View(testresult);
        }


        // GET: RegisterRisk/Details/5
        [Authorize(Roles ="SuperAdmin")]
        public ActionResult Details(int id)
        {
            //var _registerRisks = _registerRisk.AllRiskRegisters();
            var _riskTypes = _riskType.AllRiskTypes();

            var _result = _registerRisk.GetRiskRegister(id);
            var _returnView = _riskType.AllRiskTypes().Where(t => t.Id == _result.RiskTypeId).FirstOrDefault();

            var registerVM = new RegisterRiskVM()
            {
                Id = _result.Id,
                Activity = _result.Activity,
                InherentRisk = _result.InherentRisk,
                LoggedBy = _result.LoggedBy,
                RiskTypeName = _returnView.Name,
                Mitigants = _result.Mitigants,
                DateCreated = _result.DateCreated
            };

            return View(registerVM);
        }

        // GET: RegisterRisk/Create
        public ActionResult Create()
        {
            List<RiskType> riskTypeList = new List<RiskType>();
            riskTypeList = _riskType.AllRiskTypes().ToList();
            riskTypeList.Insert(0, new RiskType {  Name = "Select" });

            ViewBag.RiskLists = riskTypeList;

            return View();
        }

        // POST: RegisterRisk/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterRisk registerRisk, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                _registerRisk.AddRiskRegister(registerRisk);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterRisk/Edit/5
        public ActionResult Edit(int id)
        {
            List<RiskType> riskTypeList = new List<RiskType>();

            riskTypeList = _riskType.AllRiskTypes().ToList();
            riskTypeList.Insert(0, new RiskType { Id = 0, Name = "Select" });

            ViewBag.RiskTypeDetails = riskTypeList;

            var _getRegister = _registerRisk.GetRiskRegister(id);
            return View(_getRegister);
        }

        // POST: RegisterRisk/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RegisterRisk register, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _registerRisk.UpdateRiskRegister(id, register);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterRisk/Delete/5
        public ActionResult Delete(int id)
        {
            var _riskTypes = _riskType.AllRiskTypes();

            var _result = _registerRisk.GetRiskRegister(id);
            var _returnView = _riskType.AllRiskTypes().Where(t => t.Id == _result.RiskTypeId).FirstOrDefault();

            var registerVM = new RegisterRiskVM()
            {
                Id = _result.Id,
                Activity = _result.Activity,
                InherentRisk = _result.InherentRisk,
                LoggedBy = _result.LoggedBy,
                RiskTypeName = _returnView.Name,
                Mitigants = _result.Mitigants,
                DateCreated = _result.DateCreated
            };

            return View(registerVM);
        }

        // POST: RegisterRisk/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                 _registerRisk.DeleteRiskRegister(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
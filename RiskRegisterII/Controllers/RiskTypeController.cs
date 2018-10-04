using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiskRegister.Models;
using RiskRegisterII.Services;

namespace RiskRegisterII.Controllers
{
    public class RiskTypeController : Controller
    {

        private readonly IErrorRegister _errorRegister;
        private readonly IDepartment _department;
        private readonly ICompany _company;
        private readonly IRiskType _riskType;
        private readonly IComplaintRegister _complaintRegister;


        public RiskTypeController(IErrorRegister errorRegister, IDepartment department,
            ICompany company, IRiskType riskType, IComplaintRegister complaintRegister)
        {
            _errorRegister = errorRegister;
            _department = department;
            _company = company;
            _riskType = riskType;
            _complaintRegister = complaintRegister;
        }

        // GET: RiskType
        public ActionResult Index()
        {
            var _riskTypes = _riskType.AllRiskTypes();
            return View(_riskTypes);
        }

        // GET: RiskType/Details/5
        public ActionResult Details(int id)
        {
            var _getRiskById = _riskType.GetRiskType(id);
            return View(_getRiskById);
        }

        // GET: RiskType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RiskType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RiskType riskType, IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                _riskType.AddRiskType(riskType);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RiskType/Edit/5
        public ActionResult Edit(int id)
        {
            var _getRiskById = _riskType.GetRiskType(id);
            return View(_getRiskById);
        }

        // POST: RiskType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RiskType riskType, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _riskType.UpdateRiskType(id, riskType);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RiskType/Delete/5
        public ActionResult Delete(int id)
        {
            var _getRiskById = _riskType.GetRiskType(id);
            return View(_getRiskById);
        }

        // POST: RiskType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _riskType.DeleteRiskType(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
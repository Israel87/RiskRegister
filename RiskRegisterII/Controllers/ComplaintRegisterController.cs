using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiskRegisterII.Models;
using RiskRegisterII.Services;

namespace RiskRegisterII.Controllers
{
    //[Route("ComplaintRegister/[controller]")]
    public class ComplaintRegisterController : Controller
    {

        private readonly IErrorRegister _errorRegister;
        private readonly IDepartment _department;
        private readonly ICompany _company;
        private readonly IRiskType _riskType;
        private readonly IComplaintRegister _complaintRegister;


        public ComplaintRegisterController(IErrorRegister errorRegister, IDepartment department,
            ICompany company, IRiskType riskType, IComplaintRegister complaintRegister)
        {
            _errorRegister = errorRegister;
            _department = department;
            _company = company;
            _riskType = riskType;
            _complaintRegister = complaintRegister;
        }

       // [Route("/Complaints")]
        // GET: ComplaintRegister
        public ActionResult Index()
        {
            var _allComplaints = _complaintRegister.AllComplaints();
            return View(_allComplaints);
        }

        // GET: ComplaintRegister/Details/5
        public ActionResult Details(int id)
        {
            var _getComplaintRegister = _complaintRegister.GetComplaint(id);
            return View(_getComplaintRegister);
        }

        // GET: ComplaintRegister/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplaintRegister/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComplaintRegister register,IFormCollection collection)
        {

            try
            {

                // TODO: Add insert logic here
                _complaintRegister.AddComplaint(register);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComplaintRegister/Edit/5
        public ActionResult Edit(int id)
        {

            var _getComplaintRegister = _complaintRegister.GetComplaint(id);
            return View(_getComplaintRegister);
           
        }

        // POST: ComplaintRegister/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ComplaintRegister register, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _complaintRegister.UpdateComplaintRegister(id, register);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComplaintRegister/Delete/5
        public ActionResult Delete(int id)
        {
            var _getComplaintRegister = _complaintRegister.GetComplaint(id);
            return View(_getComplaintRegister);
        }

        // POST: ComplaintRegister/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _complaintRegister.DeleteComplaints(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hovedliste.Data;
using Hovedliste.Models;

namespace Hovedliste
{
    public class SagersController : Controller
    {
        private readonly HovedlisteContext _context;

        public SagersController(HovedlisteContext context)
        {
            _context = context; //Dependency Injection
        }

        // GET: Sagers
        public async Task<IActionResult> Index(string searchString, int Semester, string Fag = "0")
        {
            var vm = new SagerViewModel();
            
            var sager = from s in _context.Sager
                        select s;

            var fagQuery = from s in _context.Sager
                select s.Fag;

            vm.Fag = await fagQuery.ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                sager = sager.Where(s => s.Emne.Contains(searchString)
                                               || s.Tekst.Contains(searchString));
            }

            if (Semester != 0)
            {
                sager = sager.Where(s => s.Semester.Equals(Semester));
            }

            if (Fag != "0")
            {
                sager = sager.Where(s => s.Fag.Equals(Fag));
            }
           
            vm.Sager = await sager.ToListAsync();
            return View(vm);
        }

        //public async Task<IActionResult> Index(int Semester)
        //{
        //    var sager = from s in _context.Sager
        //        select s;
        //    if (Semester != null)
        //    {
        //        sager = sager.Where(s => s.Semester.Equals(Semester));
        //    }

        //    return View(await sager.ToListAsync());
        //}

        // GET: Sagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sager = await _context.Sager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sager == null)
            {
                return NotFound();
            }

            return View(sager);
        }

        // GET: Sagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Billede,Emne,Tekst,Fag,Semester")] Sager sager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sager);
        }

        // GET: Sagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sager = await _context.Sager.FindAsync(id);
            if (sager == null)
            {
                return NotFound();
            }
            return View(sager);
        }

        // POST: Sagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Billede,Emne,Tekst,Fag,Semester")] Sager sager)
        {
            if (id != sager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SagerExists(sager.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sager);
        }

        // GET: Sagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sager = await _context.Sager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sager == null)
            {
                return NotFound();
            }

            return View(sager);
        }

        // POST: Sagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sager = await _context.Sager.FindAsync(id);
            _context.Sager.Remove(sager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SagerExists(int id)
        {
            return _context.Sager.Any(e => e.Id == id);
        }
    }
}

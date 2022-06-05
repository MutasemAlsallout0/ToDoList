using HomeWork1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork1.Controllers
{
    public class ShowListController : Controller
    {
        static List<ToDoList> mylist = new();
        public IActionResult Index()
        {
            return View(nameof(Index),mylist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] ToDoList clist)
        {
            clist.id = ToDoList.currentid++;
            clist.InsertDate = DateTime.Now;
            mylist.Add(clist);
            return Index();
        }


  

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var elist = mylist.FirstOrDefault(x => x.id == id);
            if (elist == null)
                return NotFound();
            return View(elist);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind] ToDoList clist)
        {
            var elist = mylist.FirstOrDefault(x => x.id == id);
            if (elist == null)
                return NotFound();
            elist.WhatToDo = clist.WhatToDo;
            elist.Notes = clist.Notes;
            elist.WhenToDo = clist.WhenToDo;
            return Index();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dlist = mylist.FirstOrDefault(x => x.id == id);
            if (dlist == null)
                return NotFound();
           
            return View(dlist);
        }

        [HttpPost("[Controller]/Delete/{id}")]
        public IActionResult PostDelete(int id)
        {
            var dlist = mylist.FirstOrDefault(x => x.id == id);
            if (dlist == null)
                return NotFound();
            mylist.Remove(dlist);
            return Index();
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork1.Models
{
    public class ToDoList
    {
        public static int currentid { get; set; } = 1;
        public int id { get; set; }
        public string WhatToDo { get; set; }
        public string Notes { get; set; }
        public DateTime WhenToDo { get; set; }
        public DateTime InsertDate { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Book
{
    public int ID { get; set; }
    public Category Category { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public interface IRepository
{
    IEnumerable<Book> Books { get; }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Catalogue : System.Web.UI.Page
{
    private IRepository _repository = BaseRepository.Instance;
    private int limit = 10;

    protected int CurrentPage
    {
        get { return GetCurrentPage(); }
    }

    protected int MaxPage
    {
        get { return GetMaxPage(); }
    }

    public IEnumerable<Book> GetBooks()
    {
        return _repository.Books
            .OrderBy(book => book.ID)
            .Skip((CurrentPage - 1) * limit)
            .Take(limit);
    }

    private int GetCurrentPage()
    {
        var pageFromUrl = Request.QueryString["page"];
        int pageNum;
        var currPageNum = int.TryParse(pageFromUrl, out pageNum) ? pageNum : 1;
        return currPageNum > GetMaxPage() ? GetMaxPage() : currPageNum;
    }

    private int GetMaxPage()
    {
        var max = Math.Ceiling((decimal)_repository.Books.Count() / limit);
        return (int)max;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
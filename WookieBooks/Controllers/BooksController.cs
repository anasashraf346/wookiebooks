using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        List<Books> _oBooks = new List<Books>() {
        new Books(){ BookId=1,Title="Harry Potter",Description="Harry1 Potter is a series of seven fantasy novels",Author="J. K. Rowling",CoverImage="HarryPotter1.jpg",Price=10 },
        new Books(){ BookId=2,Title="Harry Potter2",Description="Harry2 Potter is a series of seven fantasy novels",Author="L. K. Rowling",CoverImage="HarryPotter2.jpg",Price=20 },
        new Books(){ BookId=3,Title="Harry Potter3",Description="Harry3 Potter is a series of seven fantasy novels",Author="M. K. Rowling",CoverImage="HarryPotter3.jpg",Price=30 },
        };
        [HttpGet]
        public IActionResult Gets()
        {
            if (_oBooks.Count == 0)
            {
                return NotFound("No List Found");
            }
            return Ok(_oBooks);
        }

        [HttpGet("GetBook")]
        public IActionResult Get(int BookId)
        {
            try
            {
                var oBook = _oBooks.SingleOrDefault(x => x.BookId == BookId);
                if (oBook == null)
                {
                    return NotFound("No Book Found");
                }
                return Ok(oBook);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Post(Books oBooks)
        {
            try
            {
                _oBooks.Add(oBooks);
                if (_oBooks.Count == 0)
                {
                    return NotFound("No Book Found");
                }
                return Ok(_oBooks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public IActionResult UpdateBook(Books oBooks)
        {
            try
            {
                var book = from r in _oBooks where r.BookId == oBooks.BookId select r;
                if (book.Count() == 0)
                {
                    return NotFound("Book not found");
                }
                book.First().Title = oBooks.Title;
                book.First().Description = oBooks.Description;
                book.First().Author = oBooks.Author;
                book.First().CoverImage = oBooks.CoverImage;
                book.First().Price = oBooks.Price;
                return Ok(_oBooks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public IActionResult DeleteBook(int BookId)
        {
            try
            {
                var oBook = _oBooks.SingleOrDefault(x => x.BookId == BookId);
                if (oBook == null)
                {
                    return NotFound("No Book Found");
                }
                _oBooks.Remove(oBook);
                if (_oBooks.Count == 0)
                {
                    return NotFound("No List Found");
                }
                return Ok(_oBooks);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksOnLoan.Data;
using BooksOnLoan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using System.Net.Mail;
using System.Net;


namespace BooksOnLoan.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Transactions.Include(p => p.Book)
            .OrderByDescending(o=> o.ReturnDate)
            .ThenBy(t=> t.AspNetUserId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: My Bookings
        public async Task<IActionResult> MyBookings()
        {
            //Get the actual user signed in by identity
            var id = User.Identity.Name;
            var applicationDbContext = _context.Transactions.Include(p => p.Book)
            .Where(w=> w.AspNetUserId == id)
            .OrderByDescending(o=> o.ReturnDate);
           
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Transaction/Details/5
        public async Task<IActionResult> Return(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trans = await _context.Transactions
                .FirstOrDefaultAsync(m => m.id == id);
            if (trans == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Transactions/Email/5
        public async Task<IActionResult> Email(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trans = await _context.Transactions.Include(p => p.Book)
                .FirstOrDefaultAsync(m => m.id == id);
            if (trans == null)
            {
                return NotFound();
            }

            return View(trans);
        }

        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReturnConfirmed(int? id, string action)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Get the transaction
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            if( action == "Return"){

                // Add the book back to the inventary
                var book = await _context.Book
                        .FirstOrDefaultAsync(m => m.CodeNumber == transaction.CodeNumber);
                if (book != null)
                {
                    book.Quantity++;
                    _context.Update(book);
                }
                //Remove transaction
                if (transaction != null)
                {
                    _context.Transactions.Remove(transaction);
                }

                await _context.SaveChangesAsync();  
            }else{
                try
                {
                   
                    ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                    var senderEmail = new MailAddress("lauraivettgonzalezalvarez@gmail.com", "Testing SMTP");  
                    var receiverEmail = new MailAddress("lauragonzalez@yahoo.com", "Receiver");  
                    var password = "Julaxixa999!";//"Jykse knph bewr cpwg";//"ztlqepxlpkbwspxj";  
                    var subject = "Subject test";  
                    var body = "Message test";  
                    var smtp = new SmtpClient {  
                        Host = "smtp.gmail.com",//"smtp.gmail.com,smtp.mail.gmail.com",  
                        Port = 587,  
                        EnableSsl = true,  
                        DeliveryMethod = SmtpDeliveryMethod.Network,  
                        UseDefaultCredentials = false,  
                        Credentials = new NetworkCredential(senderEmail.Address, password)  
                    };
                    using(var mess = new MailMessage(senderEmail, receiverEmail) {  
                    Subject = subject,  
                        Body = body  
                        }) {  
                            smtp.Send(mess);  
                        }  
                }
                catch (Exception ep)
                {
                    Console.WriteLine("failed to send email with the following error:");
                    System.Console.WriteLine(ep.InnerException);
                }
            }
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Email")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendEmail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Get the transaction
            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            try
            {
                ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                var senderEmail = new MailAddress("lauraivettgonzalezalvarez@gmail.com", "Testing SMTP");  
                var receiverEmail = new MailAddress("lauragonzalez@yahoo.com", "Receiver");  
                var password = "Julaxixa999!";//"Jykse knph bewr cpwg";//"ztlqepxlpkbwspxj";  
                var subject = "Subject test";  
                var body = "Message test";  
                var smtp = new SmtpClient {  
                    Host = "smtp.gmail.com",//"smtp.gmail.com,smtp.mail.gmail.com",  
                    Port = 587,  
                    EnableSsl = true,  
                    DeliveryMethod = SmtpDeliveryMethod.Network,  
                    UseDefaultCredentials = false,  
                    Credentials = new NetworkCredential(senderEmail.Address, password)  
                };
                using(var mess = new MailMessage(senderEmail, receiverEmail) {  
                Subject = subject,  
                    Body = body  
                    }) {  
                        smtp.Send(mess);  
                    }  
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                System.Console.WriteLine(ep.InnerException);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodeNumber,Author,Title,YearPublished,Quantity")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // GET: Book/Book/5
        public async Task<IActionResult> Book(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.CodeNumber == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Book")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.CodeNumber == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                book.Quantity--;
            }

            _context.Update(book);
            await _context.SaveChangesAsync();

            //Now populate transactions
            Transactions tr = new Transactions();
            tr.AspNetUserId = User.Identity.Name!;
            tr.CodeNumber = book.CodeNumber;
            tr.CheckoutDate = DateTime.Today.AddMonths(-2);
            tr.Quantity = 1;
            _context.Transactions.Add(tr);
            await _context.SaveChangesAsync();

            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodeNumber,Author,Title,YearPublished,Quantity")] Book book)
        {
            if (id != book.CodeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.CodeNumber))
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
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.CodeNumber == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.CodeNumber == id);
        }
    }
}

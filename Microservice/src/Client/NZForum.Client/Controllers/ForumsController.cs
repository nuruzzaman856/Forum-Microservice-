using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NZForum.Client.ApiServices;
using NZForum.Client.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NZForum.Client.Controllers
{
    [Authorize]
    public class ForumsController : Controller
    {
        private readonly IForumApiService _forumApiServices;

        public ForumsController(IForumApiService forumApiServices)
        {
            _forumApiServices = forumApiServices ?? throw new ArgumentNullException(nameof(forumApiServices));
        }

        // GET: Forums
        public async Task<IActionResult> Index()
        {
            await LogTokenAndClaims();
            return View(await _forumApiServices.GetForums());
        }

        public async Task LogTokenAndClaims()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            Debug.WriteLine($"Identity token: {identityToken}");

            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }
        }

        // GET: Forums/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var forum = await _context.Forum
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (forum == null)
            //{
            //    return NotFound();
            //}

            //return View(forum);
        }

        // GET: Forums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ImageUrl")] Forum forum)
        {
            throw new NotImplementedException();
            //if (ModelState.IsValid)
            //{
            //    forum.Id = Guid.NewGuid();
            //    _context.Add(forum);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(forum);
        }

        // GET: Forums/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var forum = await _context.Forum.FindAsync(id);
            //if (forum == null)
            //{
            //    return NotFound();
            //}
            //return View(forum);
        }

        // POST: Forums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,ImageUrl")] Forum forum)
        {
            throw new NotImplementedException();
            //if (id != forum.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(forum);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ForumExists(forum.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(forum);
        }

        // GET: Forums/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var forum = await _context.Forum
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (forum == null)
            //{
            //    return NotFound();
            //}

            //return View(forum);
        }

        // POST: Forums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            throw new NotImplementedException();
            //var forum = await _context.Forum.FindAsync(id);
            //_context.Forum.Remove(forum);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool ForumExists(Guid id)
        {
            throw new NotImplementedException();
            //return _context.Forum.Any(e => e.Id == id);
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}

using Core.Abstracts.Services.Data;
using Services01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace UI.WEB.Controllers
{
    public class NewsController : Controller
    {

        private IArticleService _service;
        public NewsController()
        {
            _service = ArticleService.Create();
        }


        // GET: News
        public async Task<ActionResult> Index(int page = 1, int per_page = 12)
        {
            return View(await _service.GetPagedArticles(page, per_page));
        }

        public async Task<ActionResult> Detail(string id)
        {
            return View(await _service.GetArticle(id));
        }

    }
}
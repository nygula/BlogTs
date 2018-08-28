using System.Linq;
using System.Web.Mvc;
using PagedList;
using TsBlog.AutoMapperConfig;
using TsBlog.Frontend.Extensions;
using TsBlog.Services;
using TsBlog.ViewModel.Post;

namespace TsBlog.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        public ActionResult Index(int? page)
        {
            ////如果未登录，则跳转到登录页面
            //if (Session["user_account"] == null)
            //{
            //    return RedirectToAction("login", "account");
            //}
            //return View();

            //var list = _postService.FindHomePagePosts();
            //var model = list.Select(x => x.ToModel().FormatPostViewModel());
            //return View(model);

            //var list = _postService.FindHomePagePosts();
            //读取分页数据,返回IPagedList<Post>
            page = page ?? 0;
            var list = _postService.FindPagedList(x => !x.IsDeleted && x.AllowShow, pageIndex: (int)page, pageSize: 10);
            var model = list.Select(x => x.ToModel().FormatPostViewModel());
            ViewBag.Pagination = new StaticPagedList<PostViewModel>(model, list.PageIndex, list.PageSize, list.TotalCount);
            return View(model);
        }

        public ActionResult Post()
        {
            //如果未登录，则跳转到登录页面
            if (Session["user_account"] == null)
            {
                return RedirectToAction("login", "account");
            }

            var post = _postService.FindById(1).ToModel();
            return View(post);
        }
    }
}

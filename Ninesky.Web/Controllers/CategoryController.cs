using Microsoft.AspNetCore.Mvc;
using Ninesky.Base;

namespace Ninesky.Web.Controllers
{
    /// <summary>
    /// 栏目控制器
    /// </summary>
    public class CategoryController : Controller
    {
        /// <summary>
        /// 数据上下文
        /// </summary>
        private NineskyDbContext _dbContext;

        /// <summary>
        /// 栏目服务
        /// </summary>
        private CategoryService _categoryService;

        public CategoryController(NineskyDbContext dbContext)
        {
            _dbContext = dbContext;
            _categoryService = new CategoryService(dbContext);
        }

        /// <summary>
        /// 查看栏目
        /// </summary>
        /// <param name="id">栏目Id</param>
        /// <returns></returns>
        [Route("/Category/{id:int}")]
        public IActionResult Index(int id)
        {
            var category = _categoryService.Find(id);
            if (category == null) return View("Error", new Models.Error { Title = "错误消息", Name = "栏目不存在", Description = "访问ID为【" + id + "】的栏目时发生错误，该栏目不存在。" });
            switch (category.Type)
            {
                case CategoryType.General:
                    if (category.General == null) return View("Error", new Models.Error { Title = "错误消息", Name = "栏目数据不完整", Description = "找不到栏目【" + category.Name + "】的详细数据。" });
                    return View(category.General.View, category);
                case CategoryType.Page:
                    if (category.Page == null) return View("Error", new Models.Error { Title = "错误消息", Name = "栏目数据不完整", Description = "找不到栏目【" + category.Name + "】的详细数据。" });
                    return View(category.Page.View, category);
                case CategoryType.Link:
                    if (category.Link == null) return View("Error", new Models.Error { Title = "错误消息", Name = "栏目数据不完整", Description = "找不到栏目【" + category.Name + "】的详细数据。" });
                    return Redirect(category.Link.Url);
                default:
                    return View("Error", new Models.Error { Title = "错误消息", Name = "栏目数据错误", Description = "栏目【" + category.Name + "】的类型错误。" });

            }
        }
    }
}
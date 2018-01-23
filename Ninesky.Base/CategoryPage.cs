using System.ComponentModel.DataAnnotations;

namespace Ninesky.Base
{
    public class CategoryPage
    {
        [Key]
        public int PageId { get; set; }

        /// <summary>
        /// 栏目ID
        /// </summary>
        [Required]
        [Display(Name = "栏目ID")]
        public int CategoryId { get; set; }

        /// <summary>
        /// 栏目内容
        /// </summary>
        [Required]
        [StringLength(10000)]
        [Display(Name = "栏目内容")]
        public string Content { get; set; }

        /// <summary>
        /// 栏目视图
        /// </summary>
        [Required]
        [StringLength(200)]
        [Display(Name = "栏目视图")]
        public string View { get; set; }

        /// <summary>
        /// 栏目
        /// </summary>
        public virtual Category Category { get; set; }

        public CategoryPage()
        {
            View = "Index";
        }
    }
}
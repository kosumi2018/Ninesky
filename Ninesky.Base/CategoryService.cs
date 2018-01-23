using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ninesky.DataLibrary;

namespace Ninesky.Base
{
    /// <summary>
    /// 栏目服务类
    /// </summary>
    public class CategoryService
    {
        private BaseRepository<Category> _baseRepository;
        public CategoryService(DbContext dbContext)
        {
            _baseRepository = new BaseRepository<Category>(dbContext);
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="Id">栏目Id</param>
        /// <returns></returns>
        public Category Find(int Id)
        {
            return _baseRepository.Find(Id);
        }
    }
}

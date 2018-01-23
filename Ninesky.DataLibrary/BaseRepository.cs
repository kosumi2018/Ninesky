using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ninesky.DataLibrary
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    public class BaseRepository<T> where T : class
    {
        private DbContext _dbContext;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="Id">主键</param>
        /// <returns>实体</returns>
        public T Find(int Id)
        {
            return _dbContext.Set<T>().Find(Id);
        }
    }
}
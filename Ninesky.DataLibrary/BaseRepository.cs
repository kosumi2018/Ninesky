﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        /// <param name="keyValue">主键</param>
        /// <returns>实体</returns>
        public virtual T Find(params object[] keyValue)
        {
            return _dbContext.Set<T>().Find(keyValue);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">查询表达式</param>
        /// <returns>实体</returns>
        public virtual T Find(Expression<Func<T, bool>> predicate)
        {
            return Find(null, predicate);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="includeParams">导航属性</param>
        /// <param name="predicate">查询表达式</param>
        /// <returns>实体</returns>
        public virtual T Find(string[] includeParams, Expression<Func<T, bool>> predicate)
        {
            var queryable = _dbContext.Set<T>().AsQueryable();
            if (includeParams != null)
            {
                foreach (string param in includeParams)
                {
                    queryable = queryable.Include(param);
                }
            }
            return queryable.SingleOrDefault(predicate);
        }
    }
}
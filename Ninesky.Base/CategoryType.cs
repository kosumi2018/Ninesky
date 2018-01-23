﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ninesky.Base
{
    /// <summary>
       /// 栏目类型
       /// </summary>
       public enum CategoryType
       {
          [Display(Name = "常规栏目")]
          General,
          [Display(Name = "单页栏目")]
          Page,
          [Display(Name = "链接栏目")]
          Link
      }
}

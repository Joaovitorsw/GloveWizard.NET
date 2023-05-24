using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloveWizard.Domain.Helpers
{
    public class PaginationFilter
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 30;
    }
}

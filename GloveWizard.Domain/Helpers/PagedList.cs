using GloveWizard.Domain.Utils.ResponseViewModel;
using GloveWizard.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloveWizard.Domain.Helpers
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IEnumerable<T> currentPage, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            TotalCount = count;
            AddRange(currentPage);
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public static async Task<PaginationResponse<IEnumerable<T>>> CreateAsync(
            IQueryable<T> source,
            int currentPage,
            int pageSize
        )
        {
            var count = await source.CountAsync();
            var items = await source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            PagedList<T> pagedList = new PagedList<T>(items, count, currentPage, pageSize);

            return new PaginationResponse<IEnumerable<T>>(
                currentPage,
                pagedList.PageSize,
                pagedList.TotalCount,
                pagedList.TotalPages,
                pagedList.AsEnumerable().ToList()
            );
        }
    }
}

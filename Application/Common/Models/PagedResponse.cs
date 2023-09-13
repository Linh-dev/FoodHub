using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models;

public class PagedResponse<T> : Response<T>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int? PageCount { get; set; }
    public int? TotalRecordCount { get; set; }

    public PagedResponse(T data, int? pageNumber, int? pageSize, int? pageCount = null, int? totalRecordCount = null, string? message = null)
        : base(true, Array.Empty<string>())
    {
        this.PageNumber = pageNumber;
        this.PageSize = pageSize;
        this.Data = data;
        this.Message = message;
        this.PageCount = pageCount;
        this.TotalRecordCount = totalRecordCount;
    }
}

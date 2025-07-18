﻿using SilverCart.Domain.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Commons.Paginations;
public static class PaginationUtils
{
    public static (int page, int pageSize, SortOrder sortType, string sortField) GetPaginationAndSortingValues(PagingRequest? request)
    {
        var page = request?.Page ?? 1;
        var pageSize = request?.PageSize ?? 10;
        var sortType = request?.SortType ?? SortOrder.Descending;
        var sortField = request?.ColName ?? "CreationDate"; // Default sorting field, can be changed to any field in the entity

        return (page, pageSize, sortType, sortField);
    }
}
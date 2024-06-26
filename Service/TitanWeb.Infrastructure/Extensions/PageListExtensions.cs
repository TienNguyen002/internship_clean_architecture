﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using TitanWeb.Domain.Collections;
using TitanWeb.Domain.Contracts;

namespace TitanWeb.Infrastructure.Extensions
{
    public static class PagedListExtensions
    {
        //public static string GetOrderExpression(
        //    this IPagingParams pagingParams,
        //    string defaultColumn = "")
        //{
        //    var column = string.IsNullOrWhiteSpace(pagingParams.SortColumn)
        //        ? defaultColumn
        //        : pagingParams.SortColumn;

        //    var order = "ASC".Equals(
        //        pagingParams.SortOrder, StringComparison.OrdinalIgnoreCase)
        //        ? pagingParams.SortOrder : "DESC";

        //    return $"{column} {order}";
        //}

        public static async Task<IPagedList<T>> ToPagedListAsync<T>(
            this IQueryable<T> source,
            IPagingParams pagingParams,
            CancellationToken cancellationToken = default)
        {
            var totalCount = await source.CountAsync(cancellationToken);
            var items = await source
                //.OrderBy(pagingParams.GetOrderExpression())
                .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                .Take(pagingParams.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedList<T>(
                items,
                pagingParams.PageNumber,
                pagingParams.PageSize,
                totalCount);
        }

        public static async Task<IPagedList<T>> ToPagedListAsync<T>(
            this IQueryable<T> source,
            int pageNumber = 1,
            int pageSize = 10,
            string sortColumn = "",
            string sortOrder = "",
            CancellationToken cancellationToken = default)
        {
            var totalCount = await source.CountAsync(cancellationToken);
            var item = await source
                .OrderBy($"{sortColumn} {sortOrder}")
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PagedList<T>(item, pageNumber, pageSize, totalCount);
        }
    }
}

﻿using TitanWeb.Domain.Contracts;

namespace TitanWeb.Domain.Collections
{
    public class PaginationResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public PagingMetadata Metadata { get; set; }

        public PaginationResult(IPagedList<T> pagedList)
        {
            Items = pagedList;
            Metadata = new PagingMetadata(pagedList);
        }
    }
}

using Domain.Entities;
using Domain.Pagination;
using Domain.QueryParams;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using System;
using System.Linq;

namespace DataAccess.Repositories
{
    public class ProductItemRepository : GenericRepository<ProductItem>, IProductItemRepository
    {
        public ProductItemRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ProductItem GetById(long id)
        {
            return FindAll().Include(x => x.Supplier).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public PagedList<ProductItem> GetProductItems(ProductItemParameters parameters)
        {
            var productItemList = FindAll();
            if (parameters.MaxManufacturingYear != 0 && parameters.MinManufacturingYear != 0)
            {
                SearchByYear(ref productItemList, parameters.MaxManufacturingYear, parameters.MinManufacturingYear);
            }

            SearchByDescription(ref productItemList, parameters.Description);

            return PagedList<ProductItem>.ToPagedList(productItemList,
                parameters.PageNumber, parameters.PageSize);
        }

        private void SearchByYear(ref IQueryable<ProductItem> productItemList, uint maxYear, uint minYear)
        {
            if (!productItemList.Any())
                return;

            productItemList = FindByCondition(o => o.ManufacturingDate.Value.Year >= minYear &&
                                o.ManufacturingDate.Value.Year <= maxYear);
        }

        private void SearchByDescription(ref IQueryable<ProductItem> productItemList, string description)
        {
            if (!productItemList.Any() || string.IsNullOrWhiteSpace(description))
                return;

            productItemList = productItemList.Where(o => o.Description.ToLower().Equals(description.Trim().ToLower()));
        }


    }
}

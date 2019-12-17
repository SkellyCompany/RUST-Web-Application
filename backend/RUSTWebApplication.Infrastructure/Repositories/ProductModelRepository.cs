using System.Linq;
using Microsoft.EntityFrameworkCore;
using RUSTWebApplication.Core.DomainService;
using RUSTWebApplication.Core.Entity.Filters;
using RUSTWebApplication.Core.Entity.Product;

namespace RUSTWebApplication.Infrastructure.Repositories
{
    public class ProductModelRepository: IProductModelRepository
    {
        private readonly RUSTWebApplicationContext _ctx;


        public ProductModelRepository(RUSTWebApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public ProductModel Create(ProductModel newProductModel)
        {
            _ctx.ProductModels.Attach(newProductModel).State = EntityState.Added;
            _ctx.SaveChanges();
            return newProductModel;
        }

        public ProductModel Read(int productModelId)
        {
            return _ctx.ProductModels.AsNoTracking().Include(pm => pm.ProductCategory).Include(pm => pm.Products).ThenInclude(p => p.ProductStocks).ThenInclude(ps => ps.ProductSize).ThenInclude(ps => ps.ProductMetric).FirstOrDefault(pm => pm.Id == productModelId);
        }

        public FilteredList<ProductModel> ReadAll(ProductModelFilter filter)
        {
			FilteredList<ProductModel> filteredList = new FilteredList<ProductModel>();
			if (filter.CurrentPage == 0 && filter.ItemsPerPage == 0)
			{
				filteredList.Data = _ctx.ProductModels.AsNoTracking();
				return filteredList;
			}
			else
			{
				if (filter.CategoryType == CategoryType.Default)
				{
					filteredList.Data = _ctx.ProductModels.AsNoTracking()
						.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);

					if (_ctx.ProductModels.Count() % filter.ItemsPerPage != 0)
					{
						filteredList.TotalPages = (_ctx.ProductModels.Count() / filter.ItemsPerPage) + 1;
					}
					else
					{
						filteredList.TotalPages = _ctx.ProductModels.Count() / filter.ItemsPerPage;
					}
				}
				else
				{
					filteredList.Data = _ctx.ProductModels.AsNoTracking().Where(pm => pm.ProductCategory.Name.Equals(filter.CategoryType.ToString()))
						.Skip((filter.CurrentPage - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);

					int totalFilteredProductModels = _ctx.ProductModels.Where(pm => pm.ProductCategory.Name.Equals(filter.CategoryType.ToString())).Count();
					if (totalFilteredProductModels % filter.ItemsPerPage != 0)
					{
						filteredList.TotalPages = (totalFilteredProductModels / filter.ItemsPerPage) + 1;
					}
					else
					{
						filteredList.TotalPages = totalFilteredProductModels / filter.ItemsPerPage;
					}
				}
			}

			return filteredList;
		}

        public ProductModel Update(ProductModel updatedProductModel)
        {
            _ctx.ProductModels.Attach(updatedProductModel).State = EntityState.Modified;
            _ctx.Entry(updatedProductModel).Reference(pm => pm.ProductCategory).IsModified = true;
            _ctx.SaveChanges();
            return updatedProductModel;
        }

        public ProductModel Delete(int productModelId)
        {
            var productModelToDelete = _ctx.ProductModels.FirstOrDefault(pm => pm.Id == productModelId);
            _ctx.ProductModels.Remove(productModelToDelete);
            _ctx.SaveChanges();
            return productModelToDelete;
        }
    }
}
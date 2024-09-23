using FlixOne.Web.Models;
using FlixOne.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace FlixOne.Web.Common {
    public static class Extension {
        public static Product ToProduct(this ProductViewModel productVM) {
            return new Product {
                Id = productVM.ProductId,
                Name = productVM.ProductName,
                Description = productVM.ProductDescription,
                Price = productVM.ProductPrice,
                CategoryId = productVM.CategoryId,
            };
        }

        public static ProductViewModel ToProductVM(this Product product) {
            return new ProductViewModel {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductImage = product.Image,
                ProductPrice = product.Price,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                CategoryDescription = product.Category.Description,
            };
        }

        public static IEnumerable<Product> ToProduct(this IEnumerable<ProductViewModel> productVMs) {
            return productVMs.Select(ToProduct).ToList();
        }

        public static IEnumerable<ProductViewModel> ToProductVM(this IEnumerable<Product> products) {
            return products.Select(ToProductVM).ToList();
        }
    }
}

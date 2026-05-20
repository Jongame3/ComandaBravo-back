using ComBravo.DataAccess.Context;
using ComBravo.Domains.Entities.Product;
using ComBravo.Domains.Models.Base;
using ComBravo.Domains.Models.Product;
using AutoMapper;
using ComBravo.Domains.Models.User;

namespace ComBravo.BusinessLogic.Core.Product
{
    public class ProductActions
    {

        protected List<ProductDto> ExecuteGetAllProductsAction()
        {
            var products = new List<ProductDto>();
            List<ProductData> pData;
            using (var db = new ProductContext())
            {
                pData = db.Products.ToList();
            }
            foreach (var product in pData)
            {
                var product_ = new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Duration = product.Duration
                };

                products.Add(product_);
            }
            return products;
        }

        protected ProductDto ExecuteGetProductByIDAction(int id)
        {
            ProductData? product;
            using (var db = new ProductContext())
            {
                product = db.Products.FirstOrDefault(x => x.Id == id);
            }

            if (product == null)
            {
                return null;
            }
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Duration = product.Duration
            };
        }

        protected ResponseMsg ExecuteProductCreateAction(ProductDto product)
        {
            ProductData pData;
            using (var db = new ProductContext())
            {
                pData = db.Products.FirstOrDefault(x => x.Name.Equals(product.Name));
            }

            if (pData != null)
            {
                return new ResponseMsg() { IsSucces = false, Message = "Product with same name already exists" };
            }

            var plocalData = new ProductData
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Duration = product.Duration
            };

            using (var db = new ProductContext())
            {
                db.Products.Add(plocalData);
                db.SaveChanges();
            }
            return new ResponseMsg()
            {
                IsSucces = true,
                Message = "Product was succesfully added"
            };
        }

        protected ResponseMsg ExecuteProductUpdateAction(ProductDto product)
        {
            using (var db = new ProductContext())
            {
                var pData = db.Products.FirstOrDefault(x => x.Id == product.Id);
                
                if (pData == null)
                {
                    return new ResponseMsg() { IsSucces = false, Message = "This user does not exist" };
                }

                pData.Name = product.Name;
                pData.Price = product.Price;
                pData.Duration = product.Duration;
                pData.Description = product.Description;

                db.SaveChanges();
            }
            return new ResponseMsg() { IsSucces = true, Message = "Product was updated" };
        }

        protected ResponseMsg ExecuteProductDeleteAction(int id)
        {
            using (var db = new ProductContext())
            {
                var pData = db.Products.FirstOrDefault(x => x.Id == id);

                if (pData == null)
                {
                    return new ResponseMsg() { IsSucces = false, Message = "There's no product with this id" };
                }

                db.Products.Remove(pData);
                db.SaveChanges();
            }
            return new ResponseMsg() { IsSucces = true, Message = "Succesfully deleted Product" };
        }
    }
}

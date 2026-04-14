using ComBravoControl.BusinessLogic.Core.Product;
using ComBravoControl.BusinessLogic.Interface;
using ComBravoControl.Domains.Models.Base;
using ComBravoControl.Domains.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravoControl.BusinessLogic.Functions.Product
{
    public class ProductFlow : ProductActions, IProductActions
    {
        public List<ProductDto> GetAllProductAction()
        {
            return ExecuteGetAllProductsAction();
        }

        public ProductDto GetProudctByIdAction(int id)
        {
            return GetProudctByIdAction(id);
        }

        public ResponseMsg ResponseProductCreateAction(ProductDto product)
        {
            return ExecuteProductCreateAction(product);
        }

        public ResponseMsg ResponseProductDeleteAction(int id)
        {
            return ExecuteProductDeleteAction(id);
        }

        public ResponseMsg ResponseProductUpdateAction(ProductDto product)
        {
            return ExecuteProductUpdateAction(product);
        }
    }
}

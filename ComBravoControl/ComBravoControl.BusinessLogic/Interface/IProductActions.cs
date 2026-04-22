using ComBravo.Domains.Models.Base;
using ComBravo.Domains.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravo.BusinessLogic.Interface
{
    public interface IProductActions
    {
        List<ProductDto> GetAllProductAction();
        ProductDto GetProudctByIdAction(int id);
        ResponseMsg ResponseProductCreateAction(ProductDto product);
        ResponseMsg ResponseProductUpdateAction(ProductDto product);
        ResponseMsg ResponseProductDeleteAction(int id);
    }
}

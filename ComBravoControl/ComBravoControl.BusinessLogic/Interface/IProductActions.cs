using ComBravoControl.Domains.Models.Base;
using ComBravoControl.Domains.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComBravoControl.BusinessLogic.Interface
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

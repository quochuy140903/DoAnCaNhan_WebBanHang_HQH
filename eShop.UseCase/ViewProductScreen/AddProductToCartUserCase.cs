using WebBanHang_QuocHuy.UseCase.PluginInterface.DataStore;
using WebBanHang_QuocHuy.UseCase.PluginInterface.StateStore;
using WebBanHang_QuocHuy.UseCase.PluginInterface.UI;
using WebBanHang_QuocHuy.UseCase.ViewProductScreen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBanHang_QuocHuy.UseCase.ViewProductScreen
{
    public class AddProductToCartUserCase : IAddProductToCartUserCase
    {
        //khai báo
        private readonly IProductRepository _productRepository;
        private readonly IShopingCart _shopingCart;
        private readonly IShoppingCartStateStore _shoppingCartStateStore;

        public AddProductToCartUserCase(IProductRepository productRespository, IShopingCart shopingCart,IShoppingCartStateStore shoppingCartStateStore)
        {
            this._productRepository = productRespository;
            this._shopingCart = shopingCart;
            this._shoppingCartStateStore = shoppingCartStateStore;
        }
        public async void Execute(int productId)
        {
            //khởi tạo product
            var product = _productRepository.GetProductById(productId);
            await _shopingCart.AddProductAsync(product);

            this._shoppingCartStateStore.UpdateLineItemsCount();
        }
    }
}

using WebBanHang_QuocHuy.CoreBusiness.Model;
using WebBanHang_QuocHuy.UseCase.PluginInterface.UI;
using WebBanHang_QuocHuy.UseCase.ShoppingCartScreen.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBanHang_QuocHuy.UseCase.ShoppingCartScreen
{
    public class ViewShoppingCartUserCase : IViewShoppingCartUserCase
    {
        //khai báo
        private readonly IShopingCart _shoppingCart;

        //khởi tạo
        public ViewShoppingCartUserCase(IShopingCart shopingCart)
        {
            this._shoppingCart = shopingCart;
        }
        public Task<Order> Execute()
        {
            return _shoppingCart.GetOrderAsync();
        }
    }
}

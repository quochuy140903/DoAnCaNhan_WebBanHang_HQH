using WebBanHang_QuocHuy.CoreBusiness.Model;

namespace WebBanHang_QuocHuy.UseCase.ShoppingCartScreen.Interfaces
{
    public interface IUpdateQuantityUserCase
    {
        Task<Order> Execute(int productId, int quatity);
    }
}
using WebBanHang_QuocHuy.CoreBusiness.Model;

namespace WebBanHang_QuocHuy.UseCase.OrderConfirmScreen
{
    public interface IViewOrderConfirmUserCase
    {
        Order Execute(string uniqueId);
    }
}
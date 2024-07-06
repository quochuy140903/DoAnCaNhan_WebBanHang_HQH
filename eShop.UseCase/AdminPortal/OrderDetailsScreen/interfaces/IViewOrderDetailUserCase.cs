using WebBanHang_QuocHuy.CoreBusiness.Model;

namespace WebBanHang_QuocHuy.UseCase.AdminPortal.OrderDetailsScreen.interfaces
{
    public interface IViewOrderDetailUserCase
    {
        Order Execute(int orderId);
    }
}
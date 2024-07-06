using WebBanHang_QuocHuy.CoreBusiness.Model;

namespace WebBanHang_QuocHuy.UseCase.AdminPortal.OutStandingOrderScreen
{
    public interface IViewOutStandingOrderUserCase
    {
        IEnumerable<Order> Execute();
    }
}
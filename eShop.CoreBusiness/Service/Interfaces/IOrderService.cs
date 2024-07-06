using WebBanHang_QuocHuy.CoreBusiness.Model;

namespace WebBanHang_QuocHuy.CoreBusiness.Service.Interfaces
{
    public interface IOrderService
    {
        bool ValidateCreateOrder(Order order);
        bool ValidateCustomerInfomation(string name, string address, string city, string provice, string country);
        bool ValidateProcessOrder(Order order);
        bool ValidateUpdateOrder(Order order);
    }
}
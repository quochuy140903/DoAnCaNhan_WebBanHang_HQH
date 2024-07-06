using WebBanHang_QuocHuy.CoreBusiness.Model;
using WebBanHang_QuocHuy.UseCase.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBanHang_QuocHuy.UseCase.OrderConfirmScreen
{
    public class ViewOrderConfirmUserCase : IViewOrderConfirmUserCase
    {
        private readonly IOrderRespository _oderRepository;
        public ViewOrderConfirmUserCase(IOrderRespository orderRespository)
        {
            this._oderRepository = orderRespository;
        }
        public Order Execute(string uniqueId)
        {
            return _oderRepository.GetOrderByUniqueId(uniqueId);
        }
    }
}

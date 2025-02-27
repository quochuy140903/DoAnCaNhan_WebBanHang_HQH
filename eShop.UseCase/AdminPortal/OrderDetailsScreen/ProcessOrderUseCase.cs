﻿using WebBanHang_QuocHuy.CoreBusiness.Service.Interfaces;
using WebBanHang_QuocHuy.UseCase.AdminPortal.OrderDetailsScreen.interfaces;
using WebBanHang_QuocHuy.UseCase.PluginInterface.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBanHang_QuocHuy.UseCase.AdminPortal.OrderDetailsScreen
{
    public class ProcessOrderUseCase : IProcessOrderUseCase
    {
        private readonly IOrderRespository _orderRespository;
        private readonly IOrderService _orderService;
        public ProcessOrderUseCase(IOrderRespository orderRespository, IOrderService orderService)
        {
            this._orderRespository = orderRespository;
            this._orderService = orderService;
        }
        public bool Execute(int orderId, string adminUserName)
        {
            var order = _orderRespository.GetOrder(orderId);
            order.AdminUser = adminUserName;
            order.DateProcessed = DateTime.Now;
            if (_orderService.ValidateProcessOrder(order))
            {
                _orderRespository.UpdateOrder(order);
                return true;
            }
            return false;
        }
    }
}

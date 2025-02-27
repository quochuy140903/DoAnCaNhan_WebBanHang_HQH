﻿using WebBanHang_QuocHuy.CoreBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBanHang_QuocHuy.UseCase.PluginInterface.DataStore
{
    public interface IOrderRespository
    {
        Order GetOrder(int id);
        Order GetOrderByUniqueId(string uniqueId);
        int CreateOrder (Order order);
        void UpdateOrder(Order order);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOutstandingOrders();
        IEnumerable<Order> GetProcessedOrders();
        IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId);
    }
}

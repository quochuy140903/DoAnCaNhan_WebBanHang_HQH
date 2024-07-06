using WebBanHang_QuocHuy.CoreBusiness.Service;
using WebBanHang_QuocHuy.CoreBusiness.Service.Interfaces;
using WebBanHang_QuocHuy.DataStore.HardCodes.Helper;

//using eShop.DataStore.HardCode;
using WebBanHang_QuocHuy.DataStore.SQL.Dapper;
using WebBanHang_QuocHuy.ShopingCart.LocalStorage;
using WebBanHang_QuocHuy.StateStore.DI;
using WebBanHang_QuocHuy.UseCase.AdminPortal.OrderDetailsScreen;
using WebBanHang_QuocHuy.UseCase.AdminPortal.OrderDetailsScreen.interfaces;
using WebBanHang_QuocHuy.UseCase.AdminPortal.OutStandingOrderScreen;
using WebBanHang_QuocHuy.UseCase.AdminPortal.ProcessedOrderScreen;
using WebBanHang_QuocHuy.UseCase.OrderConfirmScreen;
using WebBanHang_QuocHuy.UseCase.PluginInterface.DataStore;
using WebBanHang_QuocHuy.UseCase.PluginInterface.StateStore;
using WebBanHang_QuocHuy.UseCase.PluginInterface.UI;
using WebBanHang_QuocHuy.UseCase.SearchProductScreen;
using WebBanHang_QuocHuy.UseCase.ShoppingCartScreen;
using WebBanHang_QuocHuy.UseCase.ShoppingCartScreen.Interfaces;
using WebBanHang_QuocHuy.UseCase.ViewProductScreen;
using WebBanHang_QuocHuy.UseCase.ViewProductScreen.Interfaces;
using WebBanHang_QuocHuy.Web.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

//Add services for auth
builder.Services.AddControllers();
builder.Services.AddAuthentication("eShop.CookieAuth").AddCookie("eShop.CookieAuth", config =>
{
    config.Cookie.Name = "eShop.CookieAuth";
    config.LoginPath = "/authenticate";
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
//tồn tại trong dự án chuyển sang AddTransient từ AddSingleton
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<IOrderRespository, OrderRepository>();
builder.Services.AddTransient<IDataAccess>(sp=>new DataAccess(builder.Configuration.GetConnectionString("Default")));
//chỉ 1 user view cart
builder.Services.AddScoped<IShopingCart, ShopingCart>();
builder.Services.AddScoped<IShoppingCartStateStore, ShoppingCartStateStore>();

//gọi 1 lần
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
builder.Services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
builder.Services.AddTransient<IAddProductToCartUserCase, AddProductToCartUserCase>();
builder.Services.AddTransient<IViewShoppingCartUserCase,ViewShoppingCartUserCase>();
builder.Services.AddTransient<IDeleteProductUserCase, DeleteProductUserCase>();
builder.Services.AddTransient<IUpdateQuantityUserCase, UpdateQuantityUserCase>();
builder.Services.AddTransient<IPlaceOrderUserCase, PlaceOrderUserCase>();
builder.Services.AddTransient<IViewOrderConfirmUserCase, ViewOrderConfirmUserCase>();

builder.Services.AddTransient<IViewOutStandingOrderUserCase,ViewOutStandingOrderUserCase>();
builder.Services.AddTransient<IViewOrderDetailUserCase, ViewOrderDetailUserCase>();
builder.Services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();
builder.Services.AddTransient<IViewPrcessedOrderUserCase, ViewPrcessedOrderUserCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

// xác thực & phân quyền
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

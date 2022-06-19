using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Authentication;
using Business.Repositories.EmailParameterRepository;
using Business.Repositories.OperationClaimRepository;
using Business.Repositories.UserOperationClaimRepository;
using Business.Repositories.UserRepository;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Repositories.EmailParameterRepository;
using DataAccess.Repositories.OperationClaimRepository;
using DataAccess.Repositories.UserOperationClaimRepository;
using Business.Repositories.BasketRepository;
using DataAccess.Repositories.BasketRepository;
using Business.Repositories.CustomerRelationshipRepository;
using DataAccess.Repositories.CustomerRelationshipRepository;
using Business.Repositories.CustomerRepository;
using DataAccess.Repositories.CustomerRepository;
using Business.Repositories.OrderDetailRepository;
using DataAccess.Repositories.OrderDetailRepository;
using Business.Repositories.OrderRepository;
using DataAccess.Repositories.OrderRepository;
using Business.Repositories.PriceListDetailRepository;
using DataAccess.Repositories.PriceListDetailRepository;
using Business.Repositories.PriceListRepository;
using DataAccess.Repositories.PriceListRepository;
using Business.Repositories.ProductImageRepository;
using DataAccess.Repositories.ProductImageRepository;
using Business.Repositories.ProductRepository;
using DataAccess.Repositories.ProductRepository;
using DataAccess.Repositories.UserRepository;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<EmailParameterManager>().As<IEmailParameterService>();
            builder.RegisterType<EfEmailParameterDal>().As<IEmailParameterDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<TokenHandler>().As<ITokenHandler>();

            builder.RegisterType<BasketManager>().As<IBasketService>().SingleInstance();
            builder.RegisterType<EfBasketDal>().As<IBasketDal>().SingleInstance();

            builder.RegisterType<CustomerRelationshipManager>().As<ICustomerRelationshipService>().SingleInstance();
            builder.RegisterType<EfCustomerRelationshipDal>().As<ICustomerRelationshipDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>().SingleInstance();
            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();

            builder.RegisterType<PriceListDetailManager>().As<IPriceListDetailService>().SingleInstance();
            builder.RegisterType<EfPriceListDetailDal>().As<IPriceListDetailDal>().SingleInstance();

            builder.RegisterType<PriceListManager>().As<IPriceListService>().SingleInstance();
            builder.RegisterType<EfPriceListDal>().As<IPriceListDal>().SingleInstance();

            builder.RegisterType<ProductImageManager>().As<IProductImageService>().SingleInstance();
            builder.RegisterType<EfProductImageDal>().As<IProductImageDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}

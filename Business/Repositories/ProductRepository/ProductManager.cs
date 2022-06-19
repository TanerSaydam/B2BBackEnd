using Business.Aspects.Secured;
using Business.Repositories.PriceListDetailRepository;
using Business.Repositories.ProductImageRepository;
using Business.Repositories.ProductRepository.Constants;
using Business.Repositories.ProductRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.ProductRepository;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.ProductRepository
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IProductImageService _productImageService;
        private readonly IPriceListDetailService _priceListDetailService;

        public ProductManager(IProductDal productDal, IProductImageService productImageService, IPriceListDetailService priceListDetailService)
        {
            _productDal = productDal;
            _productImageService = productImageService;
            _priceListDetailService = priceListDetailService;
        }

        //[SecuredAspect("admin,prdocut.add")]
        [ValidationAspect(typeof(ProductValidator))]
        [RemoveCacheAspect("IProductService.Get")]

        public async Task<IResult> Add(Product product)
        {
            await _productDal.Add(product);
            return new SuccessResult(ProductMessages.Added);
        }

        [SecuredAspect("admin,prdocut.update")]
        [ValidationAspect(typeof(ProductValidator))]
        [RemoveCacheAspect("IProductService.Get")]

        public async Task<IResult> Update(Product product)
        {
            await _productDal.Update(product);
            return new SuccessResult(ProductMessages.Updated);
        }

        //[SecuredAspect("admin,prdocut.delete")]
        [RemoveCacheAspect("IProductService.Get")]

        public async Task<IResult> Delete(Product product)
        {
            var images = await _productImageService.GetListByProductId(product.Id);
            foreach (var image in images)
            {
                await _productImageService.Delete(image);
            }

            var priceListProducts = await _priceListDetailService.GetListByProductId(product.Id);
            foreach (var item in priceListProducts)
            {
                await _priceListDetailService.Delete(item);
            }

            await _productDal.Delete(product);
            return new SuccessResult(ProductMessages.Deleted);
        }

        //[SecuredAspect("admin,prdocut.get")]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<Product>>> GetList()
        {
            return new SuccessDataResult<List<Product>>(await _productDal.GetAll());
        }

        //[SecuredAspect("admin,prdocut.get")]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<ProductListDto>>> GetProductList(int customerId)
        {
            return new SuccessDataResult<List<ProductListDto>>(await _productDal.GetProductList(customerId));
        }

        [SecuredAspect("admin,prdocut.get")]
        public async Task<IDataResult<Product>> GetById(int id)
        {
            return new SuccessDataResult<Product>(await _productDal.Get(p => p.Id == id));
        }

    }
}

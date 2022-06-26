using Business.Abstract;
using Business.Aspects.Secured;
using Business.Repositories.ProductImageRepository.Constants;
using Business.Repositories.ProductImageRepository.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.ProductImageRepository;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.ProductImageRepository
{
    public class ProductImageManager : IProductImageService
    {
        private readonly IProductImageDal _productImageDal;
        private readonly IFileService _fileService;

        public ProductImageManager(IProductImageDal productImageDal, IFileService fileService)
        {
            _productImageDal = productImageDal;
            _fileService = fileService;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(ProductImageValidator))]
        [RemoveCacheAspect("IProductImageService.Get")]

        public async Task<IResult> Add(ProductImageAddDto productImageAddDto)
        {
            foreach (var image in productImageAddDto.Images)
            {
                IResult result = BusinessRules.Run(
    CheckIfImageExtesionsAllow(image.FileName),
    CheckIfImageSizeIsLessThanOneMb(image.Length)
    );

                if (result == null)
                {
                    string fileName = _fileService.FileSaveToFtp(image);

                    ProductImage productImage = new()
                    {
                        Id = 0,
                        ImageUrl = fileName,
                        ProductId = productImageAddDto.ProductId,
                        IsMainImage = false
                    };

                    await _productImageDal.Add(productImage);
                }
            }

            return new SuccessResult(ProductImageMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(ProductImageValidator))]
        [RemoveCacheAspect("IProductImageService.Get")]

        public async Task<IResult> Update(ProductImageUpdateDto productImageUpdateDto)
        {
            IResult result = BusinessRules.Run(
    CheckIfImageExtesionsAllow(productImageUpdateDto.Image.FileName),
    CheckIfImageSizeIsLessThanOneMb(productImageUpdateDto.Image.Length)
    );

            if (result != null)
            {
                return result;
            }

            string path = @"./Content/img/" + productImageUpdateDto.ImageUrl;

            _fileService.FileDeleteToServer(path);

            string fileName = _fileService.FileSaveToServer(productImageUpdateDto.Image, "./Content/img/");

            ProductImage productImage = new()
            {
                Id = productImageUpdateDto.Id,
                ImageUrl = fileName,
                ProductId = productImageUpdateDto.ProductId,
                IsMainImage = productImageUpdateDto.IsMainImage
            };

            await _productImageDal.Update(productImage);
            return new SuccessResult(ProductImageMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IProductImageService.Get")]

        public async Task<IResult> Delete(ProductImage productImage)
        {
            string path = productImage.ImageUrl;

            _fileService.FileDeleteToFtp(path);

            await _productImageDal.Delete(productImage);
            return new SuccessResult(ProductImageMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<ProductImage>>> GetList()
        {
            return new SuccessDataResult<List<ProductImage>>(await _productImageDal.GetAll());
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<ProductImage>>> GetListByProductId(int productId)
        {
            return new SuccessDataResult<List<ProductImage>>(await _productImageDal.GetAll(p => p.ProductId == productId));
        }

        [SecuredAspect()]
        public async Task<IDataResult<ProductImage>> GetById(int id)
        {
            return new SuccessDataResult<ProductImage>(await _productImageDal.Get(p => p.Id == id));
        }

        private IResult CheckIfImageSizeIsLessThanOneMb(long imgSize)
        {
            decimal imgMbSize = Convert.ToDecimal(imgSize * 0.000001);
            if (imgMbSize > 5)
            {
                return new ErrorResult("Yüklediðiniz resmi boyutu en fazla 1mb olmalýdýr");
            }
            return new SuccessResult();
        }

        private IResult CheckIfImageExtesionsAllow(string fileName)
        {
            var ext = fileName.Substring(fileName.LastIndexOf('.'));
            var extension = ext.ToLower();
            List<string> AllowFileExtensions = new List<string> { ".jpg", ".jpeg", ".gif", ".png" };
            if (!AllowFileExtensions.Contains(extension))
            {
                return new ErrorResult("Eklediðiniz resim .jpg, .jpeg, .gif, .png türlerinden biri olmalýdýr!");
            }
            return new SuccessResult();
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IProductImageService.Get")]
        [RemoveCacheAspect("IProductService.Get")]
        public async Task<IResult> SetMainImage(int id)
        {
            var productImage = await _productImageDal.Get(p => p.Id == id);
            var productImages = await _productImageDal.GetAll(p => p.ProductId == productImage.ProductId);
            foreach (var item in productImages)
            {
                item.IsMainImage = false;
                await _productImageDal.Update(item);
            }

            productImage.IsMainImage = true;
            await _productImageDal.Update(productImage);
            return new SuccessResult(ProductImageMessages.MainImageIsUpdated);
        }
    }
}

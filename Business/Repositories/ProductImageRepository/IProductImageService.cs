using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Repositories.ProductImageRepository
{
    public interface IProductImageService
    {
        Task<IResult> Add(ProductImageAddDto productImageAddDto);
        Task<IResult> Update(ProductImageUpdateDto productImageUpdateDto);
        Task<IResult> SetMainImage(int id);
        Task<IResult> Delete(ProductImage productImage);
        Task<IDataResult<List<ProductImage>>> GetList();
        Task<IDataResult<List<ProductImage>>> GetListByProductId(int productId);
        Task<IDataResult<ProductImage>> GetById(int id);
    }
}

using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto categoryDto);

        void DeleteCategory(int id);

        void UptadeCategory(UpdateCategoryDto categoryDTo);

        Task<GetByIDCategoryDto> GetCategory(int id);
    }
}

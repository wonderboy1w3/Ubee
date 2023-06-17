using Ubee.Domain.Configurations;
using Ubee.Service.DTOs.Categories;

namespace Ubee.Service.Interfaces;

public interface ICategoryService
{
	ValueTask<bool> RemoveAsync(long id);
	ValueTask<CategoryForResultDto> RetrieveByIdAsync(long id);
	ValueTask<CategoryForResultDto> ModifyAsync(CategoryForUpdateDto dto);
	ValueTask<CategoryForResultDto> CreateAsync(CategoryForCreationDto dto);
	ValueTask<IEnumerable<CategoryForResultDto>> RetrieveAllAsync(PaginationParams @params);
}

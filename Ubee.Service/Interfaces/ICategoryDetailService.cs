using Ubee.Domain.Configurations;
using Ubee.Service.DTOs.Categories;

namespace Ubee.Service.Interfaces;

public interface ICategoryDetailService
{
	ValueTask<bool> RemoveAsync(long id);
	ValueTask<CategoryDetailForResultDto> RetrieveByIdAsync(long id);
	ValueTask<CategoryDetailForResultDto> ModifyAsync(CategoryDetailForUpdateDto dto);
	ValueTask<CategoryDetailForResultDto> CreateAsync(CategoryDetailForCreationDto dto);
	ValueTask<IEnumerable<CategoryDetailForResultDto>> RetrieveAllAsync(PaginationParams @params);
}

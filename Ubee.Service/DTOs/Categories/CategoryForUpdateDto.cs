using System.ComponentModel.DataAnnotations;

namespace Ubee.Service.DTOs.Categories;

public class CategoryForUpdateDto
{
	[Required]
	public long Id { get; set; }
	public string Name { get; set; }
}

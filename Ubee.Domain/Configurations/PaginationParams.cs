namespace Ubee.Domain.Configurations;

public class PaginationParams
{
    private const int maxSize = 20;
    private int pageSize;

    public int PageIndex { get; set; }
    public int PageSize
    { 
        get => pageSize; 
        set => pageSize = value > maxSize ? maxSize : value; 
    }
}

namespace BaseCRUDForAPI.Core.Models.Request.Base
{
    public class BaseSearch
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}

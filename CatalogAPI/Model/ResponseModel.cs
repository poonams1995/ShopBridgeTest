
namespace CatalogAPI.Model
{
    /// <summary>
    /// Class for response type
    /// </summary>
    public class ResponseModel
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public object ResponseData { get; set; } 
    }
}

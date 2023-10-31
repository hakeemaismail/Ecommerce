namespace Ecommerce.Models.DTO
{
    public class ResponseDTO<T>
    {
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public T data { get; set; }

    }
}

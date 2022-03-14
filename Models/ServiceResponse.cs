namespace WebApiJumpStart.Models
{
    public class ServiceResponse<T>
    {
        public string Version { get; set; } = "v1";

        public bool Success { get; set; } = true;

        public string Message { get; set; } = null!;

        public string Method { get; set; } = null!;

        public string Operation { get; set; } = null!;

        public string Type { get; set; } = null!;

        public int Count { get; set; } = 0;

        public T? Data { get; set; }
    }
}

namespace AppEscritorio.Models.Response
{
    public class ServerResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Error { get; set; } = string.Empty;
    }
}

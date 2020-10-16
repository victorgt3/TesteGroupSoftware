namespace GroupSoftware.Domain.DependencyInjection.Configuration.ErroHandler
{
    public class ErroHandlerLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public string User { get; set; }
    }
}

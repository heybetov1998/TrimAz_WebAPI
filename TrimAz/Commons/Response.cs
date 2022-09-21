namespace TrimAz.Commons
{
    internal class Response
    {
        private int _code { get; set; }
        private string _message { get; set; }

        public Response(int code, string message)
        {
            _code = code;
            _message = message;
        }
    }
}

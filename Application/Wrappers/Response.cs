using Application.Interfaces;


namespace Application.Wrappers
{
    public class Response<T> : IResponse<T> where T : class
    {
        public Response(string msj, bool success = true, IEnumerable<T>? list = null, T? entity = null)
        {
            this.Success = success;
            this.Entities = list;
            this.Entity = entity;
            this.Message = msj;
        }

        public Response(string? msj, bool success = true)
        {
            this.Success = success;
            this.Message = msj;
        }

        public Response(List<string> errors, bool success = true)
        {
            this.Success = success;
            this.Errors = errors;
        }

        public Response(IEnumerable<T>? list = null, T? entity = null)
        {
            this.Entities = list;
            this.Entity = entity;
        }

        public T? Entity { get; set; }
        public IEnumerable<T>? Entities { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; } = true;
        public List<string>? Errors { get; set; }
    }
}

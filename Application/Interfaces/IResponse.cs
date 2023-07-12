
namespace Application.Interfaces
{
    public interface IResponse<T> where T : class
    {
        IEnumerable<T>? Entities { get; set; }
        T? Entity { get; set; }
        List<string>? Errors { get; set; }
        string? Message { get; set; }
        bool Success { get; set; }
    }
}

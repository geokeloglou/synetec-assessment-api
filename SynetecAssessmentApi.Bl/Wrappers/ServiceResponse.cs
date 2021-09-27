namespace SynetecAssessmentApi.Bl.Wrappers
{
    public class ServiceResult<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = null;

        public int StatusCode { get; set; }
    }
}

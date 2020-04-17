namespace ClearAddVsLookupMove.Library
{
    public class BaseResponse
    {
        public bool Status { get; set; } = false;
        public object Response { get; set; } = null;
        public string Message { get; set; } = null;
    }
}

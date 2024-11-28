namespace Eve.Shared.Utils
{
    public class ResultOperation
    {
        public bool StateOperation { get; set; } = true;
        public string MessageResult { get; set; } = string.Empty;
        public string MessageError { get; set; } = string.Empty;
    }

    public class ResultOperation<T> : ResultOperation
    {
        public T? Result { get; set; }
        public List<T>? Results { get; set; }
    }
}

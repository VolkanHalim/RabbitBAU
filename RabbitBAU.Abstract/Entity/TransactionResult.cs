namespace RabbitBAU.Abstract
{
    public class TransactionResult<T>
    {
        public T Result { get; set; }

        public bool IsSucceed { get; set; }

        public string Message { get; set; }
    }
}

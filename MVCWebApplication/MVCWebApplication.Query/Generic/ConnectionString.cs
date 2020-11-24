namespace MVCWebApplication.Query.Generic
{   
    public sealed class QueriesConnectionString
    {
        public string Value { get; }

        public QueriesConnectionString(string value)
        {
            Value = value;
        }
    }
}

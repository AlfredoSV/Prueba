namespace Exercise2
{
    public class CommonException : Exception
    {
        public string Title { get; set; }
        public string Detail { get; set; }

        public CommonException(string title, string detail)
        {
            this.Title = title;
            this.Detail = detail;
        }

    }
}

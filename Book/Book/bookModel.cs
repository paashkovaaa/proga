namespace Book
{
    public class BookModel
    {
        public List<BookModel> Items { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
    }
}

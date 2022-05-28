using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public class BookCreator : IDocumentCreator<Book>
    {
        public Book Create()
        {
            return new Book();
        }
    }
}

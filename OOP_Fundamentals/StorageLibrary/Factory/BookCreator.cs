using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public class BookCreator : IDocumentCreator
    {
        public IDocumentType Create()
        {
            return new Book();
        }
    }
}

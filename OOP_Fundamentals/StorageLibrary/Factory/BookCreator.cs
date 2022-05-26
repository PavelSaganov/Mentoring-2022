using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public class BookCreator : IDocumentCreator
    {
        public AbstractDocument Create()
        {
            return new Book();
        }
    }
}

using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public class LocalizedBookCreator : IDocumentCreator
    {
        public IDocumentType Create()
        {
            return new LocalizedBook();
        }
    }
}

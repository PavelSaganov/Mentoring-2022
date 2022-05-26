using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public class LocalizedBookCreator : IDocumentCreator
    {
        public AbstractDocument Create()
        {
            return new LocalizedBook();
        }
    }
}

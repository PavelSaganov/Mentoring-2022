using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public class LocalizedBookCreator : IDocumentCreator<LocalizedBook>
    {
        public LocalizedBook Create()
        {
            return new LocalizedBook();
        }
    }
}

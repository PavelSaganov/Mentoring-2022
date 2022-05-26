using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public interface IDocumentCreator
    {
        public IDocumentType Create();
    }
}

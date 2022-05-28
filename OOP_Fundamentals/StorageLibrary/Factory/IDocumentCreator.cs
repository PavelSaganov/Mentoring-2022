using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public interface IDocumentCreator<out TDocument>
        where TDocument : AbstractDocument
    {
        public TDocument Create();
    }
}

using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public class PatentCreator : IDocumentCreator
    {
        public IDocumentType Create()
        {
            return new Patent();
        }
    }
}

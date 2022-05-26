using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public class PatentCreator : IDocumentCreator
    {
        public AbstractDocument Create()
        {
            return new Patent();
        }
    }
}

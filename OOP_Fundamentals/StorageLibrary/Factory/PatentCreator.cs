using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public class PatentCreator : IDocumentCreator<Patent>
    {
        public Patent Create()
        {
            return new Patent();
        }
    }
}

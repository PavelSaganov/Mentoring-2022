namespace StorageLibrary.Model
{
    public abstract class AbstractDocument
    {
        protected int Id { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}";
        }
    }
}

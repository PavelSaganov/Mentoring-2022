namespace StorageLibrary.Model
{
    public abstract class AbstractDocument
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}";
        }
    }
}

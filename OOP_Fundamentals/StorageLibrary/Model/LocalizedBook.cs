namespace StorageLibrary.Model
{
    public class LocalizedBook : Book
    {
        public string CountryOfLocalization { get; set; }
        public string LocalPublisher { get; set; }
    }
}

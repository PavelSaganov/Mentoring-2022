namespace StorageLibrary.Model
{
    public class LocalizedBook : Book
    {
        public string CountryOfLocalization { get; set; }
        public string LocalPublisher { get; set; }

        public override string ToString()
        {
            return $"ISBN = {ISBN}" +
                $" Title = {Title}" +
                $" NumberOfPages = {NumberOfPages}" +
                $" Publisher = {Publisher}" +
                $" DatePublished = {DatePublished.ToShortDateString()}" +
                $" LocalPublisher = {LocalPublisher}" +
                $" CountryLocalization = {CountryOfLocalization}";
        }
    }
}

using System;

namespace StorageLibrary.Model
{
    public class Magazine : AbstractDocument
    {
        public int ReleaseNumber { get => Id; set => Id = value; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }

        public override string ToString()
        {
            return $"ReleaseNumber = {ReleaseNumber}" +
                $" Title = {Title}" +
                $" Publisher = {Publisher}" +
                $" PublishDate = {PublishDate.ToShortDateString()}";
        }
    }
}

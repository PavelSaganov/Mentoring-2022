using System;
using System.Collections.Generic;
using StorageLibrary.Factory;
using StorageLibrary.Model;
using StorageLibrary.Repositories.JsonRepository;

namespace UI_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Patent test
            var patentCreator = new PatentCreator();
            Console.WriteLine("Getting test patents...");
            var patents = GetTestDocuments(patentCreator);
            Console.WriteLine($"Documents were created:\n1 - {patents[0]}\n2 - {patents[1]}");
            var jsonPatentRepository = new JsonPatentRepository();
            Console.WriteLine("Saving documents to json...");
            SaveToStorageTest(patents, jsonPatentRepository);

            Console.WriteLine("Reading documents from json...");
            var p1 = jsonPatentRepository.Read(patents[0].Id);
            Console.WriteLine($"{p1} was readed from json");
            var p2 = jsonPatentRepository.Read(patents[1].Id);
            Console.WriteLine($"{p2} was readed from json");
            #endregion


            #region Book test
            var bookCreator = new BookCreator();
            Console.WriteLine("Getting test books...");
            var books = GetTestDocuments(bookCreator);
            Console.WriteLine($"Documents were created: 1 - {books[0]}\n2 - {books[1]}");
            var jsonBookRepository = new JsonBookRepository();
            Console.WriteLine("Saving documents to json...");
            SaveToStorageTest(books, jsonBookRepository);

            Console.WriteLine("Reading documents from json...");
            var b1 = jsonPatentRepository.Read(books[0].ISBN);
            Console.WriteLine($"{b1} was readed from json");
            var b2 = jsonPatentRepository.Read(books[1].ISBN);
            Console.WriteLine($"{b2} was readed from json");
            #endregion


            #region Localized books test
            var localizedBookCreator = new LocalizedBookCreator();
            Console.WriteLine("Getting test localizedBooks...");
            var localizedBooks = GetTestDocuments(localizedBookCreator);
            Console.WriteLine($"Documents were created: 1 - {localizedBooks[0]}\n2 - {localizedBooks[1]}");
            var jsonLocalizedBookRepository = new JsonLocalizedBookRepository();
            Console.WriteLine("Saving documents to json...");
            SaveToStorageTest(localizedBooks, jsonLocalizedBookRepository);

            Console.WriteLine("Reading documents from json...");
            var lb1 = jsonPatentRepository.Read(localizedBooks[0].ISBN);
            Console.WriteLine($"{lb1} was readed from json");
            var lb2 = jsonPatentRepository.Read(localizedBooks[1].ISBN);
            Console.WriteLine($"{lb2} was readed from json");
            #endregion

            #region Magazine test
            var magazineCreator = new MagazineCreator();
            Console.WriteLine("Getting test magazines...");
            var magazines = GetTestDocuments(magazineCreator);
            Console.WriteLine($"Documents were created: 1 - {magazines[0]}\n2 - {magazines[1]}");
            var jsonMagazineRepository = new JsonMagazineRepository();
            Console.WriteLine("Saving documents to json...");
            SaveToStorageTest(magazines, jsonMagazineRepository);

            Console.WriteLine("Reading documents from json...");
            var m1 = jsonPatentRepository.Read(magazines[0].ReleaseNumber);
            Console.WriteLine($"{m1} was readed from json");
            var m2 = jsonPatentRepository.Read(magazines[1].ReleaseNumber);
            Console.WriteLine($"{m2} was readed from json");
            #endregion
        }

        private static void SaveToStorageTest<TDocument>(List<TDocument> list, IJsonDocumentRepository<TDocument> jsonRepository)
        where TDocument : AbstractDocument
        {
            jsonRepository.Create(list[0]);
            jsonRepository.Create(list[1]);
        }

        #region Create test data methods
        static List<TDocument> GetTestDocuments<TDocument>(IDocumentCreator<TDocument> documentCreator)
            where TDocument : AbstractDocument
        {
            var document = documentCreator.Create();
            var document2 = documentCreator.Create();

            // can't use switch/case
            if (typeof(TDocument) == typeof(Patent))
            {
                var patent = document as Patent;
                patent.Authors = new List<string> { "Petrovich", "Mihalich", "Evgenich" };
                patent.DatePublished = DateTime.Now.AddYears(-15);
                patent.ExpirationDate = DateTime.Now.AddYears(1);
                patent.Title = "Electrocar";
                patent.Id = 1;

                var patent2 = document2 as Patent;
                patent2.Authors = new List<string> { "Seregey", "Bacho" };
                patent2.DatePublished = DateTime.Now.AddYears(-12);
                patent2.ExpirationDate = DateTime.Now.AddYears(4);
                patent2.Title = "Reactor";
                patent2.Id = 2;
            }

            if (typeof(TDocument) == typeof(Book))
            {
                var book = document as Book;
                book.Authors = new List<string> { "Petrovich", "Mihalich", "Evgenich" };
                book.DatePublished = DateTime.Now.AddYears(-15);
                book.NumberOfPages = 500;
                book.Publisher = "Future c. - 2003";
                book.Title = "History of Europe";
                book.ISBN = 1;

                var book2 = document2 as Book;
                book2.Authors = new List<string> { "Seregey", "Bacho" };
                book2.DatePublished = DateTime.Now.AddYears(-12);
                book2.NumberOfPages = 370;
                book.Publisher = "Future c. - 2010";
                book2.Title = "How to cook";
                book2.ISBN = 2;
            }

            if (typeof(TDocument) == typeof(LocalizedBook))
            {
                var book = document as LocalizedBook;
                book.Authors = new List<string> { "Petrovich", "Mihalich", "Evgenich" };
                book.DatePublished = DateTime.Now.AddYears(-15);
                book.NumberOfPages = 180;
                book.Publisher = "Future c. - 2003";
                book.LocalPublisher = "Local Future c. - 2003";
                book.Title = "History of Asia";
                book.ISBN = 1;

                var book2 = document2 as LocalizedBook;
                book2.Authors = new List<string> { "Seregey", "Bacho" };
                book2.DatePublished = DateTime.Now.AddYears(-12);
                book2.NumberOfPages = 420;
                book.Publisher = "Future c. - 2010";
                book2.LocalPublisher = "Local Future c. - 2010";
                book2.Title = "How to read";
                book2.ISBN = 2;
            }

            if (typeof(TDocument) == typeof(Magazine))
            {
                var magazine = document as Magazine;
                magazine.PublishDate = DateTime.Now.AddYears(-5);
                magazine.Publisher = "Future c. - 2003";
                magazine.Title = "History of Asia";
                magazine.ReleaseNumber = 1;

                var magazine2 = document2 as Magazine;
                magazine2.PublishDate = DateTime.Now.AddYears(-29);
                magazine.Publisher = "Future c. - 2010";
                magazine2.Title = "How to read";
                magazine2.ReleaseNumber = 2;
            }

            return new List<TDocument>()
            {
                document,
                document2
            };
        }
        #endregion
    }
}

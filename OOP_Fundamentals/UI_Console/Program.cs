using System;
using System.Collections.Generic;
using StorageLibrary.Factory;
using StorageLibrary.Model;
using StorageLibrary.Repositories.JsonRepository;
using StorageLibrary.Service;
using StorageLibrary.Service.CacheServices;

namespace UI_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Patent test
            var patentCreator = new PatentCreator();
            var jsonPatentRepository = new JsonPatentRepository();
            var patentCacheService = new PatentCacheService();
            var patentService = new PatentService(jsonPatentRepository, patentCacheService);
            Console.WriteLine("Getting test patents...");
            var patents = GetTestDocuments(patentCreator);
            Console.WriteLine($"Documents were created:\n1 - {patents[0]}\n2 - {patents[1]}");
            Console.WriteLine("Saving documents to json and cache...");
            SaveToStorageTest(patents, patentService);

            Console.WriteLine("Reading documents from json/cache...");
            var p1 = patentService.Read(patents[0].Id);
            Console.WriteLine($"{p1} was readed from json/cache");
            var p2 = patentService.Read(patents[1].Id);
            Console.WriteLine($"{p2} was readed from json/cache");
            #endregion


            #region Book test
            var bookCreator = new BookCreator();
            var jsonBookRepository = new JsonBookRepository();
            var bookCacheService = new BookCacheService();
            var bookService = new BookService(jsonBookRepository, bookCacheService);

            Console.WriteLine("Getting test books...");
            var books = GetTestDocuments(bookCreator);
            Console.WriteLine($"Documents were created: 1 - {books[0]}\n2 - {books[1]}");
            Console.WriteLine("Saving documents to json and cache...");
            SaveToStorageTest(books, bookService);

            Console.WriteLine("Reading documents from json/cache...");
            var b1 = bookService.Read(books[0].ISBN);
            Console.WriteLine($"{b1} was readed from json/cache");
            var b2 = bookService.Read(books[1].ISBN);
            Console.WriteLine($"{b2} was readed from json/cache");
            #endregion


            #region Localized books test
            var localizedBookCreator = new LocalizedBookCreator();
            var jsonLocalizedBookRepository = new JsonLocalizedBookRepository();
            var localizedBookCacheService = new LocalizedBookCacheService();
            var localizedBooktService = new LocalizedBookService(jsonLocalizedBookRepository, localizedBookCacheService);
            Console.WriteLine("Getting test localizedBooks...");
            var localizedBooks = GetTestDocuments(localizedBookCreator);
            Console.WriteLine($"Documents were created: 1 - {localizedBooks[0]}\n2 - {localizedBooks[1]}");
            Console.WriteLine("Saving documents to json and cache...");
            SaveToStorageTest(localizedBooks, localizedBooktService);

            Console.WriteLine("Reading documents from json/cache...");
            var lb1 = localizedBooktService.Read(localizedBooks[0].ISBN);
            Console.WriteLine($"{lb1} was readed from json/cache");
            var lb2 = localizedBooktService.Read(localizedBooks[1].ISBN);
            Console.WriteLine($"{lb2} was readed from json/cache");
            #endregion

            #region Magazine test
            var magazineCreator = new MagazineCreator();
            var jsonMagazineRepository = new JsonMagazineRepository();
            var magazineCacheService = new MagazineCacheService();
            var magazinetService = new MagazineService(jsonMagazineRepository, magazineCacheService);
            Console.WriteLine("Getting test magazines...");
            var magazines = GetTestDocuments(magazineCreator);
            Console.WriteLine($"Documents were created: 1 - {magazines[0]}\n2 - {magazines[1]}");
            Console.WriteLine("Saving documents to json and cache...");
            SaveToStorageTest(magazines, magazinetService);

            Console.WriteLine("Reading documents from json/cache...");
            var m1 = magazinetService.Read(magazines[0].ReleaseNumber);
            Console.WriteLine($"{m1} was readed from json/cache");
            var m2 = magazinetService.Read(magazines[1].ReleaseNumber);
            Console.WriteLine($"{m2} was readed from json/cache");
            #endregion
        }

        private static void SaveToStorageTest<TDocument>(List<TDocument> list, IDocumentService<TDocument> service)
        where TDocument : AbstractDocument
        {
            service.Create(list[0]);
            service.Create(list[1]);
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

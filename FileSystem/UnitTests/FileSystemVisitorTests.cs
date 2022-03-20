using FileSystemVisitorLibrary;
using NUnit.Framework;
using System.Collections;
using System.Configuration;
using System.IO;

namespace UnitTests
{
    public class FileSystemVisitorTests
    {
        private int countForAbort = 10;
        private int countForExclude = 10;
        private string pathToFolder = string.Empty;

        [SetUp]
        public void Setup()
        {
            int.TryParse(ConfigurationManager.AppSettings.Get("CountForAbort"), out countForAbort);
            int.TryParse(ConfigurationManager.AppSettings.Get("CountForExclude"), out countForExclude);
            pathToFolder = Directory.GetCurrentDirectory() + "\\TestFolder";

            FillDirectory();
        }

        private void FillDirectory()
        {
            Directory.CreateDirectory(pathToFolder);
            Directory.CreateDirectory($"{pathToFolder}\\TestFolder1");
            Directory.CreateDirectory($"{pathToFolder}\\asdd");
            Directory.CreateDirectory($"{pathToFolder}\\SomeInfo");
            File.Create($"{pathToFolder}\\FirstFile");
            File.Create($"{pathToFolder}\\fiile.txt");
            File.Create($"{pathToFolder}\\Wow_its_a_test_file");
            File.Create($"{pathToFolder}\\FileWithNumbers123214");
        }

        [TearDown]
        public void Rollback()
        {
            ClearFolder(pathToFolder);
        }

        private void ClearFolder(string folderName)
        {
            DirectoryInfo dir = new DirectoryInfo(folderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ClearFolder(di.FullName);
                di.Delete();
            }
        }

        [Test]
        public void ReadFilesInFolder_CorrectFiles_ShouldContainAllFiles()
        {
            // Arrange
            var expectedElementsOfFolder = new ArrayList {
                $"{pathToFolder}\\TestFolder1",
                $"{pathToFolder}\\asdd",
                $"{pathToFolder}\\SomeInfo",
                $"{pathToFolder}\\FirstFile",
                $"{pathToFolder}\\fiile.txt",
                $"{pathToFolder}\\Wow_its_a_test_file",
                $"{pathToFolder}\\FileWithNumbers123214" };

            // Act
            var fileSystemVisitor = new FileSystemVisitor(pathToFolder);

            // Assert
            Assert.Multiple(() =>
            {
                foreach (var element in fileSystemVisitor.ElementsOfFolder)
                    Assert.Contains(element, expectedElementsOfFolder);
            });
        }
    }
}
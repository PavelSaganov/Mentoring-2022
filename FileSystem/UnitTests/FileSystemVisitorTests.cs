using FileSystemVisitorLibrary;
using NUnit.Framework;
using System.Collections;
using System.IO;
using FileSystemVisitorLibrary.Configuration;

namespace UnitTests
{
    public class FileSystemVisitorTests
    {
        private FileSystemVisitorConfiguration _config;
        private string pathToFolder = string.Empty;

        [SetUp]
        public void Setup()
        {
            pathToFolder = Directory.GetCurrentDirectory() + "\\TestFolder";
            _config = new FileSystemVisitorConfiguration(pathToFolder);

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
            var dir = new DirectoryInfo(folderName);

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
        public void ReadFilesInFolder_ValidFiles_ShouldContainAllFiles()
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
            var fileSystemVisitor = new FileSystemVisitor(_config);

            // Assert
            Assert.Multiple(() =>
            {
                foreach (var element in fileSystemVisitor.ElementsOfFolder)
                    Assert.Contains(element, expectedElementsOfFolder);
            });
        }
    }
}
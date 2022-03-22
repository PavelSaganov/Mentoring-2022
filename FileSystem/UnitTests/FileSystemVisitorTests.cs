using FileSystemVisitorLibrary;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace UnitTests
{
    public class FileSystemVisitorTests
    {
        private string pathToFolder = string.Empty;

        [SetUp]
        public void Setup()
        {
            pathToFolder = Directory.GetCurrentDirectory() + "\\TestFolder";

            FillDirectory();
        }

        private void FillDirectory()
        {
            Directory.CreateDirectory(pathToFolder);
            Directory.CreateDirectory($"{pathToFolder}\\TestFolder1");
            Directory.CreateDirectory($"{pathToFolder}\\asdd");
            Directory.CreateDirectory($"{pathToFolder}\\SomeInfo");
            File.Create($"{pathToFolder}\\fiile.txt");
            File.Create($"{pathToFolder}\\FileWithNumbers123214");
            File.Create($"{pathToFolder}\\FirstFile");
            File.Create($"{pathToFolder}\\Wow_its_a_test_file");
        }

        [TearDown]
        public void Rollback()
        {
            if (Directory.Exists(pathToFolder))
            {
                var dir = new DirectoryInfo(pathToFolder);
                dir.Delete(true);
            }
        }

        [Test]
        public void ReadFilesInFolder_ValidFiles_ShouldContainAllFiles()
        {
            // Arrange
            var fileSystemVisitor = new FileSystemVisitor(pathToFolder);
            var expectedElementsOfFolder = new List<FileInfo> {
                new FileInfo($"{pathToFolder}\\fiile.txt"),
                new FileInfo($"{pathToFolder}\\FileWithNumbers123214"),
                new FileInfo($"{pathToFolder}\\FirstFile"),
            new FileInfo($"{pathToFolder}\\Wow_its_a_test_file") };

            // Act
            var actual = (ICollection)fileSystemVisitor.GetFiles();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Contains(expectedElementsOfFolder, actual);
            });
        }
    }
}
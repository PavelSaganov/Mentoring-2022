using System;
using System.Collections.Generic;
using System.Text;
using StorageLibrary.Model;

namespace StorageLibrary.Factory
{
    public class MagazineCreator : IDocumentCreator<Magazine>
    {
        public Magazine Create()
        {
            return new Magazine();
        }
    }
}

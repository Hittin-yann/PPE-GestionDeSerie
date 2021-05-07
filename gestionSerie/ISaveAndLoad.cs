using System;
using System.Collections.Generic;
using System.Text;

namespace gestionSerie
{
    public interface ISaveAndLoad
    {
        void SaveText(string filename, string text);
        string LoadText(string filename);
        void DeleteText(string filename);
        bool ExistFile(string filename);
    }
}

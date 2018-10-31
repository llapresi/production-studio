using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IEditorRenamable
{
    string GetName();
    void SetName(string newName);
}

public interface IEditorAddable
{
    void Add(string nameOfElementToAdd);
}

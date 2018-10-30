using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Contains a list of QueryTopics one can query
// Will eventually be given a handle to link to a given "leader" entity
[System.Serializable]
public class DialogQuery : IEditorAddable
{

    public List<DialogQueryTopic> topics;

    public DialogQuery()
    {
        topics = new List<DialogQueryTopic>();
    }

    public void Add(string nameOfElementToAdd)
    {
        topics.Add(new DialogQueryTopic(nameOfElementToAdd));
    }
}

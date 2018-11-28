using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Contains a list of QueryTopics one can query
[System.Serializable]
public class DialogQuery : IEditorAddable
{
    // List of QueryTopics
    public List<DialogQueryTopic> topics;

    // String used to look up relevant images (ex. leader profiles, background)
    public string leaderID;

    public DialogQuery()
    {
        topics = new List<DialogQueryTopic>();
        leaderID = "defaultLeaderID";
    }

    public void Add(string nameOfElementToAdd)
    {
        topics.Add(new DialogQueryTopic(nameOfElementToAdd));
    }
}

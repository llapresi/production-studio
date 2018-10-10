using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains a list of QueryTopics one can query
// Will eventually be given a handle to link to a given "leader" entity
[System.Serializable]
class DialogQuery {

    public List<DialogQueryTopic> topics;

    public DialogQuery()
    {
        topics = new List<DialogQueryTopic>();
    }
}

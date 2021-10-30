using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Event
{
    public static void GetDialogueEventValues(Define.DialogueEvent evt, int select, out int nextId, out int lastId, out int joinId)
    {
        nextId = 0;
        lastId = 0;
        joinId = 0;

        switch (evt)
        {
            case Define.DialogueEvent.AskAmuroName:
                if (select == 1)
                {
                    nextId = 8;
                    lastId = 8;
                    joinId = 10;
                }
                else if (select == 2)
                {
                    nextId = 9;
                    lastId = 9;
                    joinId = 10;
                }
                break;
        }
    }
}

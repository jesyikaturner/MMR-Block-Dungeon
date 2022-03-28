using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room
{
    private int _roomID;
    private int _level;
    [System.NonSerialized] public List<Room> nextRooms;

    public Room()
    {
        _roomID = 0;
        _level = 0;
    }
    public Room (int roomID, int level)
    {
        _roomID = roomID;
        _level = level;
    }

    public virtual string Print()
    {
        string[] nextRoomsString = new string[nextRooms.Count];
        for (int i = 0; i < nextRoomsString.Length; i++)
        {
            nextRoomsString[i] = string.Format("nextRoom{0}",nextRooms[i]._roomID);
        }
        return string.Format("roomID:{},level:{}");
    }


}

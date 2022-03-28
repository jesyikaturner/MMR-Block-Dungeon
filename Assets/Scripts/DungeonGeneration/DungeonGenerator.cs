using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int maxSize;
    public List<Room> rooms;
    private int _level;

    // Start is called before the first frame update
    void Start()
    {
        _level = 0;
        GenerateDungeon(maxSize);
    }

    public void GenerateDungeon(int maxSize)
    {
        EntryRoom entry = new EntryRoom();
        //Room entry = ScriptableObject.CreateInstance<Room>();
        //entry.SetupRoom();
        rooms.Add(entry);
        while (_level < maxSize)
        {

            _level++;
        }
    }
}


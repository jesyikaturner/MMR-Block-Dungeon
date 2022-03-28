using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonMonStats
{
    private int _level = 1;
    private float _experience = 0;

    // type (element attack)

    private float _maxHitPoints = 10f;
    private float _maxManaPoints = 10f;

    private int _dexterity = 10;
    private int _strength = 10;
    private int _intellect = 10;

    public Move[] moves = { new Move(), new Move(), new Move(), new Move() };

    // equipment list (element resistence)

    public void SetupStatsViaJSON(TextAsset json)
    {
        Stats statObject = JsonUtility.FromJson<Stats>(json.text);

        if (statObject == null)
            return;

        _level = statObject.level;
        _experience = statObject.experience;

        _maxHitPoints = statObject.hitpoints;
        _maxManaPoints = statObject.manapoints;

        _dexterity = statObject.dexterity;
        _strength = statObject.strength;
        _intellect = statObject.intellect;

        // TODO: Create moves by looking up moves in movedictionary
        // TODO: Create equipment by looking up items in itemdictionary
    }

    // JSON
    private class Stats
    {
        public int level;
        public float experience;
        // public string type;
        public float hitpoints;
        public float manapoints;
        public int dexterity;
        public int strength;
        public int intellect;

        public MoveName[] moveset;
        public equipmentName[] equipment;
    }

    private class MoveName
    {
        public string name;
    }

    private class equipmentName
    {
        public string name;
        public int slotPosition;
    }
}

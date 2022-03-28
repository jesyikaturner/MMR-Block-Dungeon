using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    private string _name;
    private string _description;
    public enum TYPE {
        DAMAGE, STATUS, STRBUFF, DEXBUFF, INTBUFF, HEAL
    }
    private TYPE _moveType;
    private float _value;

    public Move ()
    {
        _name = "default";
        _description = "default";
        _moveType = TYPE.DAMAGE;
        _value = 10f;
    }

    public Move (string name, string description, TYPE moveType, float value)
    {
        _name = name;
        _description = description;
        _moveType = moveType;
        _value = value;
    }
}

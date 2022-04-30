using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventList
{
    /*
     * EventList.cs
     * Stores a list of events which are created from EventDictionary.json.
     * 
     * This is used for the Dungeon Generation code.
     */
    private Dictionary<string, Event> _eventList;


    public EventList(TextAsset json)
    {
        _eventList = new Dictionary<string, Event>();
        JSONEvents events = JsonUtility.FromJson<JSONEvents>(json.text);

        foreach (JSONEvent e in events.events)
        {
            _eventList.Add(e.name, new Event(e.id, e.name, e.text, e.effect));
            Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Added new event: {0}", _eventList[e.name].Print()));
        }

    }

    public Event GetEventByName(string name)
    {
        try
        {
            Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Got {0} from the eventList dictionary", name));
            return _eventList[name];
        }
        catch (Exception)
        {
            Logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), string.Format("{0} doesn't exist", name));
            return null;
        }

    }

    public Event GetEventById(int id)
    {
        foreach(KeyValuePair<string, Event> e in _eventList)
        {
            if (e.Value.ID == id)
                return _eventList[e.Key];
        }
        return null;
    }

    // JSON
    [Serializable]
    public class JSONEvents
    {
        public JSONEvent[] events;
    }
    [Serializable]
    public class JSONEvent
    {
        public int id;
        public string name;
        public string text;
        public string effect;
    }
}

public class Event
{
    /*
    * Event.cs
    */
    public enum EFFECT { LOSEHEALTH, GAINDISEASE, DECREASEDROPS, BUFFENEMIES, GAINHEALTH, LOSEDISEASE, INCREASEDROPS, DEBUFFENEMIES, GAINITEM };

    public int ID { get; private set; }
    public string Name { get; private set; }
    public string Text { get; private set; }
    private EFFECT _effect;

    public Event(int id, string name, string text, string effect)
    {
        ID = id;
        Name = name;
        Text = text;
        SetEffect(effect);
        Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), "Created event");
    }

    public void SetEffect(string effect)
    {
        Dictionary<string, EFFECT> effectDictionary = new Dictionary<string, EFFECT>()
        {
            ["losehealth"] = EFFECT.LOSEHEALTH,
            ["gaindisease"] = EFFECT.GAINDISEASE,
            ["decreasedrops"] = EFFECT.DECREASEDROPS,
            ["buffenemies"] = EFFECT.BUFFENEMIES,
            ["gainhealth"] = EFFECT.GAINHEALTH,
            ["losedisease"] = EFFECT.LOSEDISEASE,
            ["increasedrops"] = EFFECT.INCREASEDROPS,
            ["debuffenemies"] = EFFECT.DEBUFFENEMIES,
            ["gainitem"] = EFFECT.GAINITEM
        };
        if (effectDictionary.ContainsKey(effect))
        {
            _effect = effectDictionary[effect];
            Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Set effect to {0}", _effect));
        }
        else
        {
            ArgumentNullException e = new ArgumentNullException("Invalid Effect");
            Logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), e.ToString());
            throw e;
        }
    }

    public string Print()
    {
        return string.Format("ID: {0}, Name: {1}, Text: {2}, Effect: {3}.", ID, Name, Text, _effect);
    }
}

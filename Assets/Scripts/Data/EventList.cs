using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventList
{
    /*
     * EventList.cs
     * Stores a list of events which are created from EventDictionary.json.
     */
    private Dictionary<string, Event> _eventList;


    public EventList(TextAsset json)
    {
        _eventList = new Dictionary<string, Event>();
        JSONEvents events = JsonUtility.FromJson<JSONEvents>(json.text);

        foreach (JSONEvent e in events.events)
        {
            _eventList.Add(e.name, new Event(e.id, e.name, e.text, e.effect));
            Logger.WriteToLog(string.Format("EventList: EventList(): SUCCESS: Added new event: {0}.", _eventList[e.name].Print()));
        }
    }

    public Event GetEventByName(string name)
    {
        try
        {
            Logger.WriteToLog(string.Format("EventList: GetEvent(): SUCCESS: Got {0} from the eventList dictionary.", name));
            return _eventList[name];
        }
        catch(Exception)
        {
            Logger.WriteToLog(string.Format("EventList: GetEvent(): Error: {0} doesn't exist.", name));
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
        Logger.WriteToLog(string.Format("EventList: Event: Event(): SUCCESS: Created event."));
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
            Logger.WriteToLog(string.Format("EventList: Event: SetEffect(): SUCCESS: Set effect to {0}.", _effect));
        }
        else
        {
            ArgumentNullException e = new ArgumentNullException("Invalid Effect");
            Logger.WriteToLog(string.Format("EventList: Event: SetEffect(): ERROR: {0}.", e));
            throw e;
        }
    }

    public string Print()
    {
        return string.Format("ID: {0}, Name: {1}, Text: {2}, Effect: {3}.", ID, Name, Text, _effect);
    }
}

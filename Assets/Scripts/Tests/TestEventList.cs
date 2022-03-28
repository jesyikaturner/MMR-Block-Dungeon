using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestEventList
{
    //public const string SKIP_SETUP = "SkipSetup";
    private EventList _list;

    //private bool CheckForSkipSetup()
    //{
    //    ArrayList categories = TestContext.CurrentContext.Test
    //       .Properties["_CATEGORIES"] as ArrayList;

    //    bool skipSetup = categories != null && categories.Contains(SKIP_SETUP);
    //    return skipSetup;
    //}

    [SetUp]
    public void TestItemListPass()
    {
        //if(CheckForSkipSetup())
        //    return;

        string eventPath = File.ReadAllText(Application.dataPath + "/Scripts/Data/TestEventDictionary.json");
        TextAsset eventJSON = new TextAsset(eventPath);
        _list = new EventList(eventJSON);
        Debug.Log(_list.GetEventByName("test").Print());
    }

    [Test]
    public void TestGetEventByNamePass()
    {
        string expectedResult = "ID: 0, Name: test, Text: test, Effect: LOSEHEALTH.";
        Assert.AreEqual(_list.GetEventByName("test").Print(), expectedResult);
    }

    [Test]
    public void TestGetEventByNameFail()
    {
        string expectedResult = "ID: 0, Name: test, Text: test, Effect: LOSEHEALTH.";
        Assert.AreNotEqual(_list.GetEventByName("test1").Print(), expectedResult);
    }

    [Test]
    public void TestGetEventByIDPass()
    {
        string expectedResult = "ID: 0, Name: test, Text: test, Effect: LOSEHEALTH.";
        Assert.AreEqual(_list.GetEventById(0).Print(), expectedResult);
    }

    [Test]
    public void TestGetEventByIDFail()
    {
        string expectedResult = "ID: 0, Name: test, Text: test, Effect: LOSEHEALTH.";
        Assert.AreNotEqual(_list.GetEventById(1).Print(), expectedResult);
    }

    [Test]
    public void TestSetEffectPass()
    {
        string expectedResult = "ID: 0, Name: test, Text: test, Effect: GAINITEM.";
        Event testEvent = _list.GetEventById(0);
        testEvent.SetEffect("gainitem");
        Assert.AreEqual(testEvent.Print(), expectedResult);
    }

    [Test]
    //[Category(SKIP_SETUP)]
    public void TestSetEffectFail()
    {
        Event testEvent = _list.GetEventById(1);
        Assert.That(() => testEvent.SetEffect(null),Throws.TypeOf<ArgumentNullException>());
    }
}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestItemList
{
    public ItemList list;

    [SetUp]
    public void TestItemListPass()
    {
        TextAsset testJSON = new TextAsset("1234");
        
        list = new ItemList(testJSON);
    }

    [Test]
    public void TestParseItemTypePass()
    {
        string testDescription = "[Junk] A bit of driftwood.";
        Assert.AreEqual(list.ParseItemType(testDescription, "[", "]"), "Junk");

    }

    [Test]
    public void TestParseItemTypeFail()
    {
        string testDescription = "[Junk] A bit of driftwood.";
        Assert.AreNotEqual(list.ParseItemType(testDescription, "[", "]"), "Material");
    }

}

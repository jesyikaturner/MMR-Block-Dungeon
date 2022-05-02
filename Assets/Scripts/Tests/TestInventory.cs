using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestInventory
{
    private Inventory _inventory;
    private List<string> _setupInventoryOutput;

    [SetUp]
    public void TestInventorySetup()
    {
        _inventory = new Inventory();

        _inventory.AddQuantity(new Item(0, "test normal item", "this is regular item", "none", 10), 3);
        _inventory.AddQuantity(new Item(1, "test special item", "this is a special item", "one", 0));
        _inventory.AddQuantity(new Item(2, "test item", "test", "all", 10));

        _setupInventoryOutput = _inventory.Print();
    }

    /// <summary>
    /// Add item that doesn't already exist in the inventory.
    /// </summary>
    [Test]
    public void TestAddNewItemPass()
    {
        Item testItem = new Item(3, "ultra special awesome card", "believe in the heart of the cards", "all", 9000);
        _setupInventoryOutput.Add(string.Format("Item Id: {0}, Item Name: {1}, Quantity: {2} \n", testItem.id, testItem.name, 1));
        _inventory.AddQuantity(testItem);

        Assert.AreEqual(_setupInventoryOutput.Count, 4);
    }

    /// <summary>
    /// Add item that already exists in the inventory.
    /// </summary>
    [Test]
    public void TestAddExistingItemPass()
    {
        Item testItem = new Item(0, "test normal item", "this is regular item", "none", 10);
        _inventory.AddQuantity(testItem);

        Assert.AreEqual(_inventory.GetItemById(testItem.id).quantity, 4);
    }

    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void TestGetItemByIdPass()
    {
        Assert.IsNotNull(_inventory.GetItemById(0));
    }

    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void TestGetItemByIdFail()
    {
        Assert.IsNull(_inventory.GetItemById(4));
    }

    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void TestGetItemByNamePass()
    {
        Assert.IsNotNull(_inventory.GetItemByName("test item"));
    }

    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void TestGetItemByNameFail()
    {
        Assert.IsNull(_inventory.GetItemByName("fake test item"));
    }
}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestInventory
{
    private Inventory _inventory;
    private List<string> _setupInventoryOutput;

    private Item _testItem, _testNewItem;

    [SetUp]
    public void TestInventorySetup()
    {
        _inventory = new Inventory();

        _testNewItem = new Item(3, "ultra special awesome card", "believe in the heart of the cards", "all", 9000);
        _testItem = new Item(0, "test normal item", "this is regular item", "none", 10);

        _inventory.AddQuantity(_testItem, 3);
        _inventory.AddQuantity(new Item(1, "test special item", "this is a special item", "one", 0));
        _inventory.AddQuantity(new Item(2, "test item", "test", "all", 10));

        _setupInventoryOutput = _inventory.Print();
    }

    #region Add Item
    /// <summary>
    /// Add item that doesn't already exist in the inventory.
    /// </summary>
    [Test]
    public void TestAddNewItemPass()
    {
        _setupInventoryOutput.Add(string.Format("Item Id: {0}, Item Name: {1}, Quantity: {2} \n", _testNewItem.id, _testNewItem.name, 1));
        _inventory.AddQuantity(_testNewItem);

        Assert.AreEqual(_setupInventoryOutput.Count, 4);
    }

    /// <summary>
    /// Add item that already exists in the inventory.
    /// </summary>
    [Test]
    public void TestAddExistingItemPass()
    {
        _inventory.AddQuantity(_testItem);

        Assert.AreEqual(_inventory.GetItemById(_testItem.id).quantity, 4);
    }
    #endregion

    #region Get Item
    /// <summary>
    /// Return an item by its id.
    /// </summary>
    [Test]
    public void TestGetItemByIdPass()
    {
        Assert.IsNotNull(_inventory.GetItemById(0));
    }

    /// <summary>
    /// Fail to return an item by its id.
    /// </summary>
    [Test]
    public void TestGetItemByIdFail()
    {
        Assert.IsNull(_inventory.GetItemById(4));
    }

    /// <summary>
    /// Return an item by its name.
    /// </summary>
    [Test]
    public void TestGetItemByNamePass()
    {
        Assert.IsNotNull(_inventory.GetItemByName("test item"));
    }

    /// <summary>
    /// Fail to return an item by its name.
    /// </summary>
    [Test]
    public void TestGetItemByNameFail()
    {
        Assert.IsNull(_inventory.GetItemByName("fake test item"));
    }
    #endregion

    #region Remove Item
    /// <summary>
    /// Remove item by id. Removes all quantity.
    /// </summary>
    [Test]
    public void TestRemoveItemByIdPass()
    {
        Assert.IsTrue(_inventory.RemoveItemById(0));
    }

    /// <summary>
    /// Fail to remove item by id.
    /// </summary>
    [Test]
    public void TestRemoveItemByIdFail()
    {
        Assert.IsFalse(_inventory.RemoveItemById(4));
    }

    /// <summary>
    /// Remove item by name. Removes all quantity.
    /// </summary>
    [Test]
    public void TestRemoveItemByNamePass()
    {
        Assert.IsTrue(_inventory.RemoveItemByName("test item"));
    }

    /// <summary>
    /// Fail to remove item by name.
    /// </summary>
    [Test]
    public void TestRemoveItemByNameFail()
    {
        Assert.IsFalse(_inventory.RemoveItemByName("fake test item"));
    }
    #endregion

    #region Remove Quantity
    /// <summary>
    /// Remove 1x test normal item.
    /// </summary>
    [Test]
    public void TestRemoveQuantityPass()
    {
        Assert.IsTrue(_inventory.RemoveQuantity(0, 1));
        Assert.AreEqual(_inventory.GetItemById(0).quantity, 2);
    }

    /// <summary>
    /// Remove 3x test normal item and remove test normal item from the list.
    /// </summary>
    [Test]
    public void TestRemoveQuantityRemoveItemPass()
    {
        Assert.IsTrue(_inventory.RemoveQuantity(0, 3));
        Assert.AreEqual(_inventory.GetInventorySize(), 2);
    }

    /// <summary>
    /// Fail to remove 1x undefined item from the list.
    /// </summary>
    [Test]
    public void TestRemoveQuantityNotFoundFail()
    {
        Assert.IsFalse(_inventory.RemoveQuantity(4, 1));
    }

    /// <summary>
    /// Fail to remove 4x test normal item because quantity is greater than the current amount.
    /// </summary>
    [Test]
    public void TestRemoveQuantityGreaterQuantityFail()
    {
        Assert.IsFalse(_inventory.RemoveQuantity(0, 4));
    }
    #endregion

    /// <summary>
    /// Completely clear inventory list.
    /// </summary>
    [Test]
    public void TestRemoveAllPass()
    {
        _inventory.RemoveAll();
        Assert.AreEqual(_inventory.GetInventorySize(), 0);
    }
}
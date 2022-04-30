
using System.Collections.Generic;
using System.Reflection;

public class Inventory
{
    public const int MAXQUANTITY = 10;
    public List<InventoryItem> items;

    public Inventory()
    {
        items = new List<InventoryItem>();
    }

    #region Add Items
    /// <summary>
    /// 
    /// </summary>
    /// <param name="item">Item to be added to the Inventory.</param>
    public bool AddItem(Item item)
    {
        if (GetItemById(item.id) != null)
        {
            Logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), "Item already exists");
            return false;
        }

        items.Add(new InventoryItem(item, 0));
        Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("{0} added to inventory", item.name));
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item">Item reference for the amount to be added to. If the item doesn't exist then adds the item to the inventory.</param>
    /// <param name="quantity">Quantity to be added to the item in the inventory.</param>
    public void AddQuantity(Item item, int quantity)
    {
        if(GetItemById(item.id) == null)
        {
            items.Add(new InventoryItem(item, quantity));
        } 
        else
        {
            InventoryItem existingItem = GetItemById(item.id);
            existingItem.quantity += quantity;
        }

        Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("{0}x {1} added to inventory", quantity, item.name));
    }
    #endregion

    #region Get Items
    /// <summary>
    /// Get item from list by it's ID.
    /// </summary>
    /// <param name="id">The id of the item looked for.</param>
    /// <returns></returns>
    public InventoryItem GetItemById(int id)
    {
        foreach(InventoryItem invItem in items)
        {
            if (invItem.item.id == id)
            {
                Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Got {0} from inventory", invItem.item.name));
                return invItem;
            }

        }
        Logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), string.Format("Item Id: {0} not found", id));
        return null;
    }

    /// <summary>
    /// Get item from list by its name. Name must match exactly, otherwise will return null.
    /// </summary>
    /// <param name="name">The name of the item looked for.</param>
    /// <returns></returns>
    public InventoryItem GetItemByName(string name)
    {
        foreach (InventoryItem invItem in items)
        {
            if (invItem.item.name == name)
            {
                Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Got {0} from inventory", invItem.item.name));
                return invItem;
            }

        }
        Logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), string.Format("Item Name: {0} not found", name));
        return null;
    }
    #endregion

    #region Remove Items
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">The id of the item to be removed.</param>
    /// <returns>Returns whether or not an item was able to be removed</returns>
    public bool RemoveItemById(int id)
    {
        InventoryItem itemToRemove = null;
        foreach (InventoryItem invItem in items)
        {
            if (invItem.item.id == id)
            {
                itemToRemove = invItem;
            }

        }
        if (itemToRemove == null)
        {
            Logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), string.Format("Item Id: {0} not found", id));
            return false;
        }

        items.Remove(itemToRemove);
        Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Removed Item Id: {0}", id));
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">The name of the item to be removed.</param>
    /// <returns>Returns whether or not an item was able to be removed</returns>
    public bool RemoveItemByName(string name)
    {
        InventoryItem itemToRemove = null;
        foreach (InventoryItem invItem in items)
        {
            if (invItem.item.name == name)
                itemToRemove = invItem;

        }
        if (itemToRemove == null)
        {
            Logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), string.Format("{0} not found", name));
            return false;
        }

        items.Remove(itemToRemove);
        Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Removed {0}", name));
        return true;
    }

    /// <summary>
    /// Removes specified amount of items from the inventory by id. Will return false the amount is greater than
    /// the item's current quantity, otherwise if the amount is the same the item will be removed from the list.
    /// </summary>
    /// <param name="id">The id of the item to have the quantity removed from.</param>
    /// <param name="quantity">The amount of items to be removed.</param>
    /// <returns>Returns whether or not an item was able to be removed.</returns>
    public bool RemoveQuantity(int id, int quantity)
    {
        InventoryItem itemToRemove = null;
        foreach (InventoryItem invItem in items)
        {
            if (invItem.item.id == id)
                itemToRemove = invItem;
        }
        if (itemToRemove == null)
        {
            Logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), string.Format("Item Id: {0} not found", id));
            return false;
        }

        if(quantity > itemToRemove.quantity)
        {
            Logger.WriteWarningToLog(MethodBase.GetCurrentMethod(), string.Format("Quantity is greater than Item Id: {0}'s current quantity", id));
            return false;
        }

        if(itemToRemove.quantity == quantity)
        {
            items.Remove(itemToRemove);
            Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Removed Item Id: {0}", id));
            return true;
        }

        itemToRemove.quantity -= quantity;
        Logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Removed {0}x Item Id: {0}", quantity, id));
        return true;
    }

    /// <summary>
    /// Clears the inventory.
    /// </summary>
    public void RemoveAll()
    {
        items.Clear();
    }
    #endregion

    /// <returns>The current length of the inventory.</returns>
    public int GetInventorySize()
    {
        return items.Count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<string> Print()
    {
        List<string> InventoryItemList = new List<string>();

        foreach(InventoryItem invItem in items)
        {
            InventoryItemList.Add(string.Format("Item Id: {0}, Item Name: {1}, Quantity: {2} \n", invItem.item.id, invItem.item.name, invItem.quantity));
        }

        return InventoryItemList;
    }

    public class InventoryItem
    {
        public Item item;
        public int quantity;

        public InventoryItem(Item item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }
    }
}

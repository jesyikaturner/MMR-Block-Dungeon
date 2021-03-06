
using System.Collections.Generic;
using System.Reflection;

public class Inventory
{
    public const int MAXQUANTITY = 10;
    public List<InventoryItem> items;

    private readonly Logger _logger = Logger.Instance;

    public Inventory()
    {
        items = new List<InventoryItem>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item">The item to be added.</param>
    /// <param name="quantity">[Optional] Quantity of the item to be added. Default is 1.</param>
    public void AddQuantity(Item item, int quantity = 1)
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

        _logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("{0}x {1} added to inventory", quantity, item.name));
    }

    #region Get Items
    /// <summary>
    /// Get item from list by it's ID.
    /// </summary>
    /// <param name="id">The id of the item looked for.</param>
    /// <returns>The item found with a typeof(InventoryItem).</returns>
    public InventoryItem GetItemById(int id)
    {
        foreach(InventoryItem invItem in items)
        {
            if (invItem.item.id == id)
            {
                _logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Got {0} from inventory", invItem.item.name));
                return invItem;
            }

        }
        _logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), string.Format("Item Id: {0} not found", id));
        return null;
    }

    /// <summary>
    /// Get item from list by its name. Name must match exactly, otherwise will return null.
    /// </summary>
    /// <param name="name">The name of the item looked for.</param>
    /// <returns>The item found with a typeof(InventoryItem).</returns>
    public InventoryItem GetItemByName(string name)
    {
        foreach (InventoryItem invItem in items)
        {
            if (invItem.item.name == name)
            {
                _logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Got {0} from inventory", invItem.item.name));
                return invItem;
            }

        }
        _logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), string.Format("Item Name: {0} not found", name));
        return null;
    }
    #endregion

    #region Remove Items
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">The id of the item to be removed.</param>
    /// <returns>Whether or not an item was able to be removed</returns>
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
            _logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), string.Format("Item Id: {0} not found", id));
            return false;
        }

        items.Remove(itemToRemove);
        _logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Removed Item Id: {0}", id));
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">The name of the item to be removed.</param>
    /// <returns>Whether or not an item was able to be removed</returns>
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
            _logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), string.Format("{0} not found", name));
            return false;
        }

        items.Remove(itemToRemove);
        _logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Removed {0}", name));
        return true;
    }

    /// <summary>
    /// Removes specified amount of items from the inventory by id. Will return false the amount is greater than
    /// the item's current quantity, otherwise if the amount is the same the item will be removed from the list.
    /// </summary>
    /// <param name="id">The id of the item to have the quantity removed from.</param>
    /// <param name="quantity">The amount of items to be removed.</param>
    /// <returns>Whether or not an item was able to be removed.</returns>
    public bool RemoveQuantity(int id, int quantity = 1)
    {
        InventoryItem itemToRemove = null;
        foreach (InventoryItem invItem in items)
        {
            if (invItem.item.id == id)
                itemToRemove = invItem;
        }
        if (itemToRemove == null)
        {
            _logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), string.Format("Item Id: {0} not found", id));
            return false;
        }

        if(quantity > itemToRemove.quantity)
        {
            _logger.WriteWarningToLog(MethodBase.GetCurrentMethod(), string.Format("Quantity is greater than Item Id: {0}'s current quantity", id));
            return false;
        }

        if(itemToRemove.quantity == quantity)
        {
            items.Remove(itemToRemove);
            _logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Removed Item Id: {0}", id));
            return true;
        }

        itemToRemove.quantity -= quantity;
        _logger.WriteSuccessToLog(MethodBase.GetCurrentMethod(), string.Format("Removed {0}x Item Id: {0}", quantity, id));
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
    /// <returns>A string list of what's currently in the inventory list.</returns>
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

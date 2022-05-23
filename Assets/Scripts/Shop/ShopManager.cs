using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private Inventory _shopInventory;
    private readonly Logger _logger = Logger.Instance;

    public ShopManager()
    {
        _shopInventory = new Inventory();
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetupShopInventory()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="playerInventory">A reference to the player's inventory.</param>
    /// <param name="id">The id of the item to be sold.</param>
    /// <param name="quantity">The quantity of the item to be sold.</param>
    /// <returns>Whether or not the item sucessfully sold.</returns>
    public bool SellItem(PlayerInventory playerInventory, int id, int quantity)
    {
        Inventory.InventoryItem playerItem = playerInventory.GetItemById(id);

        if(playerItem == null)
        {
            _logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), "Item doesn't exist in player inventory");
            return false;
        }

        if(playerItem.item.price == 0)
        {
            // display error to user - unable to sell item. item cannot be sold.
            _logger.WriteErrorToLog(MethodBase.GetCurrentMethod(), string.Format("{0} cannot be sold", playerItem.item.name));
            return false;
        }

        if (playerInventory.RemoveQuantity(playerItem.item.id, quantity))
        {
            playerInventory.TotalMoney += (playerItem.item.price / 2) * quantity;
            _shopInventory.AddQuantity(playerItem.item, quantity);
            // display success to user - item sold.
            // TODO: Logger here.
            return true;
        }
        // display error to user - unable to sell item. selected quantity is greater then available amount.
        // TODO: Logger here.
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="playerInventory">A reference to the player's inventory.</param>
    /// <param name="id">The id of the item to be bought.</param>
    /// <param name="quantity">The quantity of the item to be bought.</param>
    /// <returns>Whether or not the item was sucessfully bought.</returns>
    public bool BuyItem(PlayerInventory playerInventory, int id, int quantity)
    {
        Inventory.InventoryItem shopItem = _shopInventory.GetItemById(id);

        if (shopItem == null)
        {
            // TODO: Logger error here.
            return false;
        }



        return false;
    }

    private void CreatePossibleStock()
    {

    }

    private void Stock()
    {

    }
}

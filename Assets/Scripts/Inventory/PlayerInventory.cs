

public class PlayerInventory : Inventory
{
    public int TotalMoney { get; set; }

    public PlayerInventory():base()
    {
        // TODO: needs to populate money with playerinfo from database
    }

}

using DungeonsAndCodeWizards.Models;

public class ItemFactory
{
    public Item ProduceItem(string itemType)
    {
        Item item = null;

        switch (itemType)
        {
            case "ArmorRepairKit":
                item = new ArmorRepairKit();
                break;
            case "HealthPotion":
                item = new HealthPotion();
                break;
            case "PoisonPotion":
                item = new PoisonPotion();
                break;
        }

        return item;
    }
}

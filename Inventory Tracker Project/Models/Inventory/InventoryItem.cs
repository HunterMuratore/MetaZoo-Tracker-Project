using Inventory_Tracker_Project.Enums.Inventory;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inventory_Tracker_Project.Models.Inventory
{
    [BsonIgnoreExtraElements]
    public class InventoryItem
    {
        public InventoryItem(InventoryItemCondition condition, string name, string edition, int purchasePrice, int purchaseQuantity, BsonObjectId id)
        {
            Condition = condition;
            Name = name;
            Edition = edition;
            PurchasePrice = purchasePrice;
            PurchaseQuantity = purchaseQuantity;
            Id = id;
        }

        public InventoryItemCondition Condition { get; }
        public string Name { get; }
        public string Edition { get; }
        public int PurchasePrice { get; }
        public int PurchaseQuantity { get; }
        public BsonObjectId Id { get; } 
    }
}

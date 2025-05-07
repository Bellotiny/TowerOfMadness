using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryController : MonoBehaviour
{
    [SerializeField] private Transform iSlot;
    [SerializeField] private ItemController itemController;
    private Dictionary<InventoryItem, ItemController> itemToSlotMap = new Dictionary<InventoryItem, ItemController>();

    public void InitInventoryController(Inventory inventory){
        var itemMap = inventory.GetAllItems();
        foreach(var item in itemMap){
            CreateOrUpdateSlot(inventory,item.Key , item.Value);
        }
    }
    public void CreateOrUpdateSlot(Inventory inventory,InventoryItem item, int icount){
        if(!itemToSlotMap.ContainsKey(item)){
            var slot = CreateSlot(inventory,item, icount);
            itemToSlotMap.Add(item, slot);
        }else{
            UpdateSlot(item,icount);
        }
    }

    public void UpdateSlot(InventoryItem item, int icount){
        itemToSlotMap[item].UpdateItemCount(icount);
    }
    public ItemController CreateSlot(Inventory inventory, InventoryItem item, int icount) {
        var slot = Instantiate(itemController, iSlot);
        slot.InitSlot(item.GetSprite(), icount);
        slot.AssignButtonCallback(()=>inventory.AssignItem(item));
        return slot;
    }
    public void DestroySlot(InventoryItem item) {
        Destroy(itemToSlotMap[item].gameObject);
        itemToSlotMap.Remove(item);
    }
}

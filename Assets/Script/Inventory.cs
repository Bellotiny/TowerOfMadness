using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private List<ItemWrapper> items = new List<ItemWrapper>();
    [SerializeField] private InventoryController inventoryUI; //the reprsentation in the ui   
    private Dictionary<InventoryItem, int> itemToCount = new Dictionary<InventoryItem, int>();
    private InventoryController _InventoryC;
    private InventoryController InventoryC{
        get{
            if(!_InventoryC){
                _InventoryC = Instantiate(inventoryUI, FindObjectOfType<Canvas>().transform.GetChild(0));
            }
            return _InventoryC;
        }
    }
    public int maxItemCount = 6;
/**
 * function to initialize the inventory
 */
    public void InitInventory(){
        for(int i = 0; i < maxItemCount; i++){
            itemToCount.Add(items[i].GetItem(), items[i].GetItemCount());
        }
        inventoryUI.InitInventoryController(this);
    }
/**
 * function to assign the item the user is going to use
 * @param item is an inventory item object
 */
    public void AssignItem(InventoryItem item){
        //to do something with the item
        Debug.Log("this is for test, require further code for implementation");
    }

    public Dictionary<InventoryItem, int> GetAllItems(){
        return itemToCount;
    }

    public void AddItem(InventoryItem item, int count){
        int currentItemCount;
        if (itemToCount.TryGetValue(item, out currentItemCount))
        {
            itemToCount[item] = currentItemCount + count;
            inventoryUI.UpdateSlot(item, currentItemCount + count);
        }else{
            itemToCount.Add(item,count);
            inventoryUI.CreateSlot(this,item, itemToCount[item]);
        }
        
    }
    public void RemoveItem(InventoryItem item, int count){
        int currentItemCount;
        if (itemToCount.TryGetValue(item, out currentItemCount))
        {
            itemToCount[item] = currentItemCount - count;
            if (currentItemCount - count <=0){
                inventoryUI.DestroySlot(item);
            }else{
                inventoryUI.UpdateSlot(item, currentItemCount - count);
            }
        }else{
            Debug.Log("not existing item");
        }
    }
}

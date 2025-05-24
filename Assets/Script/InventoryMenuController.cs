using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    private bool isInventoryVisible = false;
    private bool canOpenInventory = false;

    void Update()
    {
        if (canOpenInventory && Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

     public void ToggleInventory()
    {
        isInventoryVisible = !isInventoryVisible;
        inventoryPanel.SetActive(isInventoryVisible);

        if (isInventoryVisible)
            InventoryManager.Instance.RefreshUI();
    }

    public void EnableInventoryAccess()
    {
        canOpenInventory = true;
    }
    
    
}

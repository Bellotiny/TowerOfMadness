using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    private bool isInventoryVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventoryVisible = !isInventoryVisible;
            inventoryPanel.SetActive(isInventoryVisible);

            if (isInventoryVisible)
                InventoryManager.Instance.RefreshUI();
        }
    }
    
    
}

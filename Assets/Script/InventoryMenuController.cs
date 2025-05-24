using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenuController : MonoBehaviour
{
    public static InventoryMenuController Instance { get; private set; }
    [SerializeField] private GameObject inventoryPanel;
    private bool isInventoryVisible = false;
    private bool canOpenInventory = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: If you want it to persist between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
        canOpenInventory = !canOpenInventory;
    }
    
    
}

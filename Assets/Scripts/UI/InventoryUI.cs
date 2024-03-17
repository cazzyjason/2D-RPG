using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject InventoryPanel;
    public Player player;
    public List<SlotUI> slots = new List<SlotUI>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }
    }

    //開關邏輯都在以下做，第一個if描述"非開時啟動"第二個if則代表否則關
    public void ToggleInventory()
    {
        if (!InventoryPanel.activeSelf)
        {
            InventoryPanel.SetActive(true);
            Setup();
        }
        else
        {
            InventoryPanel.SetActive(false);
        }
    }

    void Setup()
    {
        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].type != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                    //for迴圈會依序掃每一格 及為i，而slots是SlotUI類
                    //所以有SetItem方法，他的parameter則引用"真正"的玩家slot
                    //及為inventory的格數
                    //這行代碼指示把玩家slot類用forloop裝到SlotUI的List裡
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }
}

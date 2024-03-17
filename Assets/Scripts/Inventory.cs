using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public CollectableType type;
        public int count;
        public int maxAllowed;

        public Sprite icon;

        public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxAllowed = 64;
        }
        //以上建構子說明slot類被創建會初始化 最大幾格、裝了多少、裝了什麼(type)
        //而這都還只是一格

        public bool CanAddItem()
        {
            if (count < maxAllowed)
            {
                return true;
            }

            return false;
        }

        public void AddItem(Collectable item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }

    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();

            //專門裝slot的slots列表
            slots.Add(slot);
        }
    }
    //以上Inventory建構子說明初始化會有創建格子並裝入List


    //以下是撿拾物品後"放哪"的邏輯
    public void Add(Collectable item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            //if函式在foreach中循環檢查哪格是空位 將優先放置物品
            if (slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    }
}

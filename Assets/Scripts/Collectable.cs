using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        //當觸發OnTriggerEnter2D 程式不知道是誰觸發了 只知道觸發就必須執行
        //而如下這個if函式也很孤立的只知道執行player是否是null，不是則觸發
        if (player)
        {
            //parameter中的this指的是這個Class本身
            //而從inventory的代碼中可以窺見，一切都以Collectable.***為主來引用
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, POTATO_SEED
}

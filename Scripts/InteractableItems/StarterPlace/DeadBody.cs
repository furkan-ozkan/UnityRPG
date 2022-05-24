using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBody : MonoBehaviour,IInteraction
{
    private DropItem _dropItem;
    public Item[] item;

    private void Start()
    {
        _dropItem = GameObject.FindGameObjectWithTag("GeneralScripts").GetComponent<DropItem>();
    }
    
    // Uses IInteraction metod and usin DropItems metod in DropItem Class. 
    public void Action()
    {
        _dropItem.DropItems(item);
        Destroy(gameObject.GetComponent<DeadBody>());
    }
}

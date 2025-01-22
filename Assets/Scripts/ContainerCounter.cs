using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerObjectGrabbed; 

    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.Prefab);
            kitchenObjectTransform.GetComponent<KitchenObjects>().SetKitchenObjectParent(player);
            OnPlayerObjectGrabbed?.Invoke(this,EventArgs.Empty);
        }

    }

}

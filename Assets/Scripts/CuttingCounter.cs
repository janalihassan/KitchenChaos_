using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectsSO cutKitchenObjectSO;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //Counter Dont have kitchen Object
            if (player.HasKitchenObject())
            {
                //Player is Carrying something
                player.GetKitchenObjects().SetKitchenObjectParent(this);
            }
            else
            {
                //Player is not carrying something
            }
        }
        else
        {
            //There is Kitchen Object on Counter
            if (player.HasKitchenObject())
            {
                // Player is carrying something
            }
            else
            {
                //Player is not Carrying Something
                GetKitchenObjects().SetKitchenObjectParent(player);

            }
        }
    }
    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject()) { 
            GetKitchenObjects().DestroySelf();
            KitchenObjects.SpawningKitchenObject(cutKitchenObjectSO,this);
        }
    }
}

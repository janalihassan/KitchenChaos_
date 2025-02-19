using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;



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



}

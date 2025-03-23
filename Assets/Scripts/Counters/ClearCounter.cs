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
                if (player.GetKitchenObjects().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // Player is Holding a plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObjects().GetKitchenObjectSO()))
                    {
                        GetKitchenObjects().DestroySelf();
                    }

                }
                else
                {
                    // Player is not Holding Plate But something else
                    if (GetKitchenObjects().TryGetPlate(out plateKitchenObject))
                    {
                        //Counter is holding a plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObjects().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObjects().DestroySelf();
                        }
                    }
                }    
            }
            else
            {
                //Player is not Carrying Something
                GetKitchenObjects().SetKitchenObjectParent(player);

            }
        }



    }
}

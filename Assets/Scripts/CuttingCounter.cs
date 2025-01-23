using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cutKitchenObjectSOArray;
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //Counter Dont have kitchen Object
            if (player.HasKitchenObject())
            {
                //Player is Carrying something That can be Cut
                if (HasRecipeWithInput(player.GetKitchenObjects().GetKitchenObjectSO()))
                {
                    player.GetKitchenObjects().SetKitchenObjectParent(this);
                }
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
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObjects().GetKitchenObjectSO())) {
            // Has KitchenObject AND can be cut
            KitchenObjectsSO OutputKitchenObjectSO = GetOutputForInput(GetKitchenObjects().GetKitchenObjectSO());

            GetKitchenObjects().DestroySelf();
            KitchenObjects.SpawningKitchenObject(OutputKitchenObjectSO,this);
        }
    }
    private bool HasRecipeWithInput(KitchenObjectsSO inputKitchenObjectSo)
    {
        foreach (CuttingRecipeSO CuttingObject in cutKitchenObjectSOArray)
        {
            if (CuttingObject.InputSO == inputKitchenObjectSo)
            {
                return true;
            }
        }
        return false;
    }

     private KitchenObjectsSO GetOutputForInput(KitchenObjectsSO inputKitchenObjects)
    {
        foreach(CuttingRecipeSO CuttingObject in cutKitchenObjectSOArray)
        {
            if(CuttingObject.InputSO == inputKitchenObjects)
            {
                return CuttingObject.OutputSO;
            }
        }
        return null;
    }
}

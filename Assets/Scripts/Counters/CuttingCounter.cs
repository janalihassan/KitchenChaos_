using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter,IHasProgress
{
    [SerializeField] private CuttingRecipeSO[] cutKitchenObjectSOArray;

    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler OnCut;
   


    private int cuttingProgress;
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

                    cuttingProgress = 0;
                    CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObjects().GetKitchenObjectSO());
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = (float)cuttingProgress / cuttingRecipeSO.CuttingProgressMax
                    });
                   
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
                if (player.GetKitchenObjects().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // Player is Holding a plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObjects().GetKitchenObjectSO()))
                    {
                        GetKitchenObjects().DestroySelf();
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
    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObjects().GetKitchenObjectSO())) {
            // Has KitchenObject AND can be cut

            cuttingProgress++;
            OnCut?.Invoke(this,EventArgs.Empty);
            CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObjects().GetKitchenObjectSO());
            OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
            {
                progressNormalized = (float)cuttingProgress / cuttingRecipeSO.CuttingProgressMax
            });
            if (cuttingProgress >= cuttingRecipeSO.CuttingProgressMax)
            {

                KitchenObjectsSO OutputKitchenObjectSO = GetOutputForInput(GetKitchenObjects().GetKitchenObjectSO());

                GetKitchenObjects().DestroySelf();
                KitchenObjects.SpawningKitchenObject(OutputKitchenObjectSO, this);
            }
        }
    }
    private bool HasRecipeWithInput(KitchenObjectsSO inputKitchenObjectSo)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSo);
       return cuttingRecipeSO != null;
    }

     private KitchenObjectsSO GetOutputForInput(KitchenObjectsSO inputKitchenObjects)
    {
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjects);
        if (cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.OutputSO;
        }
        else
        {
            return null;
        }
    }

    private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectsSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO CuttingObject in cutKitchenObjectSOArray)
        {
            if (CuttingObject.InputSO == inputKitchenObjectSO)
            {
                return CuttingObject;
            }
        }
        return null;
    }
}

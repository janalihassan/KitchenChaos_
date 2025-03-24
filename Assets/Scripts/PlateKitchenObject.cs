using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObjects
{

    public event EventHandler<OnIngredientAddedEventArgs> onIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectsSO KitchenObjectsSO;
    }

    [SerializeField] private List<KitchenObjectsSO> validKitchenObjectSO;
    private List<KitchenObjectsSO> kitchenObjectsSOList;

    private void Awake()
    {
        kitchenObjectsSOList = new List<KitchenObjectsSO>();
    }

    public bool TryAddIngredient(KitchenObjectsSO kitchenObjectsSO)
    {
        if (!validKitchenObjectSO.Contains(kitchenObjectsSO)) { 
            //Not a Valid Ingredient
            return false;
        }
        if (kitchenObjectsSOList.Contains(kitchenObjectsSO))
        {
            //already had this Ingredient
            return false;
        }
        else
        {
            // Ingredient Added
            kitchenObjectsSOList.Add(kitchenObjectsSO);
            onIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs { 
                KitchenObjectsSO = kitchenObjectsSO
            });
            return true;
        }
    }
    public List<KitchenObjectsSO> GetKitchenObjectsSOs() {
        return kitchenObjectsSOList;
    }
}

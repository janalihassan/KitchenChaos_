using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObjects
{

    [SerializeField] private List<KitchenObjectsSO> validKitchenObjectSO;
    private List<KitchenObjectsSO> kitchenObjectsSOList;

    private void Awake()
    {
        kitchenObjectsSOList = new List<KitchenObjectsSO>();
    }

    public bool TryAddIngredient(KitchenObjectsSO kitchenObjectsSO)
    {
        if (!validKitchenObjectSO.Contains(kitchenObjectsSO)) { 
            //Not a Valid Indredient
            return false;
        }
        if (kitchenObjectsSOList.Contains(kitchenObjectsSO))
        {
            return false;
        }
        else
        {
            kitchenObjectsSOList.Add(kitchenObjectsSO);
            return true;
        }
    }
}

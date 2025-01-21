using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour,IkitchenObjectParent
{
    [SerializeField] private KitchenObjectsSO kitchenObjectsSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObjects kitchenObjects;


    public void Interact(Player player)
    {
        if (kitchenObjects == null)
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.Prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObjects>().SetKitchenObjectParent(this);
        }
       else
        {
            kitchenObjects.SetKitchenObjectParent(player);
        }

    }

    public Transform GetObjectFollowtransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObjects kitchenObject)
    {
        this.kitchenObjects = kitchenObject;
    }
    public KitchenObjects GetKitchenObjects()
    {
        return kitchenObjects;
    }
    public void ClearKitchenObject() { 
        kitchenObjects = null; 
    }
    public bool HasKitchenObject()
    {
        return kitchenObjects != null;
    }

}

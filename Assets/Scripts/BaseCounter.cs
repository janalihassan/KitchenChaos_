using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IkitchenObjectParent
{
    [SerializeField] private Transform counterTopPoint;

    private KitchenObjects kitchenObjects;
    public virtual void Interact(Player player)
    {

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
    public void ClearKitchenObject()
    {
        kitchenObjects = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObjects != null;
    }
}

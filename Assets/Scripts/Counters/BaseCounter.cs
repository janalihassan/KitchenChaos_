using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IkitchenObjectParent
{

    public static event EventHandler OnAnyObjectPlacedHere;

    public static void ResestStaticData()
    {
        OnAnyObjectPlacedHere = null;
    }

    [SerializeField] private Transform counterTopPoint;

    private KitchenObjects kitchenObjects;
    public virtual void Interact(Player player)
    {

    }
    public virtual void InteractAlternate(Player player)
    {

    }
    public Transform GetObjectFollowtransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObjects kitchenObject)
    {
        this.kitchenObjects = kitchenObject;
        if (kitchenObject != null)
        {
            OnAnyObjectPlacedHere?.Invoke(this,EventArgs.Empty);
        }
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

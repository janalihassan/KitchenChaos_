using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IkitchenObjectParent 
{
    public Transform GetObjectFollowtransform();

    public void SetKitchenObject(KitchenObjects kitchenObject);

    public KitchenObjects GetKitchenObjects();

    public void ClearKitchenObject();

    public bool HasKitchenObject();

}

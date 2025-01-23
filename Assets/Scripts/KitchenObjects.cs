using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjects : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectsSO kitchenObjectsSo;
    private IkitchenObjectParent iKitchenParent;
    public KitchenObjectsSO GetKitchenObject()
    {
        return kitchenObjectsSo;
    }

    public void SetKitchenObjectParent(IkitchenObjectParent kitchenObjectParent)
    {
        if (this.iKitchenParent != null) { 
            this.iKitchenParent.ClearKitchenObject();
        }

        this.iKitchenParent = kitchenObjectParent;

        if (kitchenObjectParent.HasKitchenObject()) {
            Debug.LogError("Ikitchen Parent Already have an object");
        }

        kitchenObjectParent.SetKitchenObject(this);
        transform.parent = kitchenObjectParent.GetObjectFollowtransform();
        transform.localPosition = Vector3.zero;
    }
    public IkitchenObjectParent GetKitchenObjectParent()
    {
        return iKitchenParent;
    }
    public void DestroySelf()
    {
        iKitchenParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public static KitchenObjects SpawningKitchenObject(KitchenObjectsSO kitchenObjectsSO,IkitchenObjectParent ikitchenObjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.Prefab);
        KitchenObjects kitchenObjects = kitchenObjectTransform.GetComponent<KitchenObjects>();

        kitchenObjects.SetKitchenObjectParent(ikitchenObjectParent);
        return kitchenObjects;
    }
}

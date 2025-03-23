using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjects : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectsSO kitchenObjectsSo;
    private IkitchenObjectParent iKitchenParent;
    public KitchenObjectsSO GetKitchenObjectSO()
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

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
    {
        if (this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        else
        {
            plateKitchenObject= null;
            return false;
        }
    }
    public static KitchenObjects SpawningKitchenObject(KitchenObjectsSO kitchenObjectsSO,IkitchenObjectParent ikitchenObjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(kitchenObjectsSO.Prefab);
        KitchenObjects kitchenObjects = kitchenObjectTransform.GetComponent<KitchenObjects>();

        kitchenObjects.SetKitchenObjectParent(ikitchenObjectParent);
        return kitchenObjects;
    }
}

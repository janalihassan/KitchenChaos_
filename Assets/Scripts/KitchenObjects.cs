using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjects : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectsSO kitchenObjectsSo;
    private ClearCounter clearCounter;
    public KitchenObjectsSO GetKitchenObject()
    {
        return kitchenObjectsSo;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter != null) { 
            this.clearCounter.ClearKitchenObject();
        }

        this.clearCounter = clearCounter;

        if (clearCounter.HasKitchenObject()) {
            Debug.LogError("This Counter Already have an object");
        }

        clearCounter.SetKitchenObject(this);
        transform.parent = clearCounter.GetObjectFollowtransform();
        transform.localPosition = Vector3.zero;
    }
    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}

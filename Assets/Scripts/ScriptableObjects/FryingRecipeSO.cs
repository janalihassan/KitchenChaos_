using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject
{
    public KitchenObjectsSO InputSO;
    public KitchenObjectsSO OutputSO;
    public float fryingTimerMax;
}

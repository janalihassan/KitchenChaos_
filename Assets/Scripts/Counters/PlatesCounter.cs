using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField]private KitchenObjectsSO PlateKitchenObjectSO;
    private float spawnPlateTimer ;
    private float spawnPlateTimerMax = 4f;
    private int plateSpawnedAmount;
    private int plateSpawnedAmountMax = 4;

    private void Update()
    {
        spawnPlateTimer += Time.deltaTime;
        if (spawnPlateTimer > spawnPlateTimerMax)
        {
            spawnPlateTimer = 0f;
            if (KitchenGameManager.Instance.IsGamePlaying() && plateSpawnedAmount < plateSpawnedAmountMax)
            {
                plateSpawnedAmount++;
                OnPlateSpawned.Invoke(this,EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject()) {
            // player is Empty Handed

            if (plateSpawnedAmount > 0) 
            { 
                // There is Atleast 1 plater on Counter
                plateSpawnedAmount--;
                KitchenObjects.SpawningKitchenObject(PlateKitchenObjectSO, player); 
                OnPlateRemoved.Invoke(this,EventArgs.Empty);
            }
        }
    }
}

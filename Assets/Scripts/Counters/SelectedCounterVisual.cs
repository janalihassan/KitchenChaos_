using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField]
    private BaseCounter clearCounter;
    [SerializeField]
    private GameObject[] CounterVisual;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged; 
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArg e)
    {
        if (e.selectedCounter == clearCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach (GameObject CounterVisual in CounterVisual)
        {
            CounterVisual.SetActive(true);
        }
    }
    private void Hide()
    {
        foreach (GameObject CounterVisual in CounterVisual)
        {
            CounterVisual.SetActive(false);
        }
    }
}

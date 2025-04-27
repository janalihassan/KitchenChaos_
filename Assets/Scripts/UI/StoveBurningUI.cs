using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBurningUI : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;


    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
        Hide();
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burnShowProgessAmount = .5f;
        bool show = stoveCounter.isFried() && e.progressNormalized >= burnShowProgessAmount;
        if (show) { 
            Show();
        }
        else { 
            Hide();
        }
    }

    void Show()
    {
        gameObject.SetActive(true);

    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}

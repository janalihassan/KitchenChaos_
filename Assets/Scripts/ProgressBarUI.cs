using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;
    [SerializeField] private Image bar;

    private void Start()
    {
        cuttingCounter.OnProgressChanged += CuttingCounter_OnProgressChanged;
        bar.fillAmount = 0;
        Hide();
    }

    private void CuttingCounter_OnProgressChanged(object sender, CuttingCounter.OnProgressChangedEventArgs e)
    {
        bar.fillAmount = e.progressNormalized;
        if (e.progressNormalized == 0 || e.progressNormalized == 1)
        {
            Hide();
        }
        else {
            Show(); 
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

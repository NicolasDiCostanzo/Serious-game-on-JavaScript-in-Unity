using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndisplayHintPanel : MonoBehaviour
{
    [SerializeField] GameObject hintPanel;
    public void UndisplayPanel()
    {
        hintPanel.SetActive(false);
    }
}

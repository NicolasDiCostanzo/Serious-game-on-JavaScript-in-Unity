using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgression : MonoBehaviour
{
    public void ResetingProgression()
    {
        PlayerPrefs.SetInt("lvl1Done", 0);
        PlayerPrefs.SetInt("lvl2Done", 0);
        PlayerPrefs.SetInt("lvl3Done", 0);

        PlayerPrefs.SetInt("errorLvl1", 0);
        PlayerPrefs.SetInt("errorLvl2", 0);
        PlayerPrefs.SetInt("errorLvl3", 0);
    }
}

using UnityEngine.UI;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Toggle toggleUp;
    private Toggle toggleLvl2;
    private Toggle toggleWidth;

    [SerializeField] Text errorLvl1Txt;
    [SerializeField] Text errorLvl2Txt;
    [SerializeField] Text errorLvl3Txt;


    private void Start()
    {
        toggleUp = GameObject.Find("Toggle_up").GetComponent<Toggle>();
        toggleLvl2 = GameObject.Find("Toggle_lvl2").GetComponent<Toggle>();
        toggleWidth = GameObject.Find("Toggle_width").GetComponent<Toggle>();
    }

    void Update()
    {
        errorLvl1Txt.text = PlayerPrefs.GetInt("errorLvl1").ToString();
        errorLvl2Txt.text = PlayerPrefs.GetInt("errorLvl2").ToString();
        errorLvl3Txt.text = PlayerPrefs.GetInt("errorLvl3").ToString();

        if (PlayerPrefs.GetInt("lvl1Done") == 1)
        {
            toggleUp.isOn = true;
        }
        else
        {
            toggleUp.isOn = false;
        }

        if (PlayerPrefs.GetInt("lvl2Done") == 1)
        {
            toggleLvl2.isOn = true;
        }
        else
        {
            toggleLvl2.isOn = false;
        }

        if (PlayerPrefs.GetInt("lvl3Done") == 1)
        {
            toggleWidth.isOn = true;
        }
        else
        {
            toggleWidth.isOn = false;
        }
    }
}

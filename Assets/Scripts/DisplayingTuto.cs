using UnityEngine;

public class DisplayingTuto : MonoBehaviour
{
    [SerializeField] GameObject panelTutoDisappear;
    [SerializeField] GameObject panelTutoAppear;

    private GameObject wall1;

    public void TutoDisappear()
    {
        if(panelTutoDisappear.name != "Panel3")
        {
            panelTutoDisappear.SetActive(false);
            panelTutoAppear.SetActive(true);
        }
        else
        {
            wall1 = GameObject.FindGameObjectWithTag("Wall1");

            if (wall1.transform.position.y >= 4)
            {
                panelTutoDisappear.SetActive(false);
                panelTutoAppear.SetActive(true);
            }
        }

    }
}

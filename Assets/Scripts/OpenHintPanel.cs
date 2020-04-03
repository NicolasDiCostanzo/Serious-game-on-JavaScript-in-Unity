using UnityEngine.UI;
using UnityEngine;

public class OpenHintPanel : MonoBehaviour
{
    [SerializeField] GameObject hintPanel;
    [SerializeField] GameObject levelManager;

    public void DisplayHintPanel()
    {
        hintPanel.SetActive(true);

        Text hintPanelText = hintPanel.GetComponentInChildren<Text>();

        LevelManager levelManagerScript = levelManager.GetComponent<LevelManager>();
        int level = levelManagerScript.level;

        switch (level)
        {
            case 1:
                hintPanelText.text = "Write the following code on the coding field:\n\n wall.style.top = 40;\n\n\nIt will push the wall up and allows the skeleton to move!";
                break;

            case 2:
                hintPanelText.text = "To rotate the <tree> by 90 degrees use:\n\ntree.style.transform = rotate(90, deg);\n\nFor the <tomb>, use:\n tomb.style.left = 50;\n";
                break;

            case 3:
                hintPanelText.text = "To access the width or the height of the <statue>, you shoud use:\nstatue.style.width\n OR\n statue.style.height\n\nBut I advise to change its width to complete this level...";
                break;
        }
    }

}

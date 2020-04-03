using UnityEngine.UI;
using Cinemachine;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vc1;
    [SerializeField] CinemachineVirtualCamera vc2;
    [SerializeField] CinemachineVirtualCamera vc3;

    [SerializeField] InputField inputField;

    [SerializeField] GameObject lastPanel;

    [SerializeField] AudioSource youhouSound;
    [SerializeField] AudioClip taskCompletedSound;
    [SerializeField] AudioSource taskCompletedSource;

    public bool levelFinished = false;
    public int level = 1;

    private GameObject wall1;
    private GameObject tree;
    private GameObject tomb;
    private GameObject statue;
    private float time = 0;

    //PlayerPrefs variables
    private int lvl1Done = 0;
    private int lvl2Done = 0;
    private int lvl3Done = 0;

    private void Awake()
    {
        wall1 = GameObject.FindGameObjectWithTag("Wall1");
        tree = GameObject.FindGameObjectWithTag("Tree");
        tomb = GameObject.FindGameObjectWithTag("Tomb");
        statue = GameObject.FindGameObjectWithTag("Statue");

    }

    void Update()
    {
        switch (level)
        {
            case 1:
                vc1.Priority = 1;
                vc2.Priority = 0;
                vc3.Priority = 0;

                if (wall1.transform.position.y >= 4)
                {
                    PlayerPrefs.SetInt("lvl1Done", 1);
                    taskCompletedSource.PlayOneShot(taskCompletedSound, .4f);
                    LevelDone();
                }
                break;

            case 2:
                vc1.Priority = 0;
                vc2.Priority = 1;
                vc3.Priority = 0;

                if (tree.transform.rotation.eulerAngles.z <= 271)
                {
                    taskCompletedSource.PlayOneShot(taskCompletedSound, .2f);
                }

                if (tomb.transform.position.x >= 5)
                {
                    taskCompletedSource.PlayOneShot(taskCompletedSound, .2f);
                }

                if (tree.transform.rotation.eulerAngles.z <= 271 && tomb.transform.position.x >= 5)
                {
                    LevelDone();
                    PlayerPrefs.SetInt("lvl2Done", 1);
                }
                break;

            case 3:
                vc1.Priority = 0;
                vc2.Priority = 0;
                vc3.Priority = 1;

                if (statue.transform.localScale.x <= 1)
                {
                    taskCompletedSource.PlayOneShot(taskCompletedSound, .4f);
                    LevelDone();
                    PlayerPrefs.SetInt("lvl3Done", 1);
                    time += Time.deltaTime;
                    if (time >= 1)
                    {
                        lastPanel.SetActive(true);
                    }
                }

                break;

            case 4:

                break;
        }
    }

    private void LevelDone()
    {
        youhouSound.Play();
        inputField.Select();
        inputField.text = "";
        levelFinished = true;
        level++;
    }
}
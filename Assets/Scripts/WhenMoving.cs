using System.Collections;
using UnityEngine;

public class WhenMoving : MonoBehaviour
{
    public bool levelFinished = false;
    private float speed = .003f;

   // private Vector3[] arrivalPos = { new Vector3(1, 1, 1), new Vector3(.5f, 5, -20), new Vector3(.5f, 1, -38) };

    [SerializeField] GameObject levelManager;
    private LevelManager levelManagerScript;
    [SerializeField] Animator anim;
    [SerializeField] GameObject lastPanel;

    private int currentLevel;

    private void Start()
    {
        levelManagerScript = levelManager.GetComponent<LevelManager>();
    }
    // Update is called once per frame
    void Update()
    {
        currentLevel = levelManagerScript.level;
        if (levelManagerScript.levelFinished)
        {
            StartCoroutine(Moving());
        }
        else
        {
            StopAllCoroutines();
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrival1") || other.gameObject.CompareTag("Arrival2"))
        {
            anim.SetBool("walk", false);
            levelManager.GetComponent<LevelManager>().levelFinished = false;
            int currentLevel = levelManagerScript.level;

            if (currentLevel < 4) GameObject.Find("Tuto lvl" + (currentLevel).ToString()).transform.GetChild(0).gameObject.SetActive(true);

            if (other.gameObject.CompareTag("Arrival1"))
            {
                transform.Rotate(new Vector3(transform.rotation.x, 90, transform.rotation.z));
            }
        }
        else if (other.gameObject.CompareTag("LastArrival"))
        {
            lastPanel.SetActive(true);
        }
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("walk", true);
        transform.position = Vector3.Lerp(transform.position, GameObject.Find("Arrival" + (currentLevel-1).ToString()).transform.position, speed);
        yield break;
    }
}

using UnityEngine;

public class FollowingObject : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    public Vector3 offset;

    void Update()
    {
        transform.position = objectToFollow.transform.position + offset;
    }
}

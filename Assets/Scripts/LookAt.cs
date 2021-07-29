using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

    public void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
}

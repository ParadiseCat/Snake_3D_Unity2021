using UnityEngine;

public class Tail : MonoBehaviour
{
    public Transform target;
    public float targetDistance;

    public void Update()
    {
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;
        
        if (distance > targetDistance)
        {
            transform.position += direction.normalized * (distance - targetDistance);
            transform.LookAt(target);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{
    public float speed = 6;
    public float rotationSpeed = 60;
    private CharacterController _controller;
    GameObject food;
    Transform current;

    public void Start()
    {
        _controller = GetComponent<CharacterController>();
        current = transform;

        for (int i = 0; i < 3; i++)
        {
            Tail tail = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Tail>();
            tail.transform.position = current.transform.position - current.transform.forward * 2;
            tail.transform.rotation = transform.rotation;
            tail.target = current.transform;
            tail.targetDistance = 2;
            Destroy(tail.GetComponent<Collider>());
            current = tail.transform;
        }
    }

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, rotationSpeed * Time.deltaTime * horizontal, 0);
        _controller.Move(transform.forward * speed * Time.deltaTime);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.name == "Food")
        {
            Game.points += 10;
            food = GameObject.Find("Food");
            food.transform.position = new Vector3(Random.Range(-40, 41), 0, Random.Range(-40, 41));

            Tail tail = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Tail>();
            tail.transform.position = current.transform.position - current.transform.forward * 2;
            tail.transform.rotation = transform.rotation;
            tail.target = current.transform;
            tail.targetDistance = 2;
            Destroy(tail.GetComponent<Collider>());
            current = tail.transform;
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
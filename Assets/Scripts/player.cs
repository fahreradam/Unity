using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject bullet_prefab;
    public float health = 100;

    Vector2 move_input = Vector2.zero;
    Rigidbody my_rigid_body;

    // Start is called before the first frame update
    void Start()
    {
        print("hello");
        my_rigid_body = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = new Vector3(move_input.x, 0, move_input.y) * speed;
        my_rigid_body.velocity = vel;
    }

    private void FixedUpdate()
    {

    }

    // This method is not a "built-in" function -- we ahve to hook it up
    // in the PlayerInput 

    public void fire(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        if (value > 0.5f && context.performed)
        {
            print("value:" + value);
            GameObject new_list = GameObject.Instantiate(bullet_prefab);
            new_list.transform.position = transform.position;
            new_list.transform.rotation = transform.rotation;
        }

    }

    public void move(InputAction.CallbackContext context)
    {
        move_input = context.ReadValue<Vector2>();
        print("move: " + move_input);
    }


}

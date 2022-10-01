using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject bullet_prefab;
    public float health = 100;
    public GameObject UI;
    public Material normal_pupil_mat;
    public Material hurt_pupil_mat;

    MeshRenderer mesh_render_comp;


    Vector2 move_input;
    Rigidbody my_rigid_body;

    Transform mesh_transform;
    Transform aim_transform;

    // Used for doing the raycasr for mouse aiming
    Ray mouse_aim_ray;
    bool aim_needs_recalulate = false;
    Camera main_camera;

    // Start is called before the first frame update
    void Start()
    {
        my_rigid_body = GetComponent<Rigidbody>();
        

        mesh_transform = transform.Find("player_mesh");
        aim_transform = mesh_transform.Find("aim_point");

        main_camera = transform.Find("Main Camera").GetComponent<Camera>();

        mesh_render_comp = transform.Find("player_mesh").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        check_lose();
    }

    private void FixedUpdate()
    {
        Vector3 vel = new Vector3(move_input.x, 0, move_input.y) * speed;
        my_rigid_body.velocity = vel;

        if (aim_needs_recalulate)
        {
            // Turn off aiming until the mouse moves again
            aim_needs_recalulate = false;

            // Do the actaul raycast
            RaycastHit hit_result;
            string[] my_layers = { "Ground" };
            if (Physics.Raycast(mouse_aim_ray, out hit_result, Mathf.Infinity, LayerMask.GetMask(my_layers)))
            {
                //print("raycast hit " + hit_resault.point);
                Vector3 aim_pt = new Vector3(hit_result.point.x, mesh_transform.position.y, hit_result.point.z);
                mesh_transform.LookAt(aim_pt, Vector3.up);
            }
        }
    }

    // This method is not a "built-in" function -- we ahve to hook it up
    // in the PlayerInput 

    public void fire(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        if (value > 0.5f && context.performed)
        {
            GameObject new_list = GameObject.Instantiate(bullet_prefab);
            new_list.GetComponent<bullet>().UI = UI;
            new_list.transform.position = aim_transform.position;
            
            new_list.transform.rotation = aim_transform.rotation;
            new_list.transform.Rotate(Vector3.up, -90);
        }

    }

    public void move(InputAction.CallbackContext context)
    {
        move_input = context.ReadValue<Vector2>();
    }

    public void look_at(InputAction.CallbackContext context)
    {
        Vector2 mouse_offset = context.ReadValue<Vector2>();
        PlayerInput input_comp = GetComponent<PlayerInput>();
        if (input_comp.currentControlScheme == "Keyboard&Mouse")
        {
            Vector2 mouse_pos = Mouse.current.position.ReadValue();
            aim_needs_recalulate = true;
            mouse_aim_ray = main_camera.ScreenPointToRay(mouse_pos);

        }
    }

    public void reduce_health()
    {
        health -= 2 * Time.deltaTime;
        UI.GetComponent<ui_script>().set_health(health);
        mesh_render_comp.material = hurt_pupil_mat;
    }
    public void reset_pupil()
    {
        mesh_render_comp.material = normal_pupil_mat;
    }
    void check_lose()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}

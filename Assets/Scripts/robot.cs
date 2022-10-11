using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class robot : MonoBehaviour
{
    public float detection = 10;
    public float speed = 20;
    public GameObject teleporter;
    GameObject player;
    GameObject ground;
    public GameObject Particle;
    public Slider health_bar;

    Animator anim_comp;
    Rigidbody my_rigid_body;
    float time = 0;
    List<Vector3> local_ground;
    List<Vector3> global_ground;
    Vector3 direction = Vector3.zero;
    float wait_time = 10;
    public int health = 100;
    Quaternion original_rot;



    // Start is called before the first frame update
    void Start()
    {

        original_rot = transform.rotation;
        anim_comp = GetComponent<Animator>();
        my_rigid_body = GetComponent<Rigidbody>();

        global_ground = new List<Vector3>();
        ground = GameObject.Find("ground");
        local_ground = new List<Vector3>(ground.GetComponent<MeshFilter>().mesh.vertices);
        global_ground.Clear();
        foreach (var v in local_ground)
            global_ground.Add(ground.transform.TransformPoint(v));
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            kill();
        update_health();
    }

    private void FixedUpdate()
    {
        player = GameObject.Find("player");
        if (Mathf.Abs(player.transform.position.magnitude - transform.position.magnitude) <= detection)
            hunt();
        else
            wander();
    }

    void wander()
    {
        if (time <= 0)
        {
            anim_comp.SetBool("do_walk", false);
            direction = new Vector3(Random.Range(-global_ground[0].x, global_ground[0].x), transform.position.y, Random.Range(-global_ground[0].x, global_ground[0].x));
            transform.LookAt(direction);
            time = wait_time + time;
        }
        time = time - Time.deltaTime;
        walk();
    }

    void hunt()
    {
        anim_comp.SetBool("do_walk", true);
        transform.LookAt(player.transform.position);
        original_rot.y = transform.rotation.y;
        original_rot.w = transform.rotation.w;
        transform.rotation = original_rot;
        direction = (player.transform.position - transform.position);

        walk();
    }

    public void hit(int damage)
    {
        health -= damage;
    }

    private void walk()
    {
        anim_comp.SetBool("do_walk", true);
        my_rigid_body.velocity = direction.normalized * speed * Time.deltaTime;
    }

    private void update_health()
    {
        health_bar.value = health;
    }


    private void kill()
    {
        GameObject particle = GameObject.Instantiate(Particle);
        particle.transform.position = transform.position;

        teleporter.GetComponent<teleport>().num_enemies--;
        GameObject.Destroy(gameObject);

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            other.GetComponent<player>().reduce_health();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "player")
            other.GetComponent<player>().reset_pupil();
    }
}

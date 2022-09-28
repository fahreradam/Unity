using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour
{
    float state_timer = 2.0f;
    
    bool playing_walk = false;


    public float detection = 10;
    public float speed = 20;
    GameObject player;
    GameObject ground;

    bool hunting = false;
    Animator anim_comp;
    Rigidbody my_rigid_body;
    Ray area;
    float time = 0;
    List<Vector3> local_ground;
    List<Vector3> global_ground;
    



    // Start is called before the first frame update
    void Start()
    {
        anim_comp = GetComponent<Animator>(); 
        my_rigid_body = GetComponent<Rigidbody>();

        global_ground = new List<Vector3> ();
        ground = GameObject.Find("ground");
        local_ground = new List<Vector3>(ground.GetComponent<MeshFilter>().mesh.vertices);
        global_ground.Clear();
        foreach (var v in local_ground)
            global_ground.Add(ground.transform.TransformPoint(v));
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Vector3 direction = new Vector3(0,0,0);
        string[] my_layers = { "Ground" };
        RaycastHit hit_result;

        if (time <= 0)
        {
            anim_comp.SetBool("do_idle", true);
            direction = new Vector3(Random.Range(-global_ground[0].x, global_ground[0].x), transform.position.y, Random.Range(-global_ground[0].x, global_ground[0].x)).normalized;
            time = 5;
        }
        if (hunting)
        {
            anim_comp.SetBool("do_idle", true);
            anim_comp.SetBool("do_walk", false);
            hunting = false;
        }

        my_rigid_body.velocity = direction * speed * Time.deltaTime;
        time -= Time.deltaTime;
        

    }

    void hunt()
    {
        hunting = true;
        transform.LookAt(player.transform.position);
        Vector3 direction = (player.transform.position - transform.position).normalized;
        my_rigid_body.velocity = direction * speed * Time.deltaTime;
        print(player.transform.position);
        anim_comp.SetBool("do_walk", true);
    }
}

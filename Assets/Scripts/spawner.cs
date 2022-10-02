using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawn_time = 5;
    public int spawn_amount = 5;
    public int spawn_batch = 2;
    public int spawn_dist = 1;
    public GameObject teleporter;

    float start_time;
    int num_batches = 0;

    float radius;


    // Start is called before the first frame update
    void Start()
    {
        start_time = spawn_time;
        radius = Mathf.Deg2Rad * (360/spawn_amount);
    }

    // Update is called once per frame
    void Update()
    {

        if (num_batches < spawn_batch)
        {
            if (start_time <= 0)
            {
                spawn();
            }
            start_time -= Time.deltaTime;
        }
    }

    void spawn()
    {
        int temp_enemy = spawn_amount;
        while(temp_enemy > 0)
        {
            GameObject new_instance = GameObject.Instantiate(enemy);

            Vector3 offset = new Vector3(Mathf.Cos(radius * temp_enemy), 0, Mathf.Sin(radius * temp_enemy)) * spawn_dist;
            offset = offset + transform.position;
            new_instance.transform.position = new Vector3(offset.x, 0, offset.z);
            temp_enemy--;
            teleporter.GetComponent<teleport>().num_enemies++;
            new_instance.GetComponent<robot>().teleporter = teleporter;
            
        }
        start_time = spawn_time;
        num_batches++;
    }
}

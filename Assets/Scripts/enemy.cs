using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Material normal_pupil_mat;
    public Material aggro_pupil_mat;

    MeshRenderer mesh_render_comp;

    
    float material_timer = 2.0f;
    int health = 100;


    // Start is called before the first frame update
    void Start()
    {
        mesh_render_comp = GetComponent<MeshRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        material_timer -= Time.deltaTime;
        if (material_timer <= 0)
        {
            mesh_render_comp.material = aggro_pupil_mat;
        }

        if (health < 0)
            kill();
    }

    public void hit(int damage)
    {
        health -= damage;
    }

    private void kill()
    {
        GameObject.Destroy(gameObject);
    }

}

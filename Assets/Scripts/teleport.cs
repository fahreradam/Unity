using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    public GameObject spawner;
    public int num_enemies = 0;
    public float wait_time;
    // Start is called before the first frame update
    void Start()
    {
        wait_time = spawner.GetComponent<spawner>().spawn_time;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(wait_time >= -1)
            wait_time -= Time.deltaTime;
        else
        {
            if (num_enemies <= 0)
            {
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<CapsuleCollider>().enabled = true;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player")
        {
            if (SceneManager.GetActiveScene().name == "Level 1")
                SceneManager.LoadScene("Level 2");
            if (SceneManager.GetActiveScene().name == "Level 2")
                SceneManager.LoadScene("Win");            
        }
    }
}

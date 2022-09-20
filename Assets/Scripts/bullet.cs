using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            print("I'm going to ignore this...");
        }
        else
        {
            print("I hit " + other.gameObject.name);
            GameObject.Destroy(gameObject);
        }
        print(other.gameObject.name);
    }
}

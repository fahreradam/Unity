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
            // This is NOT where you want this code -- this is just a quick test
            GameObject ui_game_object = GameObject.Find("main_ui"); //SLOW!! Use sparingly
            ui_script ui_script = ui_game_object.GetComponent<ui_script>();
            ui_script.change_ui_score(42);

            print("I hit " + other.gameObject.name);
            GameObject.Destroy(gameObject);
        }
        print(other.gameObject.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject UI;



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
        if(other.gameObject.name != "player")
        {

            if (other.gameObject.name == "enemy Variant(Clone)")
            {
                other.GetComponent<robot>().hit(50);
                if (other.GetComponent<robot>().health <= 0)
                {
                    ui_script ui_script = UI.GetComponent<ui_script>();
                    ui_script.change_ui_score();
                }
            }

            GameObject.Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_script : MonoBehaviour
{
    TextMeshProUGUI score_value;
    public Slider health_value;


    // Start is called before the first frame update
    void Start()
    {
        score_value = transform.Find("score_value").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_ui_score(int new_value)
    {
        score_value.text = new_value.ToString();
    }

    public void set_health(float health)
    {
        health_value.value = health;
        print(health_value.value);
    }
}

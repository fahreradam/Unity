using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_script : MonoBehaviour
{
    TextMeshProUGUI score_value;
    public Slider health_value;
    private int current_score = 0;


    // Start is called before the first frame update
    void Start()
    {
        score_value = transform.Find("score_value").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_ui_score()
    {
        current_score ++;
        score_value.text = current_score.ToString();
    }

    public void set_health(float health)
    {
        health_value.value = health;
        print(health_value.value);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ui_script : MonoBehaviour
{
    TextMeshProUGUI score_value;


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
}

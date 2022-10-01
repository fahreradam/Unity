using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class title_ui : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void new_game()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void quit_game()
    {
        Application.Quit();
    }
}

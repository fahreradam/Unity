using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        buttons = transform.Find("Image").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            pause();
    }

    public void new_game()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void unpause()
    {
        buttons.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void quit()
    {
        Application.Quit();

    }

    public void pause()
    {
        buttons.SetActive(true);
        Time.timeScale = 0.0f;

    }
}

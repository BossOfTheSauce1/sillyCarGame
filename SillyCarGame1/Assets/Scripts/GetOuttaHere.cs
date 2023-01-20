using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOuttaHere : MonoBehaviour
{
    public GameObject leaveMenu;
    public bool exitMenu = false;


    // Start is called before the first frame update
    void Start()
    {
        leaveMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitMenu = !exitMenu;
            if (exitMenu == true)
            {
                leaveMenu.SetActive(true);
            }
            if (exitMenu == false)
            {
                leaveMenu.SetActive(false);
            }
        }
    }

   public void ExitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        exitMenu = false;
        leaveMenu.SetActive(false);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public GameObject title;
    public GameObject canvas;



    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        title.SetActive(title);
    }

    public void StartThing()
    {
        title.SetActive(false);
        canvas.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject creditsThing;
    public bool creditToTeam = false;

    // Start is called before the first frame update
    void Start()
    {
        creditsThing.SetActive(false);
    }

    public void EngineerIsCreditTeam()
    {
        creditToTeam = !creditToTeam;
        if (creditToTeam == true)
        {
            creditsThing.SetActive(true);
        }
        if (creditToTeam == false)
        {
            creditsThing.SetActive(false);
        }
    }
}

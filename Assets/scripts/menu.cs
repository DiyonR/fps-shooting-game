using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    
    public void loadOnePlayer()
    {
        SceneManager.LoadScene("player control");
    }
    public void Controls()
    {
        SceneManager.LoadScene("menu");
    }
    public void yes()
    {
        SceneManager.LoadScene("controls");
    }
    public void instructions()
    {
        SceneManager.LoadScene("instructions");
    }
}


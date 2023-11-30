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

// - after death interaction with menu fixed
// - add gun to player
// - finish map
// - text for the levels
// - checkpoint for each level
// - have a end boss
// - be able to go to menu when boss is killed
// - have right click make u go aim/ scope in 
// - make a enemy look like enemy with sword 



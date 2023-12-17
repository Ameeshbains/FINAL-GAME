using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    //This is to load the 1st button
    public void easy()
    {

        SceneManager.LoadSceneAsync(1);


    }

    //This is to load the 2nd button
    public void medium()
    {

        SceneManager.LoadSceneAsync(2);


    }


    //This is to load the 3rd button
    public void hard()
    {

        SceneManager.LoadSceneAsync(3);


    }



    //This is to load the 4rd button
    public void OpenUrl()
    {

        Application.OpenURL("https://github.com/Ameeshbains/GUNS-PHOBIA.git");


    }

    //This is to load the 1st button
    public void MainMenu()
    {

        SceneManager.LoadSceneAsync(0);


    }



    //--https://www.youtube.com/watch?v=3L8bDWLfO_8

    //--https://www.youtube.com/watch?v=DX7HyN7oJjE



}

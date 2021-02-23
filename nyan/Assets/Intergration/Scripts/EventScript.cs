using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    public enum stateUI
    {
        BuildMode,
        MainMode,
        MenuMode,
        OptionMode,
        MainMenuMode,

    };

    public bool isesc = false;

    public stateUI currentState;

    public Camera Build;
    public Camera Select;
    public GameObject BuildG;
    public GameObject SelectG;
    public string Split = "------------------";
    public GameObject MainUI;
    public GameObject BuildingUI;
    public GameObject MenuUI;
    public GameObject Options;
    public GameObject MainMenu;

    public GameObject Background;
    public GameObject Chalkboard;


    int k = 0;


    public GameObject Audio;
    private void Awake()
    {

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            isesc = !isesc;
            if(isesc)
            {
                OptionsMode();
            }
            else
            {
                MainMode();
            }
        }
    }

    public void BuildMode()
    {
        currentState = stateUI.BuildMode;
        Select.enabled = false;
        BuildG.SetActive(true);
        Build.enabled = true;
        SelectG.SetActive(false);

        BuildingUI.SetActive(true);
        MainUI.SetActive(false);


    }

    public void MainMode()
    {
        currentState = stateUI.MainMode;
        MainMenu.SetActive(false);

        Build.enabled = false;
        SelectG.SetActive(true);
        Select.enabled = true;
        BuildG.SetActive(false);

        MainUI.SetActive(true);
        BuildingUI.SetActive(false);
        MenuUI.SetActive(false);

        Options.SetActive(false);
        Chalkboard.SetActive(false);
        Background.SetActive(false);


        if (k == 0)
        {
            k++;
            Audio.GetComponent<AudioManager>().PlayMain();
            Audio.GetComponent<AudioManager>().Stop("Menu");
        }
    }

    public void MenuMode()
    {

        currentState = stateUI.MenuMode;


        MenuUI.SetActive(true);
        MainUI.SetActive(false);

    }



    public void OptionsMode()
    {
        currentState = stateUI.OptionMode;
        Options.SetActive(true);
        MainMenu.SetActive(false);
        MenuUI.SetActive(false);
        MainUI.SetActive(false);
        Chalkboard.SetActive(true);
        Background.SetActive(true);

    }

    public void Exit()
    {
        Application.Quit();

    }






}

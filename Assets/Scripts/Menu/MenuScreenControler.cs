using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreenControler : MonoBehaviour
{
    private GameObject GDResetScreen;
    private GameObject ImageScoreScreen;
    private int oldHighScore;
    private int newHighScore;
    private int lastScore;
    private int blobbsDestroyed;


    // Start is called before the first frame update
    void Start()
    {
        GDResetScreen = GameObject.FindWithTag("GDResetScreen");
        GDResetScreen.SetActive(false);
        ImageScoreScreen = GameObject.Find("ImageScoreScreen");
        scorescreenControl(0);

        // Loade Savefile from PlayerPrefs

        loadSave();
        Debug.Log(new Vector4(oldHighScore,newHighScore,lastScore,blobbsDestroyed));
        if (oldHighScore < lastScore)
        {
            newHighScore = lastScore;
            PlayerPrefs.SetInt("Highscore", lastScore);
            // Open Score Screen
            scorescreenControl(1);
        }
        else
        {
            newHighScore = oldHighScore;
        }

        // Set Scoreboard

        setScoreboard();

    }

    public void quitGame()
    {
        Debug.Log("Game shutting down. Good bye");
        Application.Quit();
    }

    public void startRun()
    {
        SceneManager.LoadScene("Game");
    }

    public void resetGameData(int ButtonDeff)
    {
        switch(ButtonDeff)
        {
            case 0:
                GDResetScreen.SetActive(true);
                toggleInteract(false);
                break;

            case 1:
                GDResetScreen.SetActive(false);
                toggleInteract(true);
                break;

            case 2:
                GDResetScreen.SetActive(false);
                PlayerPrefs.DeleteAll();
                Debug.Log("GameData Erased.");
                loadSave();
                setScoreboard();
                toggleInteract(true);
                break;

            default:
                Debug.LogError("ERROR: ButtonDeff Invalid!");
                break;
        }

    }

    public void toggleInteract(bool OnOff)
    {
        GameObject.Find("StartGameBTN").GetComponent<Button>().interactable = OnOff;
        GameObject.Find("ResetBTN").GetComponent<Button>().interactable = OnOff;
        GameObject.Find("QuitBTN").GetComponent<Button>().interactable = OnOff;
    }

    public void setScoreboard()
    {
        Text HS = GameObject.Find("HS").GetComponent<Text>();
        Text BP = GameObject.Find("BP").GetComponent<Text>();
        HS.text = ("HighScore: " + newHighScore);
        BP.text = ("Blobbs Ploped: " + blobbsDestroyed);
    }

    public void loadSave()
    {
        newHighScore = 0;
        blobbsDestroyed = PlayerPrefs.GetInt("BlobbsDestroyed", 0);
        oldHighScore = PlayerPrefs.GetInt("Highscore", 0);
        lastScore = PlayerPrefs.GetInt("LastScore", 0);
    }

    public void scorescreenControl(int OnOff)
    {
        switch (OnOff)
        {
            case 0:
                ImageScoreScreen.SetActive(false);
                toggleInteract(true);
                break;
            case 1:
                ImageScoreScreen.SetActive(true);
                ImageScoreScreen.GetComponentsInChildren<Text>()[1].text = newHighScore.ToString();
                toggleInteract(false);
                break;

        }
    }
        
}
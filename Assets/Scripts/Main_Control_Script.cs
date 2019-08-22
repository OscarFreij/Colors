using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Control_Script : MonoBehaviour
{
    // Start is called before the first frame update

    public Material[] MaterialColors;
    public float spawnDelay = 0;
    public GameObject blobbPrefab;
    public bool PplayerIsAlive;

    public int playerHealth;
    public int playerScore;
    public int playerHighScore;

    private float spawnTimer = 0;

    private bool playerIsAlive = true;
    private bool endIsTriggerd = false;
    public float switchTimer = 0.0f;
    public int blobbDestroyedInSesion = 0;


    void Start()
    {
        playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsAlive == true)
        {
            if (spawnTimer < spawnDelay)
            {
                spawnTimer = spawnTimer + Time.deltaTime;
            }
            else
            {
                spawnTimer = 0;
                Instantiate(blobbPrefab, new Vector3(17, 0.5f, 0), Quaternion.Euler(0, 0, 0));
                spawnDelay-= (Mathf.Pow(playerScore/100,2)/8);
                spawnDelay = Mathf.Clamp(spawnDelay, 0.5f, 10);
            }
        }

        if (endIsTriggerd == false)
        {
            if (playerHealth <= 0)
            {
                playerIsAlive = false;
                Debug.Log("Player Died. Cause: Out of Health");
            }

            if (playerIsAlive == false)
            {
                Debug.Log("Final Score - Player : " + playerScore);
                endIsTriggerd = true;
            }
        }

        if (endIsTriggerd == true && switchTimer < 2.0f)
        {
            switchTimer = switchTimer + Time.deltaTime;
        }
        else if (endIsTriggerd == true && switchTimer >= 2.0f)
        {
            Debug.Log("Saving gameData...");
            PlayerPrefs.SetInt("LastScore", playerScore);
            PlayerPrefs.SetInt("BlobbsDestroyed", PlayerPrefs.GetInt("BlobbsDestroyed",0)+blobbDestroyedInSesion);
            Debug.Log("gameData Saved!");
            SceneManager.LoadScene("Menu");
        }

        PplayerIsAlive = playerIsAlive;

    }

    void OnTriggerEnter(Collider collision)
    {
        if (playerIsAlive == true)
        {
            if (collision.gameObject.tag == "Blobb")
            {
                Destroy(collision.gameObject);
                playerIsAlive = false;
                Debug.Log("Player Died. Cause: "+'"'+"Blobb"+'"'+" hit center, Unlucky one mate...");
            }
        }
    }

}

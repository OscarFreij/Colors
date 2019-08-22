using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner_Control : MonoBehaviour
{

    private Material myMaterial;
    private Main_Control_Script Main_Control_Script;
    private Audio_Controler audioPlayer;
    private int myKey;
    // Start is called before the first frame update
    void Start()
    {
        myKey = int.Parse(gameObject.name.Substring(gameObject.name.Length-1));

        audioPlayer = GameObject.FindWithTag("AudioControl").GetComponent<Audio_Controler>();

        try
        {
            Main_Control_Script = GameObject.FindGameObjectWithTag("Player").GetComponent<Main_Control_Script>();
        }
        catch
        {
            Debug.LogError("ERROR: Corner did not find Main_Control_Script!");
        }

        myMaterial = Main_Control_Script.MaterialColors[myKey];
        gameObject.GetComponent<MeshRenderer>().material = myMaterial;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (Main_Control_Script.PplayerIsAlive == true)
        {
            if (collision.gameObject.tag == "Blobb")
            {
                if (collision.gameObject.GetComponent<Blobb_Controler>().PKey == myKey)
                {
                    // Add 1 Score Point
                    Main_Control_Script.playerScore += 1;
                    Main_Control_Script.blobbDestroyedInSesion += 1;
                    Debug.Log("1 Score Point Added!");
                    audioPlayer.PlayAudio(1);
                }
                else
                {
                    // Remove 1 Health Point
                    Main_Control_Script.playerHealth -= 1;
                    Debug.Log("1 Health Point Removed!");
                    audioPlayer.PlayAudio(2);
                }

                Destroy(collision.gameObject);
            }
        }
    }
}
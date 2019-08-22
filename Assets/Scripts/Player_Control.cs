using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    private float rotationStep = 90.0f;
    private float smooth = 10.0f;
    private float disiredAngle = 0.0f;
    private Audio_Controler audioPlayer;
    private Main_Control_Script Main_Control_Script;

    void Start()
    {
        audioPlayer = GameObject.FindGameObjectWithTag("AudioControl").GetComponent<Audio_Controler>();
        Main_Control_Script = gameObject.GetComponent<Main_Control_Script>();
    }
    void Update()
    {
        if (Main_Control_Script.PplayerIsAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                disiredAngle += rotationStep;
                audioPlayer.PlayAudio(0);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                disiredAngle -= rotationStep;
                audioPlayer.PlayAudio(0);
            }

            Quaternion target = Quaternion.Euler(0, disiredAngle, 0);

            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }
    }
}

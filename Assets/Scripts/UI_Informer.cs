using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Informer : MonoBehaviour
{
    private Main_Control_Script Main_Control_Script;
    private Text UI_Health;
    private Text UI_Score;
    
    // Start is called before the first frame update
    void Start()
    {
        Main_Control_Script = GameObject.FindGameObjectWithTag("Player").GetComponent<Main_Control_Script>();
        UI_Health = GameObject.Find("UI_Health").GetComponent<Text>();
        UI_Score = GameObject.Find("UI_Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UI_Health.text = ("Health: " + Main_Control_Script.playerHealth);
        UI_Score.text = ("Score: " + Main_Control_Script.playerScore);
    }
}

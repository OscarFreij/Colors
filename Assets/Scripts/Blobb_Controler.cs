using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blobb_Controler : MonoBehaviour
{
    // Initiate Private Variabels and Objects \\
    private GameObject Player;
    private Main_Control_Script Main_Control_Script;
    private MeshRenderer Mrenderer;
    private Rigidbody Brigidbody;

    private int Key;
    private float Speed = 8.0f;
    public int PKey;


    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
        Main_Control_Script = Player.GetComponent<Main_Control_Script>();

        Speed += Main_Control_Script.playerScore * 0.1f;

        Key = Random.Range(0, 4);

        Mrenderer = gameObject.GetComponent<MeshRenderer>();
        Mrenderer.material = Main_Control_Script.MaterialColors[Key];

        Brigidbody = gameObject.GetComponent<Rigidbody>();
        Brigidbody.velocity = new Vector3(-Speed, 0, 0);
        PKey = Key;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero          S { get; private set; } //singleton property

    [Header("Inscribed")]
    //these fields control the movement of the ship
    public float            speed = 30;
    public float            rollMult = -45;
    public float            pitchMult = 30;

    [Header("Dynamic")] [Range(0,4)]
    public float            shieldLevel = 1;

    void Awake(){
        if (S == null) {
            S = this; //set the singleton only if it's null
        } else {
            Debug.LogError("Hero.Awake() Attempted to assign second Hero.S!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //pull in information from the input class
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        //change transform.position based on the axes
        Vector3 pos = transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;
        transform.position = pos;

        //rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(vAxis*pitchMult,hAxis*rollMult, 0);
    }
}

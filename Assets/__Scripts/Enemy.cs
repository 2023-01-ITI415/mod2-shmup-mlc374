using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Inscribed")]
    public float speed   = 10f; //the movement speed is 10m/s
    public float fireRate = .3f; //seconds/shot (unused)
    public float health = 10; //damage needed to destroy enemy
    public int score = 100; //points earned for destroying this

    private BoundsCheck bndCheck;

    void Awake() {
        bndCheck = GetComponent<BoundsCheck>();
    }

    //this is a propery: a method that acts like a field
    public Vector3 pos{
        get{
            return this.transform.position;
        }
        set {
            this.transform.position = value;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();


    //check whether the enemy has gone off the screen
    if ( bndCheck.LocIs (BoundsCheck.eScreenLocs.offDown)){
        Destroy ( gameObject);
        }
    }

    //if ( !bndCheck.isOnScreen) {
    //    if ( pos.y < bndCheck.camHeight - bndCheck.radius){
    //        //we're off the bottom, so destroy this GameObject
    //        Destroy (gameObject);
    //       }
    //    }
    //}

    public virtual void Move(){
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    void OnCollisionEnter (Collision coll) {
        GameObject otherGO = coll.gameObject;
        if (otherGO.GetComponent<ProjectileHero>() !=null){
            Destroy (otherGO);
            Destroy (gameObject);
        } else {
            Debug.Log ("Enemey hit by non-ProjectileHero: "+ otherGO.name);
        }
    }
}

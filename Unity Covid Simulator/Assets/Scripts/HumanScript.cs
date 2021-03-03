using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanScript : MonoBehaviour
{
    public int currentrate;
    public GameObject Human;
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public bool infection;
    private SpriteRenderer rend;

    public Transform[] moveSpots;
    private int randomSpot;

    void Start(){

        randomSpot = Random.Range(0, moveSpots.Length);
        currentrate = 174;
        infection = false;
    }

    public void OnTriggerEnter2D(Collider2D col){
            HumanScript hscript = col.gameObject.GetComponent<HumanScript>();
            if (hscript.infection == true){
                int x = Random.Range(0, 1000);
                if (x <=currentrate && x >= 0){
                    infection = true;
                    rend = GetComponent<SpriteRenderer>();
                    rend.material.color = Color.red;
                }
            }    
    }

    void OnMouseDown(){
            if (infection == true){
                infection = false;
                rend = GetComponent<SpriteRenderer>();
                rend.material.color = Color.white;
            }
            else {
                infection = true;
                rend = GetComponent<SpriteRenderer>();
                rend.material.color = Color.red;
            }          
    }

    public void RateChange (int rate){
        currentrate = rate;
    }

    void Update(){

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
            if (waitTime <= 0){
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
        else if(Vector2.Distance(transform.position, moveSpots[8].position) < 0.2f){
                Destroy(Human);
            }
            else{
                waitTime  -= Time.deltaTime;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanScript : MonoBehaviour
{
    public int currentrate;
    public GameObject Human;
    public GameObject ButtonManager;
    public bool infection;
    private SpriteRenderer rend;
    UnityEngine.AI.NavMeshAgent human;

    [SerializeField] Transform[] line;
    [SerializeField] Transform[] seat;
    [SerializeField] Transform[] spot;
    [SerializeField] Transform[] exit;
    private Vector2 target;

    private int spotpick;
    private int seatpick;
    private int type;
    private int exitpoint;

    private int[] linestarts = {2,3,10};
    private int[] kfcline = {2, 1, 0};
    private int[] subline = {3,4,5,6,7};
    private int[] marioline = {10,9,8};
    private int linestart;
    private int kfc;
    private int mario;
    private int sub;
    private int linelength;
    private Vector2 next1, next2, next3, next4;


    void Start(){

        human = GetComponent<UnityEngine.AI.NavMeshAgent>();
        human.updateRotation = false;
        human.updateUpAxis = false;
        
        seatpick = Random.Range(0,24);
        spotpick = Random.Range(0,5);
        type = Random.Range(0,3);
        exitpoint = Random.Range (0,4);
        linestart = Random.Range(0,3);
        currentrate = 174;
        infection = false;

        kfc = 3;
        mario = 3;
        sub = 5;

        if (type == 0){
            target = spot[spotpick].position;
        }
        if (type == 1){
            target = seat[seatpick].position;         
        }
        if (type == 2){
            if (linestart == 0){
                target = line[kfcline[0]].position;
                next1 =line[kfcline[1]].position;
                next2 =line[kfcline[2]].position;
                linelength = kfc;  
            }
            if (linestart == 1){
                target = line[subline[0]].position;
                next1 = line[subline[1]].position;
                next2 = line[subline[2]].position;
                next3 = line[subline[3]].position;
                next4 = line[subline[4]].position;
                linelength = sub; 
            }
            if (linestart == 2){
                target = line[marioline[0]].position; 
                next1 = line[marioline[1]].position; 
                next2 = line[marioline[2]].position; 
                linelength = mario;  
            }                
        }

    }

    public void OnTriggerEnter2D(Collider2D col){

        HumanScript hscript = col.gameObject.GetComponent<HumanScript>();
            if (hscript.infection == true){
                Infect();
            }
        }    

    public void OnTriggerStay2D(Collider2D col){
        HumanScript hscript = col.gameObject.GetComponent<HumanScript>();
            if (hscript.infection == true){
                Invoke("Infect", 3);
        }
    }

    public void Infect(){
        ButtonScript ratechecker = ButtonManager.gameObject.GetComponent<ButtonScript>();
            currentrate = ratechecker.rate;
            int x = Random.Range(0, 1000);
            if (x <=currentrate && x >= 0){
                infection = true;
                rend = GetComponent<SpriteRenderer>();
                rend.material.color = Color.red;
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

    public void TakePause (int x){
        if (human.isStopped == false){
            human.isStopped = true;
        }
        Invoke("EndPause", x);
    }

    public void EndPause (){
        human.isStopped = false;
    }

    void Update(){

//Type 1 : The Drifter. Human that loiters in a spot before leaving.
        if (type == 0){
            human.isStopped = false;
            human.SetDestination(target);

            if(Vector2.Distance(transform.position, spot[spotpick].position) < 0.5f){
                TakePause(2);
                target = exit[exitpoint].position;
            }
            if(Vector2.Distance(transform.position, exit[exitpoint].position) < 0.5f){
                Destroy(Human);
            }
            
        }
        
//Type 2 : The Seated. Human that sits at a table for a while before leaving.
        if (type == 1){
            human.isStopped = false;
            human.SetDestination(target);

            if(Vector2.Distance(transform.position, seat[seatpick].position) < 0.5f){
                TakePause(4);
                target = exit[exitpoint].position;
            }
            if(Vector2.Distance(transform.position, exit[exitpoint].position) < 0.5f){
                Destroy(Human);
            }
            
        }

//Type 3 : The Customer. Human that lines up to purchase food before leaving.
        if (type == 2){
            human.isStopped = false;
            human.SetDestination(target);

            if(Vector2.Distance(transform.position, target) < 0.5f){
                TakePause(1);
                target = next1;                    
            }
            if(Vector2.Distance(transform.position, next1) < 0.5f){
                TakePause(1);
                target = next2;                    
            }
            if(Vector2.Distance(transform.position, next2) < 0.5f){
                TakePause(1);
                if (linelength == 3){
                    target = exit[exitpoint].position;
                }
                if (linelength == 5){
                    target = next3;
                }                    
            }
            if(Vector2.Distance(transform.position, next3) < 0.5f){
                TakePause(1);
                target = next4;                    
            }    
            if(Vector2.Distance(transform.position, next4) < 0.5f){
                TakePause(1);
                target = exit[exitpoint].position;                    
            }                               
            if(Vector2.Distance(transform.position, exit[exitpoint].position) < 0.5f){
                Destroy(Human);
            }
            
        }
    }
}

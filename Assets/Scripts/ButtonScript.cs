using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject Human;
    public HumanScript script;
    public Text RateText;
    private int starter;
    public Transform[] startpoint;
    public bool socialdistancing = false;
    public bool mask = false;
    public int rate;

    public void OnAddHumanButtonPress(){
        starter = Random.Range(0,4);
        GameObject duplicate = Instantiate(Human, startpoint[starter].position, startpoint[starter].rotation);
    }

    public void OnSocialDistancingButtonPress(){
        if(socialdistancing == false){
            socialdistancing = true;
            ChangeRate();
        }
        else{
            socialdistancing = false;
            ChangeRate();
        }
    }

    public void OnMaskButtonPress(){
        if(mask == false){
            mask = true;
            ChangeRate();
        }
        else{
            mask = false;
            ChangeRate();
        }
    }    

    public void ChangeRate(){
        HumanScript hscript = Human.gameObject.GetComponent<HumanScript>();
        if (mask == true && socialdistancing == true){
            rate = 4;
            RateText.text ="Current Rate: 0.4%";
        }
        else if (mask == true && socialdistancing == false){
            rate = 31;
            RateText.text ="Current Rate: 3.1%";
        }
        else if (mask == false && socialdistancing == true){
            rate = 26;
            RateText.text ="Current Rate: 2.6%";
        }
        else if (mask == false && socialdistancing == false){
            rate = 174;
            RateText.text ="Current Rate: 17.4%";
        }
    }    
}

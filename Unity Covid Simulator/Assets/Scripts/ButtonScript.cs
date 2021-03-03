using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject Human;
    public HumanScript script;
    public Text RateText;
    public Transform startpoint;
    public bool socialdistancing = false;
    public bool mask = false;

    public void OnAddButtonPress(){
        GameObject duplicate = Instantiate(Human, startpoint.position, startpoint.rotation);
    }

    public void OnSDButtonPress(){
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
            hscript.RateChange(4);
            RateText.text ="Current Rate: 0.4%";
        }
        else if (mask == true && socialdistancing == false){
            hscript.RateChange(31);
            RateText.text ="Current Rate: 3.1%";
        }
        else if (mask == false && socialdistancing == true){
            hscript.RateChange(26);
            RateText.text ="Current Rate: 2.6%";
        }
        else if (mask == false && socialdistancing == false){
            hscript.RateChange(174);
            RateText.text ="Current Rate: 17.4%";
        }
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_door : MonoBehaviour {

    
    public float reachDistance;
    public GameObject Player;
    public GameObject Target;
    public GameObject Target2;
    public bool open = false;

    private Animator anim;
    private Animator anim2;

    // Use this for initialization
    void Start () {
        anim = Target.GetComponent<Animator>();
        anim2 = Target2.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        reachDistance = Vector3.Distance(Player.transform.position, Target.transform.position);

        if(open == false && reachDistance <= 5.0f)
        {
            anim.Play("Open");
            anim2.Play("Open_right");
            open = true;
        }

        else if(open && reachDistance > 5.0f)
        {
            anim.Play("Close");
            anim2.Play("Close_right");
            open = false;
        }
        
		
	}
}

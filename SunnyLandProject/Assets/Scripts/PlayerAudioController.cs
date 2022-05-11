using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
   AudioSource[] allAudioSources;
   AudioSource landing;
   AudioSource crouching;
   AudioSource footsteps;
   AudioSource jumping;
   AudioSource cherry; 


    // keep track of the jumping state ... 
    bool isJumping = false;
    // make sure to keep track of the movement as well !
    bool isMoving= false; 

    Rigidbody2D rb; // note the "2D" prefix 

     

    
    // Start is called before the first frame update
    void Start()
    {
        

	rb = GetComponent<Rigidbody2D>();
	// get the references to your audio sources here !     
    allAudioSources = GetComponents<AudioSource>();
    landing = allAudioSources[0];
    crouching = allAudioSources[1];
    footsteps = allAudioSources[2];
    jumping = allAudioSources[3];
    cherry = allAudioSources[4];


    }

    // FixedUpdate is called whenever the physics engine updates
    void FixedUpdate()
    {
	// Use the ridgidbody instance to find out if the fox is
	// moving, and play the respective sound !
	// Make sure to trigger the movement sound only when
	// the movement begins ...

	// Use a magnitude threshold of 1 to detect whether the
	// fox is moving or not !
	// i.e.
	// if ( ??? > 1 && ???) {
	//    play sound here !
	// } else if ( ??? < 1 &&) {
	//   stop sound here !
	// }

    float v = rb.velocity.magnitude;
    if(v>1 && !isMoving && !isJumping){
        footsteps.Play();
        isMoving = true;
    }	
    else if (v<1 && isMoving && !isJumping){
        footsteps.Stop();
        isMoving = false;
    }
    }
    
    // trigger your landing sound here !
    public void OnLanding() {
        
        isJumping = false; 
        landing.Play();
        footsteps.Stop();
        print("the fox has landed");
	// to keep things cleaner, you might want to
	// play this sound only when the fox actually jumoed ...
    }

    // trigger your crouching sound here
    public void OnCrouching() {
        crouching.Play();
        print("the fox is crouching");
    }
 
    // trigger your jumping sound here !
    public void OnJump() {

        isJumping = true;
        jumping.Play();
        footsteps.Stop();
        print("the fox has jumped");
    }

    // trigger your cherry collection sound here !
    public void OnCherryCollect() {
        cherry.Play();
        print("the fox has collected a cherry");
    }


    

    
}

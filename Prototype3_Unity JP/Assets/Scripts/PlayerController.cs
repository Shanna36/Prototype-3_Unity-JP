using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float gravityModifier;
    public float jumpForce =10;
    public bool isOnGround = true;

    public bool isGameOver = false;

    private Animator playerAnim;

    public ParticleSystem explosionParticle;

    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound; 

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        dirtParticle.Play();
        playerAudio = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isOnGround){
             playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
             isOnGround = false;
             playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        } else if (isGameOver == true){ //I know they didn't do it this way in Unity, but this seems to work too
            isOnGround = false;
           
        }
    }
    private void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.CompareTag("Ground")){
            isOnGround = true; 
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")){
            Debug.Log ("Game Over");
            isGameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Animator playerAnim;
    public ParticleSystem dirtParticle;
    public ParticleSystem expolsionParticle;
    private GameManager gameManager;
    public float speed;
    private Rigidbody playerRb;
    public bool hasPowerup;
    public bool died;
    public GameObject indecator;
    private AudioSource playerAudio;
    public AudioClip coinSound;
   public AudioClip powerSound;
    public AudioClip explosionSound;

    // Start is called before the first frame update
    void Start()
    {
      
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();


          playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        //playerRb.AddForce(Vector3.forward * speed * verticalInput);
        if (!died && gameManager.canMove)
        {
            playerRb.AddForce(Vector3.right * speed * horizontalInput, ForceMode.Impulse);
        }
         
        indecator.transform.position = transform.position + new Vector3(0, 1f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            speed = 25f;
            Destroy(other.gameObject);
            Debug.Log ("Player has power up");
            StartCoroutine(PowerupCountdown());
            playerAudio.PlayOneShot(powerSound, 1.0f);
            indecator.gameObject.SetActive(true);

        }
        else if (other.CompareTag("meteor"))
        {
            died = true;
            Destroy(other.gameObject);
            Debug.Log ("Player was hit by a meteor and died");
           gameManager.GameOver();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(explosionSound, 1.0f);
            expolsionParticle.Play();
            dirtParticle.Stop();
            
        }
        else if (other.CompareTag("Bolder"))
        {
            died = true;
            Destroy(other.gameObject);
            Debug.Log("Player was hit by a bolder and died");
            gameManager.GameOver();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(explosionSound, 1.0f);
            expolsionParticle.Play();
            dirtParticle.Stop();
         
        }

        else if (other.CompareTag("coin"))
        {
           
            Destroy(other.gameObject);
            gameManager.UpdateScore(1);
             playerAudio.PlayOneShot(coinSound, 1.0f);
         
        }

        else if (other.CompareTag("scoin"))
        {

            Destroy(other.gameObject);
            gameManager.UpdateScore(2);
            playerAudio.PlayOneShot(coinSound, 1.0f);
        }

        else if (other.CompareTag("gcoin"))
        {

            Destroy(other.gameObject);
            gameManager.UpdateScore(4);
            playerAudio.PlayOneShot(coinSound, 1.0f);
        }
    }

   

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(6);
        hasPowerup = false;
        speed = 10f;
        indecator.gameObject.SetActive(false);
    }

}

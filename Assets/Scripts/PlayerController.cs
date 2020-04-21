using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    private AudioSource playerAudio;
    Rigidbody rgbd;
    public float jumpForce;
    public float gravityModifier;
    bool isGround = false;
    public bool isGameOver = false;
    public ParticleSystem explosionParticle , dirtParticle;
    public AudioClip jumpSound, crashSound;
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            dirtParticle.Play();
        }
        if(collision.gameObject.tag == "Obstacle")
        {
            collision.gameObject.GetComponent<MoveLeft>().isGameOver = true;
            isGameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int",1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1f);
        }
    }
    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        rgbd = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier; // gravity for whole of our scene
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround &&!isGameOver)
        {
            playerAnim.SetTrigger("Jump_trig");
            rgbd.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dirtParticle.Stop();
            isGround = false;
            playerAudio.PlayOneShot(jumpSound,1f);
        }
        
    }
}

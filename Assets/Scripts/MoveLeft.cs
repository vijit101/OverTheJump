using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20f;
    private float lowerBound = -25f;
    public PlayerController player;
    [HideInInspector]
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (isGameOver)
        {
            Debug.Log("gameover");
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }

    }
}

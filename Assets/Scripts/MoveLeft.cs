using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    private float leftBound = -15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 1.17 stop moving left when the game is over
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            bool isGameOver = player.GetComponent<PlayerController>().gameOver;
            if (isGameOver)
            {
                speed = 0;
            }
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
        }
    }
}

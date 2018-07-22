using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed = 10;

    public Vector3 checkPoint;

    public int currentLife;
    public int maxLife = 10;

    public Text countText;
    public Text gameOverText;

    private int maxCount = 8;
    private Rigidbody rb;
    private int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        currentLife = maxLife;

        UpdateText();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if(currentLife <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagNames.Pickup.ToString()))
        {
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            count += 1;
            UpdateText();
        }

        if (other.gameObject.CompareTag(TagNames.Fatal.ToString()))
        {
            Die();
        }

        if (other.gameObject.CompareTag(TagNames.Enemy.ToString()))
        {
            UpdateLife(-1);
        }

        if (other.gameObject.CompareTag(TagNames.CheckPoint.ToString()))
        {
            checkPoint = other.transform.position;
        }
    }

    private void UpdateText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= maxCount)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }

    private void UpdateLife(int updateNumber)
    {
        Debug.Log("Life update");
        currentLife += maxLife;
    }

    private void Die()
    {
        currentLife = 0;
        // disable game object
        // disable input
        // hide game object

        // move to checkpoint

        // enable game object
        // show object
        // enable input
    }
}

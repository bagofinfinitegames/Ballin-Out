using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed = 10;

    public Text countText;
    public Text gameOverText;

    private int maxCount = 8;
    private Rigidbody rb;
    private int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        UpdateText();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            count += 1;
            UpdateText();
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
}

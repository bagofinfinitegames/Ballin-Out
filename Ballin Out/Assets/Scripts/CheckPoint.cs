using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public GameObject gameManager;
    GameManager gameManagerScript;

    private void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag(TagNames.Player.ToString()))
        {
            // Can't set the object or position?
            // Show Effect
        }
    }
}

using UnityEngine;

public class Spinner : MonoBehaviour {
    public float speed = 50;

    private void Update()
    {
        transform.Rotate(new Vector3(speed, speed, speed) * Time.deltaTime);
    }
}

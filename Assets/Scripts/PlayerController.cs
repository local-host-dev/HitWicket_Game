using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Debug.Log("Working");
        speed = GameManager.Instance.playerSpeed;
    }

    private void Update()
    {
        // float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        // float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // transform.Translate(new Vector3(moveX, 0, moveZ));
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}

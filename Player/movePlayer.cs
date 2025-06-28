using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0, z) * speed * Time.deltaTime;
        transform.Translate(move);
    }
}

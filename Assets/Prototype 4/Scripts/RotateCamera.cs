using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    float rotateSpeed = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, (horizontalInput * rotateSpeed * Time.deltaTime));
    }
}

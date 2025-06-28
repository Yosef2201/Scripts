using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public float senstivity;
    public float xRotation;
        public float yRotation;

        void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xRotation += Input.GetAxis("Mouse X") * senstivity;
                yRotation -= Input.GetAxis("Mouse Y")*senstivity;
        transform.eulerAngles = new Vector3(yRotation, xRotation, 0);
    }
}

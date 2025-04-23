using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    private float rotateSpeed =75.0f;
    private GameObject target;

    void Awake()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        target = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        RotateCameraXY();
    }

    private void RotateCameraXY()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(1) && horizontalInput>0)
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1) && horizontalInput<0)
        {
            transform.Rotate(Vector3.down, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1) && verticalInput>0)
        {
            transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButton(1) && verticalInput<0)
        {
            transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
        transform.position = target.transform.position; 
    }
}

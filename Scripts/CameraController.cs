using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static bool cursor_active = false;
    public static bool rotation = true;

    Transform playerBody; // Ссылка на объект игрока
    
    float mouseSensitivity = 70f;
    float xRotation = 0f;
    
    void Start()
    {
        playerBody = GameObject.Find("Player").GetComponent<Transform>();
        Cursor.visible = false; Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!cursor_active)
        {
            Cursor.visible = false; Cursor.lockState = CursorLockMode.Locked;
            // Получаю движение мыши
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // Поворот камеры вверх/вниз (по оси X)
            xRotation -= mouseY; xRotation = Mathf.Clamp(xRotation, -80f, 80f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            if(rotation) playerBody.Rotate(Vector3.up * mouseX);// Поворот игрока влево/вправо (по оси Y)
        }
        else
        {
            Cursor.visible = true; Cursor.lockState = CursorLockMode.None;
        }
        
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController charController;
    [SerializeField] private float rotationSensitivity = 5.0f;
    [SerializeField] private float smoothRotation = 2.0f;
    [SerializeField] private GameObject playerChar;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private GameObject muzzleWeapon;
    
    private Bullet bullet;
    private Vector2 mouseLook;
    private Vector2 smoothV;
    private float minVertLook = -45f;
    private float maxVertLook = 45f;

    private void Start()
    {
        playerChar = GameObject.FindGameObjectWithTag("Player"); //not ideal to look for gameobjects with find but it works as it is
        charController = FindObjectOfType<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        RotationInputs(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        ShootingInput();
    }
    
    private void RotationInputs(float a_horizInput, float a_vertInput) {
        Vector2 md = new Vector2(a_horizInput, a_vertInput);

        md = Vector2.Scale(md , new Vector2(rotationSensitivity * smoothRotation, rotationSensitivity * smoothRotation));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothRotation);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothRotation);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, minVertLook, maxVertLook);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        playerChar.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, charController.transform.up);
    }

    private void ShootingInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletSpawned = Instantiate(bulletObject);

            bulletSpawned.transform.position = muzzleWeapon.transform.position;
            Vector3 rotation = bulletSpawned.transform.rotation.eulerAngles;
            bulletSpawned.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
            Debug.Log("x is" + bulletSpawned.transform.rotation.eulerAngles.x + "y is "+ bulletSpawned.transform.rotation.eulerAngles.y + "z is" + bulletSpawned.transform.rotation.eulerAngles.z);
           bulletSpawned.GetComponent<Bullet>().reflectDirection = bulletSpawned.transform.forward;
        }
    }
}

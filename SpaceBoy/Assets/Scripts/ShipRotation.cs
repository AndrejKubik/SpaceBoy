using UnityEngine;

public class ShipRotation : MonoBehaviour
{
    [SerializeField] private Transform ship;
    [SerializeField] private Vector3 shipStartPosition;
    //[SerializeField] private float rotationSpeed;
    //[SerializeField] private Vector3 zAxis;
    //[SerializeField] private Vector3 anchorPosition;
    //[SerializeField] private Vector3 anchorOffset;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float joystickAngle;
    [SerializeField] private float shipTargetRotation;
    [SerializeField] private float rotateSpeed = 200f;
    private void Start()
    {
        //anchorPosition = ship.position + anchorOffset; //set the rotation anchor point above the ship
        shipStartPosition = ship.position; //store the ship's starting position
    }
    void Update()
    {
        //if(Input.GetKey(KeyCode.A)) //when player presses A button
        //{
        //    ship.RotateAround(anchorPosition, zAxis, rotationSpeed); //rotate the ship to the left around the chosen anchor point with the chosen speed
        //    ship.position = shipStartPosition;
        //}

        //if (Input.GetKey(KeyCode.D)) //when player presses D button
        //{
        //    ship.RotateAround(anchorPosition, zAxis, -rotationSpeed); //rotate the ship to the right around the chosen anchor point with the chosen speed
        //    ship.position = shipStartPosition;
        //}

        joystickAngle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg; //calculate the angle of joystick handle position
        ship.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 180f, -(joystickAngle + 90f)), rotateSpeed * Time.deltaTime); //change the ships rotation according to joystick position over chosen speed

    }
}

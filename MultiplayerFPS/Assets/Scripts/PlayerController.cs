using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
  //show in inspectorrbut still private
  [SerializeField]
  private float speed = 5f;

  [SerializeField]
  private float lookSensitivity = 3f;

  private PlayerMotor motor;

  void Start()
  {
    motor = GetComponent<PlayerMotor>();
  }
  //Calculate movement velocity as 3D Vector
  void Update()
  {
    //Always between -1 and 1
    float _xMov = Input.GetAxisRaw("Horizontal");
    float _zMov = Input.GetAxisRaw("Vertical");

    //(1,0,0) and (0,0,1) before multiply respectively
    Vector3 _moveHorizontal = transform.right *  _xMov;
    Vector3 _moveVertical = transform.forward * _zMov;
    //Final movement vector
    Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

    motor.Move(_velocity);

    //Calculate rotation as a 3D vector (turning around)
    float _yRot = Input.GetAxisRaw("Mouse X");
    Vector3 _rotation = new Vector3(0f, _yRot, 0f)*lookSensitivity;

    //Apply rotation
    motor.Rotate(_rotation);

    //Calculate camera rotation as a 3D vector (turning around)
    float _xRot = Input.GetAxisRaw("Mouse Y");
    Vector3 _cameraRotation = new Vector3(_xRot,0f, 0f)*lookSensitivity;

    //Apply rotation
    motor.RotateCamera(_cameraRotation);
  }
}

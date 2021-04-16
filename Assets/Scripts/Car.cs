using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

  public GameObject Bullet;
  public int Hp;

  [SerializeField]
  private Rigidbody _rgdb;
  [SerializeField]
  private float _carSpeed;
  [SerializeField]
  private float _turnSpeed;
  [SerializeField]
  private Transform _shotPlace;

  private bool _canMove;

  private void Awake()
  {
    _rgdb = GetComponent<Rigidbody>();

    if (!_shotPlace)
      _shotPlace = transform.Find("shotPlace");

    _canMove = true;
  }

  private void Update()
  {

    if (Hp <= 0 && _canMove)
    {
      _canMove = false;
      Debug.Log("Open GameOver Panel!");
    }

    if (!_canMove)
      return;

    if (Input.GetKeyDown(KeyCode.Space))
    {
      GameObject b = Instantiate(
                                  Bullet, 
                                  _shotPlace.position, 
                                  transform.rotation
                                );
    }
  }

  void FixedUpdate()
  {

    if (!_canMove)
      return;

    if (Input.GetKey(KeyCode.W))
      _rgdb.velocity = transform.forward * _carSpeed;
    else if (Input.GetKey(KeyCode.S))
      _rgdb.velocity = transform.forward * -1 * _carSpeed;
    
    if (Input.GetKey(KeyCode.A))
      _rgdb.angularVelocity = Vector3.up * _turnSpeed * -1;
    else if (Input.GetKey(KeyCode.D))
      _rgdb.angularVelocity = Vector3.up * _turnSpeed;
    else
      _rgdb.angularVelocity = Vector3.zero;
  }

  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag.Equals("Colect"))
    {
      Destroy(other.gameObject);
    } else if (other.gameObject.tag.Equals("Cone"))
    {
      other.gameObject.transform.Translate(0, -0.2f, 0);
      other.gameObject.transform.Rotate( 110, 0, 0);
      Destroy(other);
    }
  }

}

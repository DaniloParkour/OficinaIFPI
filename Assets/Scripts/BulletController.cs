using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

  public float Speed;

  void Update()
  {
    transform.Translate(transform.forward * Time.deltaTime * Speed, Space.World);
  }

  private void OnTriggerEnter(Collider other)
  {

    Car c = other.GetComponent<Car>();
    if (c)
      c.Hp -= 2;

    if(other.gameObject.tag.Equals("Car"))
      other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 40);

    Destroy(gameObject);
  }

}

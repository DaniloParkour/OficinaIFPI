using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

  public GameObject Bullet;

    // Start is called before the first frame update
  void Start()
  {
        
  }

    // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.W))
      transform.Translate(transform.forward * Time.deltaTime * 10);
    else if (Input.GetKey(KeyCode.S))
      transform.Translate(transform.forward * -1 * Time.deltaTime * 10);

    if (Input.GetKeyDown(KeyCode.Space))
    {
      GameObject b = Instantiate(Bullet);
      b.transform.position = transform.position;
    }

  }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{

  private int _totalCarDestroyed;

  public GameObject EndPanel;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag.Equals("Car"))
      _totalCarDestroyed++;
    Destroy(other.gameObject);

    if(_totalCarDestroyed >= 5)
    {
      EndPanel.SetActive(true);
    }
  }

}

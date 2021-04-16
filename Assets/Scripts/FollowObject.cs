using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{

  public Transform Target;
  public bool JustLook;

  private Vector3 _targetDistance;

  private void Start()
  {
    _targetDistance = Target.position - transform.position;
  }

  private void LateUpdate()
  {
    if (JustLook)
      transform.LookAt(Target.position);
    else
      transform.position = Target.position - _targetDistance;
  }

}

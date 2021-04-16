using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  public Transform ShotPosition;
  public Transform Player;
  public float Range;
  public float[] ShotCooldown;

  public GameObject BulletPrefab;

  private void Awake()
  {
    if (!ShotPosition)
      ShotPosition = transform.Find("shotPosition");

    //Chamar a função ShotNow após A segundos
    Invoke("ShotNow", ShotCooldown[0]);

    InvokeRepeating("UptadeDirectio", 1, 0.1f);
  }

  private void UptadeDirectio()
  {
    Vector3 distanceVector = transform.position - Player.position;
    float distance = distanceVector.magnitude;

    if (Mathf.Abs(distance) > Range)
      return;

    transform.LookAt(Player);
  }

  private void ShotNow()
  {
    //Chamar a função ShotNow após um valor randômico entre A e B segundos
    Invoke("ShotNow", Random.Range(ShotCooldown[0], ShotCooldown[1]));

    if (Mathf.Abs((transform.position - Player.position).magnitude) > Range)
      return;

    GameObject g = Instantiate(BulletPrefab);
    g.transform.position = ShotPosition.position;
    g.transform.rotation = transform.rotation;
  }

}

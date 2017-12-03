using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fove.Managed;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject spawnPoint = null;
    [SerializeField] private GameObject ballPrefab = null;

    [SerializeField] private float distance = 100;
    [SerializeField] private float blinkThreshold = 5f;
    [SerializeField] private float power = 10.0f;

    private float countTime = 0;

    // Update is called once per frame
    private void Update()
    {
        Ray ray = new Ray(this.transform.position, FoveInterface.GetHMDRotation() * Vector3.forward * distance);

        //Rayを画面に表示
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
        /*
        Debug.LogFormat("Rotation x : {0}, y: {1} z: {2} ",
                    ray.direction.x, ray.direction.y, ray.direction.z);
*/
  
        // まばたきでボールを飛ばすように
        countTime += Time.deltaTime;

        if (FoveInterface.CheckEyesClosed() == EFVR_Eye.Both
         && countTime > blinkThreshold)
        {
            GameObject tempBall = MakeBall();
            tempBall.GetComponent<BaketBall>().Shot(ray.direction * power);
            tempBall = null;
            countTime = 0;
        }

    }

    private GameObject MakeBall()
    {
        GameObject temp = null;

        if (ballPrefab && spawnPoint)
        {
            temp = Instantiate(ballPrefab,
               spawnPoint.transform.position,
               spawnPoint.transform.rotation) as GameObject;
            temp.transform.parent = spawnPoint.transform;
        }

        return temp;
    }
}

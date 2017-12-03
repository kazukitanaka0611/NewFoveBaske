using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fove.Managed;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject spawnPoint = null;
    [SerializeField] private GameObject ball = null;
    [SerializeField] private float distance = 100;
    [SerializeField] private float blinkThreshold = 5f;
    [SerializeField] private float power = 3.0f;

    private float countTime = 0;


    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        /*
           // ヘッドマウントディスプレイの傾きを取得ログに表示する
           Debug.LogFormat("Rotation x : {0}, y: {1} z: {2} ",
               FoveInterface.GetHMDRotation().eulerAngles.x,
               FoveInterface.GetHMDRotation().eulerAngles.y,
               FoveInterface.GetHMDRotation().eulerAngles.z);
               */

        /*
                Vector3 dir = Vector3.zero;
                dir.x = FoveInterface.GetHMDRotation().eulerAngles.x;
                dir.y = FoveInterface.GetHMDRotation().eulerAngles.y;

                if (dir.sqrMagnitude > 1)
                {
                    dir.Normalize();
                    Debug.LogFormat("Rotation x : {0}, y: {1} z: {2} ",
                      dir.x, dir.y, dir.z);
                }*/

        Ray ray = new Ray(this.transform.position, FoveInterface.GetHMDRotation() * Vector3.forward * distance);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            //Rayが当たるオブジェクトがあった場合はそのオブジェクト名をログに表示
           // Debug.Log(hit.collider.gameObject.name);
        }

        //Rayを画面に表示
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);

        // まばたきでボールを飛ばすように
        countTime += Time.deltaTime;

        if (FoveInterface.CheckEyesClosed() == EFVR_Eye.Both
         && countTime > blinkThreshold)
        {

            GameObject ball = MakeBall();
            ball.GetComponent<BaketBall>().Shot(ray.direction * distance);
            countTime = 0;
        }

    }

    private GameObject MakeBall()
    {
        GameObject temp = null;

        if (ball && spawnPoint)
        {
            temp = Instantiate(ball,
               spawnPoint.transform.position,
               spawnPoint.transform.rotation) as GameObject;
            temp.transform.parent = spawnPoint.transform;
        }

        return temp;
    }
}

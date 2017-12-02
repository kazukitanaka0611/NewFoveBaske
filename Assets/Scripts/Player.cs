using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject spawnPoint = null;
    [SerializeField] private GameObject ball = null;
    [SerializeField] private float distance = 100;

    private float tempPositionX = 0;

    private void Start()
    {
        if (ball && spawnPoint)
        {
            GameObject tem = Instantiate(ball,
               spawnPoint.transform.position,
               spawnPoint.transform.rotation) as GameObject;
            tem.transform.parent = spawnPoint.transform;
        }
    }

    // Update is called once per frame
    private void Update()
    {

        // ヘッドマウントディスプレイの傾きを取得ログに表示する
        Debug.LogFormat("Rotation x : {0}, y: {1} z: {2} ",
            FoveInterface.GetHMDRotation().x,
            FoveInterface.GetHMDRotation().y,
            FoveInterface.GetHMDRotation().z);

        Ray ray = new Ray(this.transform.position, FoveInterface.GetHMDRotation() * Vector3.forward * distance);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            //Rayが当たるオブジェクトがあった場合はそのオブジェクト名をログに表示
            Debug.Log(hit.collider.gameObject.name);
        }

        //Rayを画面に表示
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);

    }
}

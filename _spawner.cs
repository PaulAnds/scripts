using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _spawner : MonoBehaviour
{
    //[SerializeField]
    //private float spawnPerMin = 60;
    //private int count = 0;
    public GameObject cameras;

    [SerializeField]
    private _factory Factory;

    // Update is called once per frame
    void Update()
    {
        //var targetCount = Time.time * (spawnPerMin / 60);
        //while (targetCount > count)
        //{
        //    var inst = Factory.GetNewInstance();
        //    inst.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
        //    count++;
        ////}

        //if(cameras.transform.position.y > )
        //{
        //    var inst = Factory.GetNewInstance();
        //    inst.transform.position = new Vector3(cameras.transform.position.x, cameras.transform.position.y + 10, 0f);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (collision.tag == "Trigger")
        {
            var inst = Factory.GetNewInstance();
            inst.transform.position = new Vector3(cameras.transform.position.x, cameras.transform.position.y + 6.75f, 0f);
            Debug.Log("Trigger");
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _spawner : MonoBehaviour
{
    [SerializeField]
    private float spawnPerMin = 60;
    private int count = 0;

    [SerializeField]
    private _factory Factory;

    // Update is called once per frame
    void Update()
    {
        var targetCount = Time.time * (spawnPerMin / 60);
        while (targetCount > count)
        {
            var inst = Factory.GetNewInstance();
            inst.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
            count++;
        }
    }
}

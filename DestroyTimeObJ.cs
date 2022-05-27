using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimeObJ : MonoBehaviour
{
    public float lifetime;//contador de destruccion

    private void Update()
    {//cuando llegue a 0 se destruya
        lifetime -= Time.deltaTime;
        if(lifetime < 0)
        {
            //destruccion del gameobject que tiene este script
            Destroy(gameObject);
        }
    }
}

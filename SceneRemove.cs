using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRemove : MonoBehaviour
{
    [SerializeField]
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timer);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _factory : MonoBehaviour
{
    [SerializeField]
    private MonoBehaviour prefab;

    public MonoBehaviour GetNewInstance()
    {
        return Instantiate(prefab);
    }

}

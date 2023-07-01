using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    float retraso = 4;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(prefab, spawner));
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Destruir tuberías, generar suelo, destruir suelo
    }

    IEnumerator Spawn(GameObject objectToInstantiate, GameObject parent) //Corrutina que genera un par de tuberías con una altura aleatoria (dentro de un rango), cada retraso segundos
    {
        while (true)
        {
            Instantiate(objectToInstantiate, parent.transform);
            yield return new WaitForSeconds(retraso);
        }       
    }
}

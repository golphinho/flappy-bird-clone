using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    float distanciaInstancias = 6;

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    GameObject spawner;

    GameObject ultimoInstanciado;

    [SerializeField]
    bool randomY; //si randomY == true, cada objeto generado tendrá la componente y de su posición aleatoria dentro de un rango. Si no, cada objeto generado lo hará en la misma posición que su generador
    [SerializeField]
    float randomYmin;
    [SerializeField]
    float randomYmax;


    // Start is called before the first frame update
    void Start()
    {
        ultimoInstanciado = Instantiate(prefab, spawner.transform); //Genera una instancia del prefab en la posición del spawner, y la guarda en ultimoInstanciado
    }

    // Update is called once per frame
    void Update()
    {
        if (ultimoInstanciado.transform.position.x <= spawner.transform.position.x - distanciaInstancias && randomY == true) //comprueba la posición del último objeto instanciado y si randomY es true
        {
            UnityEngine.Random.InitState(System.DateTime.Now.Second);
            ultimoInstanciado = Instantiate(prefab, new Vector3(spawner.transform.position.x, spawner.transform.position.y + UnityEngine.Random.Range(randomYmin, randomYmax), 0), Quaternion.Euler(0, 0, 0)); //genera un nuevo objeto en la posición x del spawner y con una posición y aleatoria (entre randomYmin y randomYmax)
            Debug.Log(ultimoInstanciado.name + " Generado");
        }
        else if (ultimoInstanciado.transform.position.x <= spawner.transform.position.x - distanciaInstancias) //comprueba la posición del último objeto instanciado
        {
            ultimoInstanciado = Instantiate(prefab, spawner.transform); //genera un nuevo objeto en la posición del spawner y lo guarda en ultimoInstanciado
            Debug.Log(ultimoInstanciado.name + " Generado");
        }
    }
}

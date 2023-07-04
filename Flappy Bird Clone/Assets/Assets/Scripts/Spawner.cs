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
    bool randomY; //si randomY == true, cada objeto generado tendr� la componente y de su posici�n aleatoria dentro de un rango. Si no, cada objeto generado lo har� en la misma posici�n que su generador
    [SerializeField]
    float randomYmin;
    [SerializeField]
    float randomYmax;


    // Start is called before the first frame update
    void Start()
    {
        ultimoInstanciado = Instantiate(prefab, spawner.transform); //Genera una instancia del prefab en la posici�n del spawner, y la guarda en ultimoInstanciado
    }

    // Update is called once per frame
    void Update()
    {
        if (ultimoInstanciado.transform.position.x <= spawner.transform.position.x - distanciaInstancias && randomY == true) //comprueba la posici�n del �ltimo objeto instanciado y si randomY es true
        {
            UnityEngine.Random.InitState(System.DateTime.Now.Second);
            ultimoInstanciado = Instantiate(prefab, new Vector3(spawner.transform.position.x, spawner.transform.position.y + UnityEngine.Random.Range(randomYmin, randomYmax), 0), Quaternion.Euler(0, 0, 0)); //genera un nuevo objeto en la posici�n x del spawner y con una posici�n y aleatoria (entre randomYmin y randomYmax)
            Debug.Log(ultimoInstanciado.name + " Generado");
        }
        else if (ultimoInstanciado.transform.position.x <= spawner.transform.position.x - distanciaInstancias) //comprueba la posici�n del �ltimo objeto instanciado
        {
            ultimoInstanciado = Instantiate(prefab, spawner.transform); //genera un nuevo objeto en la posici�n del spawner y lo guarda en ultimoInstanciado
            Debug.Log(ultimoInstanciado.name + " Generado");
        }
    }
}

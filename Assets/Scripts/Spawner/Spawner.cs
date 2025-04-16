using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //variables
    //lista de objetos que van a spawnear
    [SerializeField] List<GameObject> objects = new List<GameObject>();
    //lugares predeterminados donde van a aparecer los huevos
    [SerializeField] List<Transform> positions = new List<Transform>();
    //tiempo en el que volvera a spawnear huevos, despues que los jugadores hayan recolectado los ya spawneados
    [SerializeField] float timeToSpawn;
    //numero de objetos que se spawnearan
    [SerializeField] float spawnCount;
    //booleano para saber si se puede spawnear
    [SerializeField] bool canSpawn = true;

    //methods

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    void Spawn()
    {
        //lista de posiciones, se iran eliminando las que se han usado para no repetir posiciones
        List<Transform> positionsUsed = positions;

        for (int i = 0; i < spawnCount; i++)
        {
            //tomar un objeto random de la lista de objetos
            int randomObj = Random.Range(0, objects.Count);
            //tomar una posicion random de nuestra lista de posiciones
            int randomPosition = Random.Range(0, positionsUsed.Count);
            //instanciar el objeto random en la ubicacion random
            Instantiate(objects[randomObj], positionsUsed[randomPosition].position, Quaternion.identity);
            //quitar la posicion usada de la lista
            positionsUsed.RemoveAt(randomObj);
        }
        canSpawn = false;
    }

    //coroutines

    IEnumerator SpawnObject()
    {
        while (true)
        {
            if (canSpawn)
            {
                yield return new WaitForSeconds(timeToSpawn);
                Spawn();
            }
            else
            {
                yield return null;
            }
        }
    }


}

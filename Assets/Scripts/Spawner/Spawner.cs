using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    //variables
    //lista de objetos que van a spawnear
    [SerializeField] List<GameObject> objects = new List<GameObject>();
    //lista de objetos especiales(Power Up)
    [SerializeField] List<GameObject> specialObjects = new List<GameObject>();
    //lugares predeterminados donde van a aparecer los huevos
    [SerializeField] List<Transform> positions = new List<Transform>();
    //numero de objetos en la escena, cuando este numero sea 0, canSpawn sera true
    int eggsCount;
    //tiempo en el que volvera a spawnear huevos, despues que los jugadores hayan recolectado los ya spawneados
    [SerializeField] float timeToSpawn;
    //numero de objetos que se spawnearan
    [SerializeField] float spawnCount;
    //booleano para saber si se puede spawnear
    [SerializeField] bool canSpawn = true;

    //properties
    protected override bool persistent => false;

    public int EggsCount
    {
        get => eggsCount;

        set
        {
            eggsCount = value;
            if (eggsCount == 0)
            {
                canSpawn = true;
            }
        }
    }

    //methods

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    void Spawn()
    {
        //lista de posiciones, se iran eliminando las que se han usado para no repetir posiciones
        List<Transform> positionsUsed = new List<Transform>();
        positionsUsed.AddRange(positions);

        for (int i = 0; i < spawnCount; i++)
        {
            //tomar un objeto random de la lista de objetos
            int randomObj = Random.Range(0, objects.Count);
            //tomar una posicion random de nuestra lista de posiciones
            int randomPosition = Random.Range(0, positionsUsed.Count);
            //instanciar el objeto random en la ubicacion random
            Instantiate(objects[randomObj], positionsUsed[randomPosition].position, Quaternion.identity);
            //quitar la posicion usada de la lista
            positionsUsed.Remove(positionsUsed[randomPosition]);
            //sumar 1 a eggsCount para contar los huevos spawneados
            eggsCount++;
        }
        //spawnear un objeto especial
        int SpecialIndex = Random.Range(0, specialObjects.Count);
        int SpecialPosition = Random.Range(0, positionsUsed.Count);
        specialObjects[SpecialIndex].transform.position = positionsUsed[SpecialPosition].position;
        specialObjects[SpecialIndex].gameObject.SetActive(true);
        eggsCount++;
        canSpawn = false;
    }

    //coroutines

    IEnumerator SpawnObject()
    {
        while (true)
        {
            if (canSpawn == true)
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

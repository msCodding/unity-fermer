using System.Collections;
using UnityEngine;

public class carrot_upper : MonoBehaviour
{
    public GameObject[] currot_obj; //все этапы моркови, можно добавсить если нужно
    public GameObject seeds; //объект семян
    public bool free = false; //занята ли сейчас грядка

    GameObject currot_food = null;//текущий этап(объект) выращивания моркови
    GameObject seeds_object = null;//использование семян


    IEnumerator SpawnSequence()
    {
        currot_food = Instantiate(currot_obj[2], transform.position+ new Vector3(0, -0.5f, 0), Quaternion.Euler(-90f, 0f, 0f));
        yield return new WaitForSeconds(5f); Destroy(currot_food);

        currot_food = Instantiate(currot_obj[1], transform.position+ new Vector3(0, -0.5f, 0), Quaternion.Euler(-90f, 0f, 0f));
        yield return new WaitForSeconds(10f); Destroy(currot_food);

        currot_food = Instantiate(currot_obj[0], transform.position+ new Vector3(0, -0.5f, 0), Quaternion.Euler(-90f, 0f, 0f));
        carrot carrotScript = currot_food.GetComponent<carrot>();
        if (carrotScript != null) carrotScript.carrotPlot = this;
    }

    void Update()
    {
        if (seeds_object != null)
        {
            if (seeds_object.GetComponent<seeds_click>().click)
            {
                free = true;
                Destroy(seeds_object); StartCoroutine(SpawnSequence());

            }
        }
    }
    void OnTriggerEnter(Collider pl)
    {
        if (pl.gameObject.CompareTag("Player") && free == false ) New_seed();



    }
    void OnTriggerExit(Collider pl)
    {
        if (pl.gameObject.CompareTag("Player")) Destroy(seeds_object);
    }
 
    public void New_seed()
    {
        if (PlayerController.seeds > 0)
        {
            seeds_object = Instantiate(seeds, transform.position + new Vector3(0, 0.8f, 0), Quaternion.Euler(0f, -180f, 0f));
        }
    }
}

using UnityEngine;
using System.Collections;

public class seeds_click : MonoBehaviour
{
    public bool click = false;
    public LayerMask seedLayer;

    Animator animator;
    PlayerController pl;

    void Start()
    {
        animator = GameObject.Find("player-T-pose").GetComponent<Animator>();
        pl = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    IEnumerator Work()
    {
        CameraController.rotation = false; PlayerController.speed = 0;
        animator.SetTrigger("work");
        yield return new WaitForSeconds(6.5f);
        CameraController.rotation = true; PlayerController.speed = 10;
        click = true;
        pl.source.clip = pl.music[3]; pl.source.Play();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // ПКМ
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, seedLayer))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    PlayerController.seeds--;
                    StartCoroutine(Work());
                    
                    
                }
            }
        }
    }
}

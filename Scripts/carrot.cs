using System.Collections;
using UnityEngine;

public class carrot : MonoBehaviour
{
    public static bool destroy = false; // для обозначения, что морковь собрана
    public LayerMask seedLayer;
    public carrot_upper carrotPlot; //ссылка на грядку

    Animator animator;

    bool pl_bool = false; //утверждение, что рядом игрок
    
    void Start()
    {
        animator = GameObject.Find("player-T-pose").GetComponent<Animator>();
    }
    IEnumerator Work()
    {
        CameraController.rotation = false; PlayerController.speed = 0; animator.SetTrigger("work");
        yield return new WaitForSeconds(6.5f);
        PlayerController.speed = 10; CameraController.rotation = true;
        destroy = true; Destroy(gameObject);
        if (carrotPlot != null)
        {
            carrotPlot.free = false; carrotPlot.New_seed();
        }
    }
    
    void OnTriggerEnter(Collider pl)
    {
        if (pl.gameObject.CompareTag("Player")) pl_bool = true;
    }
    void OnTriggerExit(Collider pl)
    {
        if (pl.gameObject.CompareTag("Player")) pl_bool = false;
    }

    void Update()
    {
        if (pl_bool && (Input.GetKeyDown(KeyCode.E)||Input.GetMouseButtonDown(0)))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, seedLayer))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    StartCoroutine(Work());

                }
            }
        }
    }
}

using TMPro;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float speed = 10f; //скорость игрока
    public static int seeds = 10; // кол-во семян
    public int Carrot = 0; //количество моркови

    public AudioClip[] music;
    public AudioSource source_game;
    public AudioSource source;

    Rigidbody rb;
    Animator animator;
    
    TextMeshProUGUI text_Carrot;
    TextMeshProUGUI text_seeds;
    GameObject panel;
    GameObject cursor;

    void Start()
    {
        text_Carrot = GameObject.Find("carrot_score").GetComponent<TextMeshProUGUI>();
        text_seeds = GameObject.Find("seeds_score").GetComponent<TextMeshProUGUI>();
        animator = GameObject.Find("player-T-pose").GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        panel = GameObject.Find("Panel");cursor = GameObject.Find("cursor");


        text_seeds.text = "x" + seeds; text_Carrot.text = "x" + Carrot;

        source_game.clip = music[0]; source_game.Play();

        panel.SetActive(false);
        
    }
    void FixedUpdate()
    {
        animator.SetFloat("speed", rb.velocity.magnitude);
        float h = Input.GetAxis("Horizontal"); float v = Input.GetAxis("Vertical");
        Vector3 inputDir = (transform.forward * v + transform.right * h).normalized;

        rb.velocity = inputDir * speed;
        if (rb.velocity.magnitude > 0.1f)
        {
            if (!source.isPlaying || source.clip != music[1])
            {
                source.clip = music[1];source.volume = 0.7f; source.Play();
            }
        }
        else
        {
            if (source.isPlaying&&source.clip == music[1])
            {
                source.Stop();
            }
        }

        
    }

    void Update()
    {
        text_seeds.text = "x" + seeds; print(seeds + "🌱");
        if (carrot.destroy)
        {
            Carrot++;
            source.clip = music[2];source.volume = 1f; source.Play();
            text_Carrot.text = "x" + Carrot; print(Carrot + "🥕");
            carrot.destroy = false;

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeSelf)
            {
                cursor.SetActive(true); panel.SetActive(false);
                CameraController.cursor_active = false;
            }
            else
            {
                CameraController.cursor_active = true;
                cursor.SetActive(false); panel.SetActive(true);
            }
            
        }

    }

}

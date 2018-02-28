
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningFire : MonoBehaviour
{
    public Sprite[] frames;
    private SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(PlayAnimation(0.15f));


    }

    // Update is called once per frame
    void Update()
    {
        //if (check.IsTouchingLayers (shieldLayers)) {
        //	check.isTrigger = false;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent <Player>();
            player.Die();
        }
    }

    IEnumerator PlayAnimation(float seconds)
    {
        int currentFrameIndex = 0;
        while (true)
        {
            spriteRenderer.sprite = frames[currentFrameIndex];
            // yield return new WaitForSeconds(1f / framesPerSecond);
            yield return new WaitForSeconds(seconds);
            currentFrameIndex++;
            currentFrameIndex = currentFrameIndex % frames.Length;
        }

    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound = null;
    [SerializeField] GameObject blockSparkleVFX = default;
    [SerializeField] int maxHits = 2;
    [SerializeField] Sprite[] hitSprites = null;

    // cached reference
    Level level;
    GameStatus gameStatus;

    // state variables
    [SerializeField] int timesHit; // TODO only for debug purposes

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        if (tag == "Breakable")
        {
            AddBreakableBlocks();
        }
    }

    private void AddBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        level.AddBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HitControl();
        }
    }

    private void HitControl()
    {
        timesHit++;
        if (timesHit >= maxHits) // kalo == takutnya ga sengaja ke hit 4 malah error
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprites();
        }
    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        PLayBlockBreakingSFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerParticleVFX();
    }

    private void PLayBlockBreakingSFX()
    {
        gameStatus.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    public void TriggerParticleVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
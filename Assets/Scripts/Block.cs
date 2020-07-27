using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound = null;
    [SerializeField] GameObject blockSparkleVFX = default;

    //cached reference
    Level level;
    GameStatus gameStatus;

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
            DestroyBlock();
        }
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
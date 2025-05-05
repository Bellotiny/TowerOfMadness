using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeParticleLoopPause : MonoBehaviour
{
    public ParticleSystem particleSystem; // Reference to your particle system
    public float minPauseDuration = 1f; 
    public float maxPauseDuration = 3f; 

    private void Start()
    {
        if (particleSystem != null)
        {
            StartCoroutine(LoopWithRandomPause());
        }
    }

    private IEnumerator LoopWithRandomPause()
    {
        while (true)
        {
            // Play the particle system
            particleSystem.Play();
            yield return new WaitForSeconds(particleSystem.main.duration);
            float randomPause = Random.Range(minPauseDuration, maxPauseDuration);
            yield return new WaitForSeconds(randomPause);
        }
    }
}

using UnityEngine;

public class ParticleStarter : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _particleSystem.Play();
    }
}

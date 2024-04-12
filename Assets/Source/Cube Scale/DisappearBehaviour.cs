using System.Collections;
using UnityEngine;

// To disappear correctly, material Surface Type on entity should be Transparent

public class DisappearBehaviour : MonoBehaviour
{
    [SerializeField] private float _fadeTimeInSeconds = 0.5f;
    
    public IEnumerator DisappearAsync(Entity entity)
    {
        Renderer renderer = entity.Renderer;
        entity.Rigidbody.isKinematic = true;
        entity.Collider.enabled = false;

        while (Mathf.Approximately(renderer.material.color.a, 0f) == false)
        {
            Color color = renderer.material.color;

            color.a = Mathf.MoveTowards(color.a, 0f, Time.deltaTime / _fadeTimeInSeconds);
            renderer.material.color = color;
            yield return null;
        }

        Destroy(entity.Collider.gameObject);
    }
}

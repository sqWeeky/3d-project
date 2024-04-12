using UnityEngine;

public class EntityModifyBehaviour : MonoBehaviour
{
    [SerializeField] private float _massFactor = 0.5f;
    [SerializeField] private float _scaleFactor = 0.5f;
    [SerializeField] private float _cloneChanceFactor = 0.5f;
    
    public void Modify(Entity entity)
    {
        entity.Rigidbody.mass       *= _massFactor;
        entity.Transform.localScale *= _scaleFactor;
        entity.CloneChance          *= _cloneChanceFactor;
    }
}

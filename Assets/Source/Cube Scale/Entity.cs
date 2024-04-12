using UnityEngine;
using UnityEngine.Assertions;

// Can be placed at ANY GAMEOBJECT and it will clone or disappear on click

[RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(Renderer))]
public class Entity : MonoBehaviour, ICloneableEntity
{
    private float _cloneChance = 100f;
    public float CloneChance
    {
        get => _cloneChance;
        set
        {
            Assert.IsTrue(value > 0 && value <= 100);
            _cloneChance = value;
        }
    }

    public Transform Transform { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Collider Collider { get; private set; }
    public Renderer Renderer { get; private set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Transform = GetComponent<Transform>();
        Collider = GetComponent<Collider>();
        Renderer = GetComponent<Renderer>();
    }

    public Entity Clone()
    {
        return Instantiate(this);
    }
}

public interface ICloneableEntity : IEntity
{
    float CloneChance { get; }
    Entity Clone();
}

public interface IEntity
{
    Transform Transform { get; }
    Rigidbody Rigidbody { get; }
}
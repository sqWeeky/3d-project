using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Cube Activate(Cube cube)
    {
        return Instantiate(cube, transform);
    }
}
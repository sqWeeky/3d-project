using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Cube_1 Activate(Cube_1 cube)
    {
        return Instantiate(cube, transform);
    }
}
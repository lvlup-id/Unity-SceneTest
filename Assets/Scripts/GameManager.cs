using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    Camera cam;
    Vector2 mousePos;
    private void Start()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
            Instantiate(bombPrefab, mousePos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(mousePos, Vector3.one * 0.25f);
    }
}
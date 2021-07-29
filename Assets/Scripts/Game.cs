using UnityEngine;

public class Game : MonoBehaviour
{
    public Material wallMaterial;
    public static int points;
    public int countWals = 10;
    private string _pointsString;
    private int _lastPonts = -1;

    public void Awake()
    {
        points = 0;
        GenerateLevel();
    }

    public void Update()
    {
        if (_lastPonts == points) return;
        _lastPonts = points;
        _pointsString = "Score: " + points.ToString("0000");
    }

    public void OnGUI()
    {
        GUI.color = Color.yellow;
        GUI.Label(new Rect(20, 20, 200, 20), _pointsString ?? "");
    }

    private void GenerateLevel()
    {
        for (int i = 0; i < countWals; i++)
        {
            GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.name = "Wall";
            wall.transform.localScale = new Vector3(2, 2, 2);

            Vector3 pos = new Vector3(Random.Range(-40, 41), 0, Random.Range(-40, 41));
            while (Mathf.Abs(pos.x) < 10 || Mathf.Abs(pos.z) < 10)
            {
                pos = new Vector3(Random.Range(-40, 41), 0, Random.Range(-40, 41));
            }

            wall.transform.position = pos;
            wall.GetComponent<Renderer>().material = wallMaterial;
        }
    }
}
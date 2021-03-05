using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textSpinning1;
    [SerializeField]
    private TextMeshPro textSpinning2;
    [SerializeField]
    private TextMeshPro textSpinning3;
    [SerializeField]
    private GameObject[] levels;
    [SerializeField]
    private float speed;
    public int enemiesDefeated;

    void Start()
    {
        GenerateLevel(true); 
    }

    private void GenerateLevel(bool generate)
    {
        if (generate)
        {
            Instantiate(levels[Random.Range(0, levels.Length)], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("Level"));
        }
    }

    public void Reset()
    {
        enemiesDefeated = 0;
        GenerateLevel(false);
        GenerateLevel(true);
    }

    // Update is called once per frame
    void Update()
    {
        textSpinning1.text = textSpinning2.text = textSpinning3.text = "Enemies Destroyed" + enemiesDefeated;
        transform.Rotate(Vector3.back * Time.deltaTime * speed);
    }
}

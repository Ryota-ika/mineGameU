using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    //Random rand = new Random();
    public int mine_pos_x = 0;
    public int mine_pos_y = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomPosition()
    {
        mine_pos_x = Random.Range(0, 10);
        mine_pos_y = Random.Range(0, 10);
    }
}

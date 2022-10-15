using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int player_pos_x = 0;
    public int player_pos_y = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Position()
    {
        //string PlayerPosition = "p";
        //‰¼‚Ì•û–@
        //PlayerPosition = Input.GetKey(KeyCode.S);
        if (Input.GetKey(KeyCode.S) && this.player_pos_y < 9)
        {
            this.player_pos_y++;
        }
        if (Input.GetKey(KeyCode.D) && this.player_pos_x < 9)
        {
            this.player_pos_x++;
        }
    }
}

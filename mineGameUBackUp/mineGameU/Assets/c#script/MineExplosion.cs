using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour {
    public GameObject mineField;
    private PlayerController player;
    public Vector2 mine_pos=new Vector2(0,0);
    // Start is called before the first frame update
    void Start( ) {
        
        mineField=GameObject.Find( "mineField" );
        player = mineField.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update( ) {
        mine_pos=this.gameObject.transform.position;
        if( this.gameObject.transform.position == player.player_quad.transform.position ) {
            Debug.Log( "îöî≠Ç…êGÇÍÇ‹ÇµÇΩÅB" );
            //player.player_quad.SetActive( false );
            var player_controller=mineField.GetComponent<PlayerController>();
            player_controller.enabled=false;
            Debug.Log("ÉQÅ[ÉÄèIóπ");
        }
    }
}

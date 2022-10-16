using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineExplosion : MonoBehaviour {
    public GameObject mineField;
    private PlayerController player;
    public Vector2 mine_pos = new Vector2( 0, 0 );
    List<MineExplosion> mine = new List<MineExplosion>( );
    GameObject[ ] mineObj = { }; 
    GameObject explosion_text;
    // Start is called before the first frame update
    void Start( ) {

        mineField = GameObject.Find( "mineField" );
        player = mineField.GetComponent<PlayerController>( );

        mineObj = GameObject.FindGameObjectsWithTag( "mine" );//�����ɂ�BP���Ă݂悤
        for( int i = 0; i < mineObj.Length; i++ ) {
            //mine[ i ] = mineObj[ i ].GetComponent<MineExplosion>( );
            mine.Add( mineObj[ i ].GetComponent<MineExplosion>( ) );
        }
    }

    // Update is called once per frame
    void Update( ) {
        mine_pos = this.gameObject.transform.position;
        if( this.gameObject.transform.position == player.player_quad.transform.position ) {
            //Debug.Log( "�����ɐG��܂����B" );
            //player.player_quad.SetActive( false );
            var player_controller = mineField.GetComponent<PlayerController>( );
            player_controller.enabled = false;
            //Debug.Log( "�Q�[���I��" );
            for( int i = 0; i < mineObj.Length; i++ ) {
                mineObj[ i ].SendMessage( "Clear" );

            }
            explosion_text=GameObject.Find("explosion_text");
            Text et=explosion_text.GetComponent<Text>();
            et.text="�������܂����B\n�Q�[���I��!\n\n\n���e�̈ʒu�͂����ł���";
        }
    }

    void Clear( ) {
        this.gameObject.GetComponent<Renderer>( ).material.color = Color.red;
        player.player_quad.SetActive( false );
    }
}

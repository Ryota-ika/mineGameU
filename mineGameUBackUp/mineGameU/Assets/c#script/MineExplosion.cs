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

        mineObj = GameObject.FindGameObjectsWithTag( "mine" );//ここにもBPしてみよう
        for( int i = 0; i < mineObj.Length; i++ ) {
            //mine[ i ] = mineObj[ i ].GetComponent<MineExplosion>( );
            mine.Add( mineObj[ i ].GetComponent<MineExplosion>( ) );
        }
    }

    // Update is called once per frame
    void Update( ) {
        mine_pos = this.gameObject.transform.position;
        if( this.gameObject.transform.position == player.player_quad.transform.position ) {
            //Debug.Log( "爆発に触れました。" );
            //player.player_quad.SetActive( false );
            var player_controller = mineField.GetComponent<PlayerController>( );
            player_controller.enabled = false;
            //Debug.Log( "ゲーム終了" );
            for( int i = 0; i < mineObj.Length; i++ ) {
                mineObj[ i ].SendMessage( "Clear" );

            }
            explosion_text=GameObject.Find("explosion_text");
            Text et=explosion_text.GetComponent<Text>();
            et.text="爆発しました。\nゲーム終了!\n\n\n爆弾の位置はここでした";
        }
    }

    void Clear( ) {
        this.gameObject.GetComponent<Renderer>( ).material.color = Color.red;
        player.player_quad.SetActive( false );
    }
}

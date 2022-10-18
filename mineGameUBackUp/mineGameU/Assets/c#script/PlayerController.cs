using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public GameObject player_quad;
    public Vector3 player_pos = new Vector3( );
        
    //public MineExplosion[ ] mine = new MineExplosion[RandomMine.input_mine_count];
    List<MineExplosion> mine=new List<MineExplosion>();
    public GameObject[ ] mineObj = { };
    cube100 field = new cube100( );
    public GameObject clear_text;
    public GameObject near_position_text;
    // Start is called before the first frame update
    void Start( ) {
        //フィールドに存在する地雷を全て取得
        //GameObjectとして取得した場合はそこからMineExplosionを抽出
        //ここでオブジェクトが取得できてない tagを確認するなどのことをしてほしい
        mineObj = GameObject.FindGameObjectsWithTag( "mine" );//ここにもBPしてみよう
        for( int i = 0; i < mineObj.Length; i++ ) {
            //mine[ i ] = mineObj[ i ].GetComponent<MineExplosion>( );
            mine.Add(mineObj[i].GetComponent<MineExplosion>());
        }

        player_quad = Instantiate( player_quad, new Vector3( 0, 9f, 0 ), Quaternion.identity );
        player_pos = player_quad.transform.position;//x=0 y=9
    }

    // Update is called once per frame
    void Update( ) {
        
        if( Input.GetKeyDown( KeyCode.D ) && player_pos.x < 9 ) {
            //FieldData();
            player_pos.x += 1f;
            //Instantiate(player_quad.transform, new Vector3(pos.x, 9, 0), Quaternion.identity);
        }
        if( Input.GetKeyDown( KeyCode.S ) && player_pos.y > 0 ) {
            player_pos.y -= 1f;
        }
        player_quad.transform.position = player_pos;

        if( player_pos.x == 9 && player_pos.y == 0 ) {
            //Debug.Log( "ゲームクリア" );
            for( int i = 0; i < mineObj.Length; i++ ) {
                mineObj[i].SendMessage("Clear");
            }
            Text ct=clear_text.GetComponent<Text>();
            ct.text="ゲームクリア！\n爆弾の位置はここでした";

        }
        MinePosition( );
    }

    void MinePosition( ) {
        float min_Distance=100;
        //最小値に対して代入する必要がある
        //distanceは距離を測った結果、最終的に出力する必要のある最小値は
        //そこのfor文で最小値を割り出してる
        //List<float> mine_list= new List<float>();
        for( int i = 0; i < mine.Count; i++ ) {//長さの指定かも　mineの長さで計算してみてmine.lengthそこは変えなくていいよここで指定する変数を変えてほしい

            var distance_x = Mathf.Abs( mine[i].mine_pos.x - player_pos.x );
            var distance_y = Mathf.Abs( mine[i].mine_pos.y - player_pos.y );
            var distance = distance_x + distance_y;//ここをBPで見てみよう
            //if( distance < 5 ) {
            //    Debug.Log( "一番近い爆弾の距離は" + distance );
            //}
            if( min_Distance>distance/*最小の距離を指す変数が今回の繰り返しで割り出された距離より大きかった場合*/ ) {//これkここの指揮逆かもOK
                //mine_list.Add(distance);
                //min_DIstanceを更新
                //min_Distanceが最小値になるためにはどの値を入れればいい？
                min_Distance=distance;
            }
        }
        Text np=near_position_text.GetComponent<Text>();
        np.text="一番近い爆弾の距離は"+min_Distance+"です";
        //Debug.Log("一番近い爆弾の距離は"+min_Distance);
        //Debug.Log("一番近い爆弾の距離は"+Mathf.Min( mine_list,mine_list));/*mine_list.Min().ToString()*/;
    }
}

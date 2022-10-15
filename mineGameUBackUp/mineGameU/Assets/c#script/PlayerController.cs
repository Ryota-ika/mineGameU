using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject player_quad;
    public Vector3 player_pos = new Vector3( );
        
    //public MineExplosion[ ] mine = new MineExplosion[RandomMine.input_mine_count];
    List<MineExplosion> mine=new List<MineExplosion>();
    public GameObject[ ] mineObj = { };
    cube100 field = new cube100( );
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
            Debug.Log( "ゲームクリア" );
        }
        MinePosition( );
    }

    void MinePosition( ) {
        float min_Distance=100;
        //mindistanceに最初に入る値は0とかだとそれがそのまま最小になっちゃう可能性があるから最小にならないであろう数がいいね
        //そうOK
        //最小値に対して代入する必要があるね
        //distanceはシンプルに距離を測った結果、最終的に出力する必要のある最小値は
        //そこのfor文で最小値を割り出してる
        //mine_listがややこしいな
        //listのmin関数がなぜか使えなかったから手動で割り出そうって話になったと思うけど
        //そうなるとlistはもう必要じゃなくなると思うそうsou
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
                //min_DIstanceを更新すればいいだけ
                //min_Distanceが最小値になるためにはどの値を入れればいい？そうそうそう
                //上のif文は最小値が最小値でなかった場合に呼び出されて最少を更新した値を代入している
                //あとは出力するのみ
                //さっきの状態はおかしいね
                min_Distance=distance;
            }
        }
        Debug.Log("一番近い爆弾の距離は"+min_Distance);
        //mindistanceに最小値が入っている状態を作り出したい
        //Debug.Log("一番近い爆弾の距離は"+Mathf.Min( mine_list,mine_list));/*mine_list.Min().ToString()*/;
    }
}

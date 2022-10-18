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
    public GameObject explanation_text;
    // Start is called before the first frame update
    void Start( ) {
        //�t�B�[���h�ɑ��݂���n����S�Ď擾
        mineObj = GameObject.FindGameObjectsWithTag( "mine" );
        for( int i = 0; i < mineObj.Length; i++ ) {
            //mine[ i ] = mineObj[ i ].GetComponent<MineExplosion>( );
            mine.Add(mineObj[i].GetComponent<MineExplosion>());
        }

        player_quad = Instantiate( player_quad, new Vector3( 0, 9f, -0.01f ), Quaternion.identity );
        player_pos = player_quad.transform.position;
    }

    // Update is called once per frame
    void Update( ) {
        Text et=explanation_text.GetComponent<Text>();
        et.text="���e������Ȃ���S�[����ڎw�����I\n\n����\nD�������Ɓ�\nS�������Ɓ�\n�Ɉړ������";
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
            //Debug.Log( "�Q�[���N���A" );
            for( int i = 0; i < mineObj.Length; i++ ) {
                mineObj[i].SendMessage("Clear");
            }
            Text ct=clear_text.GetComponent<Text>();
            ct.text="�Q�[���N���A�I\n���e�̈ʒu�͂����ł���";

        }
        MinePosition( );
    }

    void MinePosition( ) {
        float min_Distance=100;
        //List<float> mine_list= new List<float>();
        for( int i = 0; i < mine.Count; i++ ) {

            var distance_x = Mathf.Abs( mine[i].mine_pos.x - player_pos.x );
            var distance_y = Mathf.Abs( mine[i].mine_pos.y - player_pos.y );
            var distance = distance_x + distance_y;//������BP�Ō��Ă݂悤
            //if( distance < 5 ) {
            //    Debug.Log( "��ԋ߂����e�̋�����" + distance );
            //}
            if( min_Distance>distance ) {
                //mine_list.Add(distance);
                //min_DIstance���X�V
                min_Distance=distance;
            }
        }
        Text np=near_position_text.GetComponent<Text>();
        np.text="��ԋ߂����e�̋�����"+min_Distance+"�ł�";
        //Debug.Log("��ԋ߂����e�̋�����"+min_Distance);
        //Debug.Log("��ԋ߂����e�̋�����"+Mathf.Min( mine_list,mine_list));/*mine_list.Min().ToString()*/;
    }
}

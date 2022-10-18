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
        //�t�B�[���h�ɑ��݂���n����S�Ď擾
        //GameObject�Ƃ��Ď擾�����ꍇ�͂�������MineExplosion�𒊏o
        //�����ŃI�u�W�F�N�g���擾�ł��ĂȂ� tag���m�F����Ȃǂ̂��Ƃ����Ăق���
        mineObj = GameObject.FindGameObjectsWithTag( "mine" );//�����ɂ�BP���Ă݂悤
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
        //�ŏ��l�ɑ΂��đ������K�v������
        //distance�͋����𑪂������ʁA�ŏI�I�ɏo�͂���K�v�̂���ŏ��l��
        //������for���ōŏ��l������o���Ă�
        //List<float> mine_list= new List<float>();
        for( int i = 0; i < mine.Count; i++ ) {//�����̎w�肩���@mine�̒����Ōv�Z���Ă݂�mine.length�����͕ς��Ȃ��Ă����悱���Ŏw�肷��ϐ���ς��Ăق���

            var distance_x = Mathf.Abs( mine[i].mine_pos.x - player_pos.x );
            var distance_y = Mathf.Abs( mine[i].mine_pos.y - player_pos.y );
            var distance = distance_x + distance_y;//������BP�Ō��Ă݂悤
            //if( distance < 5 ) {
            //    Debug.Log( "��ԋ߂����e�̋�����" + distance );
            //}
            if( min_Distance>distance/*�ŏ��̋������w���ϐ�������̌J��Ԃ��Ŋ���o���ꂽ�������傫�������ꍇ*/ ) {//����k�����̎w���t����OK
                //mine_list.Add(distance);
                //min_DIstance���X�V
                //min_Distance���ŏ��l�ɂȂ邽�߂ɂ͂ǂ̒l������΂����H
                min_Distance=distance;
            }
        }
        Text np=near_position_text.GetComponent<Text>();
        np.text="��ԋ߂����e�̋�����"+min_Distance+"�ł�";
        //Debug.Log("��ԋ߂����e�̋�����"+min_Distance);
        //Debug.Log("��ԋ߂����e�̋�����"+Mathf.Min( mine_list,mine_list));/*mine_list.Min().ToString()*/;
    }
}

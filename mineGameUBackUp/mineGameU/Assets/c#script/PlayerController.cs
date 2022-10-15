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
            Debug.Log( "�Q�[���N���A" );
        }
        MinePosition( );
    }

    void MinePosition( ) {
        float min_Distance=100;
        //mindistance�ɍŏ��ɓ���l��0�Ƃ����Ƃ��ꂪ���̂܂܍ŏ��ɂȂ����Ⴄ�\�������邩��ŏ��ɂȂ�Ȃ��ł��낤����������
        //����OK
        //�ŏ��l�ɑ΂��đ������K�v�������
        //distance�̓V���v���ɋ����𑪂������ʁA�ŏI�I�ɏo�͂���K�v�̂���ŏ��l��
        //������for���ōŏ��l������o���Ă�
        //mine_list����₱������
        //list��min�֐����Ȃ����g���Ȃ���������蓮�Ŋ���o�������Ęb�ɂȂ����Ǝv������
        //�����Ȃ��list�͂����K�v����Ȃ��Ȃ�Ǝv������sou
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
                //min_DIstance���X�V����΂�������
                //min_Distance���ŏ��l�ɂȂ邽�߂ɂ͂ǂ̒l������΂����H������������
                //���if���͍ŏ��l���ŏ��l�łȂ������ꍇ�ɌĂяo����čŏ����X�V�����l�������Ă���
                //���Ƃ͏o�͂���̂�
                //�������̏�Ԃ͂���������
                min_Distance=distance;
            }
        }
        Debug.Log("��ԋ߂����e�̋�����"+min_Distance);
        //mindistance�ɍŏ��l�������Ă����Ԃ����o������
        //Debug.Log("��ԋ߂����e�̋�����"+Mathf.Min( mine_list,mine_list));/*mine_list.Min().ToString()*/;
    }
}

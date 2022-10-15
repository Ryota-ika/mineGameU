using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Program : MonoBehaviour
{
    const int FIELD_HEIGHT = 10;
    const int FIELD_WIDTH = 10;
    public string[,] data = new string[FIELD_WIDTH, FIELD_HEIGHT];
    public bool[,] mine_data = new bool[FIELD_WIDTH, FIELD_HEIGHT];//false
    public bool[,] goal_data = new bool[9, 9];
    // Start is called before the first frame update
    //var mG = new Board();
    public InputField inputField;
    public Text text;
    Player player = new Player();
    Mine mine = new Mine();
    void Start()
    {
        inputField=inputField.GetComponent<InputField>();
        text=text.GetComponent<Text>();
    }

    public void InputText(){ 
            text.text=inputField.text;
        }

    // Update is called once per frame
    void Update()
    {
        bool end_flg = true;
        //��������͂��Ă�������
        //�������g���ČJ��Ԃ��̏���
        int mc = 0;
        string mine_count = "";
        bool parse_mine_count = true;
        while (parse_mine_count)
        {
            Debug.Log("�n���̐�����͂��Ă��������B");
            mine_count = inputField.text;
            int.TryParse(mine_count, out mc);
            if (mc != 0)
            {
                parse_mine_count = false;
            }
        }
        SetField();
        if (mine_count != "")
        {
            //int�ɂ���mine_count���i�[
            /*mc = int.Parse( mine_count );*/
            for (int i = 0; i < mc; i++)
            {
                mine.RandomPosition();
                if (!(mine.mine_pos_x == 9 && mine.mine_pos_y == 9) || !(mine.mine_pos_x == 0 && mine.mine_pos_y == 0))
                {
                    SetMine(mine.mine_pos_x, mine.mine_pos_y);
                }
            }
        }

        //mG����data��S�ď����o��
        DrawBoard();
        //mG.unit( );

        //mG.MainLoop( );

        //string outChar = "=";
        while (end_flg)
        {
            //�L�[����
            //outChar = Console.ReadKey( ).Key.ToString( );
            Debug.Log("���݂̃v���C���[�̈ʒu��" + player.player_pos_x + player.player_pos_y);
            MinePosition(player);
            player.Position();
            //Console.WriteLine( "���݂̒n���̈ʒu��" + mine.mine_pos_x + mine.mine_pos_y );
            SetPlayer(player.player_pos_x, player.player_pos_y);
            DrawBoard();
            if (mine_data[player.player_pos_x, player.player_pos_y])
            {
                Debug.Log("�n���𓥂݂܂����B");
                end_flg = false;
            }
            if (player.player_pos_x == 9 && player.player_pos_y == 9
                /*mG.goal_data[player.player_pos_x,player.player_pos_y]*/ )
            {
                Debug.Log("�S�[���I�I");
                Debug.Log("�n���̈ʒu�͂����ł���");
                DrawMine();
                DrawBoard();
                end_flg = false;
            }
        }
        //end_flg = CheckKey(outChar);
        //DispMap();
        //DispMessage();
        Debug.Log("�����ꂩ�̃L�[�������ďI�����Ă��������B");
        //Console.ReadKey().Key.ToString();
    }

    public void SetField()
    {
        for (int i = 0; i < FIELD_WIDTH; i++)
        {
            for (int j = 0; j < FIELD_HEIGHT; j++)
            {
                data[i, j] = ".";
            }
        }
    }

    public void DrawBoard()
    {
        for (int y = 0; y < FIELD_HEIGHT; y++)
        {
            for (int x = 0; x < FIELD_WIDTH; x++)
            {
                Debug.Log(data[x, y]);
            }
            Debug.Log("\n");
        }
    }

    public void SetPlayer(int pos_x, int pos_y)
    {
        data[pos_x, pos_y] = "p";
    }

    public void SetMine(int pos_x, int pos_y)
    {
        //��񂾂����Ƃ�
        mine_data[pos_x, pos_y] = true;
        //�`�������Ă��܂�
        //data[pos_x, pos_y] = "m";
    }
    public void DrawMine()
    {
        for (int i = 0; i < FIELD_WIDTH; i++)
        {
            for (int j = 0; j < FIELD_HEIGHT; j++)
            {
                if (mine_data[i, j] == true)
                {
                    data[i, j] = "m";

                }
            }
        }
    }
    public void MinePosition(Player player/*, Mine mine*/ )
    {
        //int shortest = mine_data1[FIELD_WIDTH,FIELD_HEIGHT];
        for (int i = 0; i < FIELD_WIDTH; i++)
        {
            for (int j = 0; j < FIELD_HEIGHT; j++)
            {
                if (mine_data[i, j] == true)
                {
                    //int shortest=int.Parse( mine_data[i, j]);
                    //Array.Sort(mine_data);
                    //shortest�ɑ΂��Ĉ�ԋ߂��n���̋����̒l��������(�����\�[�g�ɋ߂���)
                    int distance_x = Mathf.Abs(i - player.player_pos_x);
                    int distance_y = Mathf.Abs(j - player.player_pos_y);
                    int distance = distance_x + distance_y;
                    if (distance < 5)
                    {
                        Debug.Log("��ԋ߂����e�̋�����" + distance);
                    }
                    //Console.WriteLine(Array.Sort(int.Parse(mine_data[i,j])));
                    //Console.WriteLine( Math.Abs( distance_x ) + Math.Abs( distance_y ) );
                    //�ŏI�I�Ɉ�ԋ߂��n���܂ł̋�����int�^�̒l�Ƃ��ďo��
                }
            }
        }
    }

}

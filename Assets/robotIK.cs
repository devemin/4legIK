using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra;    //Unityの行列は4x4しかないため、行列演算にはこのライブラリを用いる
using MathNet.Numerics.LinearAlgebra.Double;
using UnityEngine.UI;

public class robotIK : MonoBehaviour
{
    //以下MathNet用

    private Matrix<double> startpos = DenseMatrix.OfArray(new double[,]
    {
            { 0 },
            { 0 },
            { 0 }
    });

    private Matrix<double> target_base, target_FL, targetFR, targetRL, targetRR;
    private Matrix<double> p_base, p_FL, p_FR, p_RL, p_RR;                              
    private Matrix<double> r_base, r_FL, r_FR, r_RL, r_RR;

    private static double bodyL = 0.24d;
    private static double bodyW = 0.10d;
    private static float L1 = 0.02f;
    private static float L2 = 0.06f;
    private static float L3 = 0.06f;

    public Transform tra_target_base;
    public Transform tra_target_FL;
    public Transform tra_target_FR;
    public Transform tra_target_RL;
    public Transform tra_target_RR;

    public Transform tra_body_base;
    public Transform tra_body_FL;
    public Transform tra_body_FR;
    public Transform tra_body_RL;
    public Transform tra_body_RR;

    public Transform tra_joint_FL1;
    public Transform tra_joint_FL2;
    public Transform tra_joint_FL3;

    public Transform tra_joint_FR1;
    public Transform tra_joint_FR2;
    public Transform tra_joint_FR3;

    public Transform tra_joint_RL1;
    public Transform tra_joint_RL2;
    public Transform tra_joint_RL3;

    public Transform tra_joint_RR1;
    public Transform tra_joint_RR2;
    public Transform tra_joint_RR3;


    private Text text0;
    private Text text1;
    private Text text2;
    private Text text3;
    private Text text4;
    private Text text5;
    private Text text6;
    private Text text7;
    private Text text8;
    private Text text9;
    private Text text10;
    private Text text11;
    private Text text12;
    private Text text13;
    private Text text14;
    private Text text15;
    private Text text16;
    private Text text17;
    private Text text18;
    private Text text19;
    private Text text20;
    private Text text21;
    private Text text22;
    private Text text23;
    private Text text24;
    private Text text25;
    private Text text26;
    private Text text27;
    private Text text28;
    private Text text29;
    private Text text30;
    private Text text31;
    private Text text32;
    private Text text33;
    private Text text34;
    private Text text35;
    private Text text36;
    private Text text37;
    private Text text38;
    private Text text39;



    // Start is called before the first frame update
    void Start()
    {

        text0 = GameObject.Find("Text (0)").GetComponent<Text>();
        text1 = GameObject.Find("Text (1)").GetComponent<Text>();
        text2 = GameObject.Find("Text (2)").GetComponent<Text>();
        text3 = GameObject.Find("Text (3)").GetComponent<Text>();
        text4 = GameObject.Find("Text (4)").GetComponent<Text>();
        text5 = GameObject.Find("Text (5)").GetComponent<Text>();
        text6 = GameObject.Find("Text (6)").GetComponent<Text>();
        text7 = GameObject.Find("Text (7)").GetComponent<Text>();
        text8 = GameObject.Find("Text (8)").GetComponent<Text>();
        text9 = GameObject.Find("Text (9)").GetComponent<Text>();
        text10 = GameObject.Find("Text (10)").GetComponent<Text>();
        text11 = GameObject.Find("Text (11)").GetComponent<Text>();
        text12 = GameObject.Find("Text (12)").GetComponent<Text>();
        text13 = GameObject.Find("Text (13)").GetComponent<Text>();
        text14 = GameObject.Find("Text (14)").GetComponent<Text>();
        text15 = GameObject.Find("Text (15)").GetComponent<Text>();
        text16 = GameObject.Find("Text (16)").GetComponent<Text>();
        text17 = GameObject.Find("Text (17)").GetComponent<Text>();
        text18 = GameObject.Find("Text (18)").GetComponent<Text>();
        text19 = GameObject.Find("Text (19)").GetComponent<Text>();
        text20 = GameObject.Find("Text (20)").GetComponent<Text>();
        text21 = GameObject.Find("Text (21)").GetComponent<Text>();
        text22 = GameObject.Find("Text (22)").GetComponent<Text>();
        text23 = GameObject.Find("Text (23)").GetComponent<Text>();
        text24 = GameObject.Find("Text (24)").GetComponent<Text>();
        text25 = GameObject.Find("Text (25)").GetComponent<Text>();
        text26 = GameObject.Find("Text (26)").GetComponent<Text>();
        text27 = GameObject.Find("Text (27)").GetComponent<Text>();
        text28 = GameObject.Find("Text (28)").GetComponent<Text>();
        text29 = GameObject.Find("Text (29)").GetComponent<Text>();
        text30 = GameObject.Find("Text (30)").GetComponent<Text>();
        text31 = GameObject.Find("Text (31)").GetComponent<Text>();
        text32 = GameObject.Find("Text (32)").GetComponent<Text>();
        text33 = GameObject.Find("Text (33)").GetComponent<Text>();
        text34 = GameObject.Find("Text (34)").GetComponent<Text>();
        text35 = GameObject.Find("Text (35)").GetComponent<Text>();
        text36 = GameObject.Find("Text (36)").GetComponent<Text>();
        text37 = GameObject.Find("Text (37)").GetComponent<Text>();
        text38 = GameObject.Find("Text (38)").GetComponent<Text>();
        text39 = GameObject.Find("Text (39)").GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        var M = Matrix<double>.Build;
        
        Matrix<double>[,] bodyikdata = new Matrix<double>[5,2];

        bodyikdata = BodyIK(tra_target_base.localEulerAngles.x / 180.0f * Mathf.PI, tra_target_base.localEulerAngles.y / 180.0f * Mathf.PI, tra_target_base.localEulerAngles.z / 180.0f * Mathf.PI, tra_target_base.position.x, tra_target_base.position.y, tra_target_base.position.z);


        text0.text = "base: " + bodyikdata[0, 0].ToString();
        text1.text = "FL: " + bodyikdata[1, 0].ToString();
        text2.text = "FR: " + bodyikdata[2, 0].ToString();
        text3.text = "RL: " + bodyikdata[3, 0].ToString();
        text4.text = "RR: " + bodyikdata[4, 0].ToString();

        text5.text = "base: " + bodyikdata[0, 1].ToString();
        text6.text = "FL: " + bodyikdata[1, 1].ToString();
        text7.text = "FR: " + bodyikdata[2, 1].ToString();
        text8.text = "RL: " + bodyikdata[3, 1].ToString();
        text9.text = "RR: " + bodyikdata[4, 1].ToString();



        text11.text = "FL: " + tra_target_FL.position.ToString();
        text12.text = "FR: " + tra_target_FR.position.ToString();
        text13.text = "RL: " + tra_target_RL.position.ToString();
        text14.text = "RR: " + tra_target_RR.position.ToString();


        tra_body_base.SetPositionAndRotation(new Vector3((float)bodyikdata[0, 0][0, 0], (float)bodyikdata[0, 0][1, 0], (float)bodyikdata[0, 0][2, 0]), tra_target_base.rotation);
        //tra_body_FL.position = new Vector3((float)bodyikdata[1, 0][0, 0], (float)bodyikdata[1, 0][1, 0], (float)bodyikdata[1, 0][2, 0]) ;
        tra_body_FL.SetPositionAndRotation(new Vector3((float)bodyikdata[1, 0][0, 0], (float)bodyikdata[1, 0][1, 0], (float)bodyikdata[1, 0][2, 0]), tra_target_base.rotation);
        tra_body_FR.SetPositionAndRotation(new Vector3((float)bodyikdata[2, 0][0, 0], (float)bodyikdata[2, 0][1, 0], (float)bodyikdata[2, 0][2, 0]), tra_target_base.rotation);
        tra_body_RL.SetPositionAndRotation(new Vector3((float)bodyikdata[3, 0][0, 0], (float)bodyikdata[3, 0][1, 0], (float)bodyikdata[3, 0][2, 0]), tra_target_base.rotation);
        tra_body_RR.SetPositionAndRotation(new Vector3((float)bodyikdata[4, 0][0, 0], (float)bodyikdata[4, 0][1, 0], (float)bodyikdata[4, 0][2, 0]), tra_target_base.rotation);

        //tra_body_FL.Rotate(new Vector3(1, 0, 0), tra_body_base.rotation.x);
        //tra_body_FL.Rotate(new Vector3(0, 1, 0), tra_body_base.rotation.y);
        //tra_body_FL.Rotate(new Vector3(0, 0, 1), tra_body_base.rotation.z);





        float[] anglelist = new float[3];

        Matrix<double>[] convertmat = new Matrix<double>[4];
        Matrix<double> footpointmat = M.Dense(3, 1);


        footpointmat[0, 0] = tra_target_FL.position.x - bodyikdata[0, 0][0, 0];
        footpointmat[1, 0] = tra_target_FL.position.y - bodyikdata[0, 0][1, 0];
        footpointmat[2, 0] = tra_target_FL.position.z - bodyikdata[0, 0][2, 0];
        convertmat[0] = bodyikdata[0, 1].Transpose() * footpointmat;
        convertmat[0][0, 0] = convertmat[0][0, 0] + 0.05f;
        convertmat[0][1, 0] = convertmat[0][1, 0] ;
        convertmat[0][2, 0] = convertmat[0][2, 0] - 0.12f;
        //X座標の反転する
        convertmat[0][0, 0] = -convertmat[0][0, 0];
        text21.text = "FL: " + convertmat[0].ToString();


        footpointmat[0, 0] = tra_target_FR.position.x - bodyikdata[0, 0][0, 0];
        footpointmat[1, 0] = tra_target_FR.position.y - bodyikdata[0, 0][1, 0];
        footpointmat[2, 0] = tra_target_FR.position.z - bodyikdata[0, 0][2, 0];
        convertmat[1] = bodyikdata[0, 1].Transpose() * footpointmat;
        convertmat[1][0, 0] = convertmat[1][0, 0] - 0.05f;
        convertmat[1][1, 0] = convertmat[1][1, 0];
        convertmat[1][2, 0] = convertmat[1][2, 0] - 0.12f;
        //X座標の反転はこれはしない
        text22.text = "FR: " + convertmat[1].ToString();


        footpointmat[0, 0] = tra_target_RL.position.x - bodyikdata[0, 0][0, 0];
        footpointmat[1, 0] = tra_target_RL.position.y - bodyikdata[0, 0][1, 0];
        footpointmat[2, 0] = tra_target_RL.position.z - bodyikdata[0, 0][2, 0];
        convertmat[2] = bodyikdata[0, 1].Transpose() * footpointmat;
        convertmat[2][0, 0] = convertmat[2][0, 0] + 0.05f;
        convertmat[2][1, 0] = convertmat[2][1, 0];
        convertmat[2][2, 0] = convertmat[2][2, 0] + 0.12f;
        //X座標の反転する
        convertmat[2][0, 0] = -convertmat[2][0, 0];
        text23.text = "RL: " + convertmat[2].ToString();


        footpointmat[0, 0] = tra_target_RR.position.x - bodyikdata[0, 0][0, 0];
        footpointmat[1, 0] = tra_target_RR.position.y - bodyikdata[0, 0][1, 0];
        footpointmat[2, 0] = tra_target_RR.position.z - bodyikdata[0, 0][2, 0];
        convertmat[3] = bodyikdata[0, 1].Transpose() * footpointmat;
        convertmat[3][0, 0] = convertmat[3][0, 0] - 0.05f;
        convertmat[3][1, 0] = convertmat[3][1, 0];
        convertmat[3][2, 0] = convertmat[3][2, 0] + 0.12f;
        //X座標の反転はこれはしない
        text24.text = "RR: " + convertmat[3].ToString();



        //Quaternionは、平行移動は加算。回転移動は乗算 !!
        anglelist = LegIK(convertmat[0]);
        tra_joint_FL1.position = new Vector3((float)bodyikdata[1, 0][0, 0], (float)bodyikdata[1, 0][1, 0], (float)bodyikdata[1, 0][2, 0]);
        tra_joint_FL1.rotation = tra_target_base.rotation * Quaternion.Euler(0.0f, 0.0f, (180.0f - anglelist[0] * 180.0f / Mathf.PI - 180.0f)); //Quaternion.Euler(tra_target_base.rotation.x*180.0f/Mathf.PI, tra_target_base.rotation.y * 180.0f / Mathf.PI, tra_target_base.rotation.z * 180.0f / Mathf.PI + (180 - anglelist[0]*180.0f/Mathf.PI -180.0f) );
        tra_joint_FL2.localRotation = Quaternion.Euler(-anglelist[1] * 180.0f / Mathf.PI, 0f, 0f);
        tra_joint_FL3.localRotation = Quaternion.Euler(-anglelist[2] * 180.0f / Mathf.PI, 0f, 0f);

        anglelist = LegIK(convertmat[1]);
        tra_joint_FR1.position = new Vector3((float)bodyikdata[2, 0][0, 0], (float)bodyikdata[2, 0][1, 0], (float)bodyikdata[2, 0][2, 0]);
        tra_joint_FR1.rotation = tra_target_base.rotation * Quaternion.Euler(0.0f, 0.0f, (180.0f + anglelist[0] * 180.0f / Mathf.PI - 180.0f)); //Quaternion.Euler(tra_target_base.rotation.x*180.0f/Mathf.PI, tra_target_base.rotation.y * 180.0f / Mathf.PI, tra_target_base.rotation.z * 180.0f / Mathf.PI + (180 - anglelist[0]*180.0f/Mathf.PI -180.0f) );
        tra_joint_FR2.localRotation = Quaternion.Euler(-anglelist[1] * 180.0f / Mathf.PI, 0f, 0f);
        tra_joint_FR3.localRotation = Quaternion.Euler(-anglelist[2] * 180.0f / Mathf.PI, 0f, 0f);

        anglelist = LegIK(convertmat[2]);
        tra_joint_RL1.position = new Vector3((float)bodyikdata[3, 0][0, 0], (float)bodyikdata[3, 0][1, 0], (float)bodyikdata[3, 0][2, 0]);
        tra_joint_RL1.rotation = tra_target_base.rotation * Quaternion.Euler(0.0f, 0.0f, (180.0f - anglelist[0] * 180.0f / Mathf.PI - 180.0f)); //Quaternion.Euler(tra_target_base.rotation.x*180.0f/Mathf.PI, tra_target_base.rotation.y * 180.0f / Mathf.PI, tra_target_base.rotation.z * 180.0f / Mathf.PI + (180 - anglelist[0]*180.0f/Mathf.PI -180.0f) );
        tra_joint_RL2.localRotation = Quaternion.Euler(-anglelist[1] * 180.0f / Mathf.PI, 0f, 0f);
        tra_joint_RL3.localRotation = Quaternion.Euler(-anglelist[2] * 180.0f / Mathf.PI, 0f, 0f);

        anglelist = LegIK(convertmat[3]);
        tra_joint_RR1.position = new Vector3((float)bodyikdata[4, 0][0, 0], (float)bodyikdata[4, 0][1, 0], (float)bodyikdata[4, 0][2, 0]);
        tra_joint_RR1.rotation = tra_target_base.rotation * Quaternion.Euler(0.0f, 0.0f, (180.0f + anglelist[0] * 180.0f / Mathf.PI - 180.0f)); //Quaternion.Euler(tra_target_base.rotation.x*180.0f/Mathf.PI, tra_target_base.rotation.y * 180.0f / Mathf.PI, tra_target_base.rotation.z * 180.0f / Mathf.PI + (180 - anglelist[0]*180.0f/Mathf.PI -180.0f) );
        tra_joint_RR2.localRotation = Quaternion.Euler(-anglelist[1] * 180.0f / Mathf.PI, 0f, 0f);
        tra_joint_RR3.localRotation = Quaternion.Euler(-anglelist[2] * 180.0f / Mathf.PI, 0f, 0f);



    }

    //ボディIK　原点から引数による角度・移動量でのIKを解き、移動後座標、回転移動行列の配列を返す [5x2]　
    //[0,]:base, [1,]:FL, [2,]:FR, [3,]:RL, [4,]:RR
    //[,0]:pos, [,1]:rot
    public Matrix<double>[,] BodyIK(float omega, float phi, float psi, float xm, float ym, float zm)
    {
        Matrix<double>[,] res = new Matrix<double>[5, 2];


        var M = Matrix<double>.Build;
        
        Matrix<double> pbase = DenseMatrix.OfArray(new double[,]
        {
            { xm },
            { ym },
            { zm }
        });
        Matrix<double> Rwbase = M.Dense(3, 3);


        var Rx = DenseMatrix.OfArray(new double[,]
        {
            { 1, 0, 0 },
            { 0, Mathf.Cos(omega), -Mathf.Sin(omega)},
            { 0, Mathf.Sin(omega), Mathf.Cos(omega)}
        });
        var Ry = DenseMatrix.OfArray(new double[,]
        {
            { Mathf.Cos(phi), 0, Mathf.Sin(phi)},
            { 0, 1, 0},
            { -Mathf.Sin(phi), 0, Mathf.Cos(phi)}
        });
        var Rz = DenseMatrix.OfArray(new double[,]
        {
            { Mathf.Cos(psi), -Mathf.Sin(psi), 0 },
            { Mathf.Sin(psi), Mathf.Cos(psi), 0 },
            { 0, 0, 1 }
        });


        res[0, 0] = pbase;

        //Unity は Z->X->Y の順番！
        Rwbase = Ry * Rx * Rz;
        res[0, 1] = Rwbase;



        var sHp = Mathf.Sin(Mathf.PI / 2.0f);
        var cHp = Mathf.Cos(Mathf.PI / 2.0f);

        res[1, 0] = DenseMatrix.OfArray(new double[,]
        {
            { -bodyW / 2 },
            { 0 },
            { bodyL / 2 }
        });
        res[1, 0] = Rwbase * res[1, 0] + pbase;
        res[1, 1] = DenseMatrix.OfArray(new double[,]
        {
            { 1,0,0 },
            { 0,1,0 },
            { 0,0,1 }
            /*
            { cHp, 0, sHp },
            { 0, 1, 0 },
            { -sHp, 0, cHp  }
            */
        });
        res[1, 1] = Rwbase * res[1, 1];

        res[2, 0] = DenseMatrix.OfArray(new double[,]
        {
            { bodyW / 2},
            { 0},
            { bodyL / 2 }
        });
        res[2, 0] = Rwbase * res[2, 0] + pbase;
        res[2, 1] = DenseMatrix.OfArray(new double[,]
        {
            { 1,0,0 },
            { 0,1,0 },
            { 0,0,1 }
            /*
            { cHp, 0, sHp },
            { 0, 1, 0 },
            { -sHp, 0, cHp  }
            */
        });
        res[2, 1] = Rwbase * res[2, 1];

        res[3, 0] = DenseMatrix.OfArray(new double[,]
        {
            { -bodyW / 2},
            { 0 },
            { -bodyL / 2}
        });
        res[3, 0] = Rwbase * res[3, 0] + pbase;
        res[3, 1] = DenseMatrix.OfArray(new double[,]
        {
            { 1,0,0 },
            { 0,1,0 },
            { 0,0,1 }
            /*
            { cHp, 0, sHp },
            { 0, 1, 0 },
            { -sHp, 0, cHp  }
            */
        });
        res[3, 1] = Rwbase * res[3, 1];

        res[4, 0] = DenseMatrix.OfArray(new double[,]
        {
            {  bodyW / 2},
            {  0},
            { -bodyL / 2 }
        });
        res[4, 0] = Rwbase * res[4, 0] + pbase;
        res[4, 1] = DenseMatrix.OfArray(new double[,]
        {
            { 1,0,0 },
            { 0,1,0 },
            { 0,0,1 }
            /*
            { cHp, 0, sHp },
            { 0, 1, 0 },
            { -sHp, 0, cHp  }
            */
        });
        res[4, 1] = Rwbase * res[4, 1];




        return res;

    }


    //脚のIK　ローカル座標０から引数の座標へのIKを解き、サーボ角度３つを返す
    //配列　0: shoulder, 1:leg, 2:foot
    //注意：　これは左足のものと想定した計算関数なので、右足の場合は事前に座標反転して引数に入力する
    public float[] LegIK(Matrix<double> mat)
    {
        //https://gitlab.com/custom_robots/spotmicroai/simulation/-/tree/master/Kinematics

        float[] res = new float[3];

        //XY平面で計算
        float P1toTP = Mathf.Sqrt(Mathf.Pow((float)mat[0, 0], 2.0f) + Mathf.Pow((float)-mat[1, 0], 2.0f));
        float P2toTP = Mathf.Sqrt(Mathf.Pow(P1toTP, 2.0f) - Mathf.Pow(L1, 2.0f) );

        //L1-P2toTP-P1toTP でできる三角形の１角から、Atan2(y,x)（x,yでX軸となす角度）を減じて、サーボ１の角度を求める
        float alpha = Mathf.Atan2(P2toTP, L1);
        float beta  = Mathf.Atan2((float)-mat[1, 0], (float)mat[0, 0]);
        res[0] = alpha - beta;

        //次の計算のため、P2-target の3D距離を求めてる
        float P2toTP3D = Mathf.Sqrt(Mathf.Pow(P2toTP, 2.0f) + Mathf.Pow((float)mat[2, 0], 2.0f));

        //P2-target 平面での計算を行う
        //L2とL3の成す角度を求め、サーボ３の角度を求める
        float cosL2toL3 = (Mathf.Pow(L2, 2.0f) + Mathf.Pow(L3, 2.0f) - Mathf.Pow(P2toTP3D, 2.0f)) / (-2.0f * L2 * L3);
        res[2] = Mathf.Acos(cosL2toL3);


        //(A). L2を延長し、L2+延長戦を底辺とした直角三角形を作り、斜辺はL2-targetとなる。
        //Atan2(z, P2-target3D)の成す角度と、(A)の1角を合計しサーボ２の角度を求める
        //https://mathtrain.jp/kangenkoushiki
        //cos(90-theta) = sin(theta)など 
        res[1] = Mathf.Atan2((float)mat[2, 0], P2toTP) - Mathf.Atan2(L3*Mathf.Sin(res[2]), L2+L3*Mathf.Cos(res[2]) ) ;


        return res;
    }

}

//---------------------------------
//�����t�F�[�Y�i�ߓ�
//�S���ҁF����
//---------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;  // LINQ��g�����߂ɕK�v
using UnityEngine.UI;
using Unity.VisualScripting;


public class CS_SetPheseController : MonoBehaviour
{
    public GameObject[] cubes; // �F��ړ�������Cube�̔z��
    public Button transferButton; // �{�^��

    //[SerializeField]
    //CSO_SetPhaseStatus mProbabilityStatus;
    //List<float> mProbabilities = new List<float>();

    [SerializeField,Header("�~�b�V�������")]
    private CSO_SetPhaseTable mMissionStatus;

    [SerializeField, Header("�~�b�V�����I��v���n�u")]
    private GameObject mMisstionSelect;

    //���o���I��������ۂ�
    private bool mPerformanceFinish = true;


    private int mPrizesNum = 0;//���ܐ�

    private CS_Controller mBigController;//�i�ߓ���

 //-----------------------�C�x���g�n���h��-----------------------
    public delegate void Performance(int _performance);

    //���o�𗬂��g���K�[�C�x���g
    public static event Performance OnPlayPerformance;
 //-------------------------------------------------------------



    int debugCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        //�p�t�H�[�}���X���X�g����m����R�s�[
        //for (int i = 0; i < mProbabilityStatus.performances.Count; i++)
        //{
        //    mProbabilities.Add(mProbabilityStatus.performances[i].value);
        //    Debug.Log(mProbabilityStatus.performances[i].name + "�̊m��" + mProbabilities[i] + "%");
        //}

       

        mBigController = GameObject.Find("BigController").GetComponent<CS_Controller>();//�i�ߓ��i��j��擾
        Instantiate(mMisstionSelect, mMisstionSelect.transform.position, mMisstionSelect.transform.rotation);

        // �{�^���������ꂽ�Ƃ��̃C�x���g��ݒ�
        transferButton.onClick.AddListener(MoveColor);
    }

    // Update is called once per frame
    void Update()
    {

        //CheckLottery();
      
        //�ϓ��I���t���O��擾
        CS_Controller ctrl = GameObject.Find("BigController").GetComponent<CS_Controller>();

        //���̕ϓ����J�n�ł��邩
        bool variationStart = ctrl.CanVariationStart();
        if (!variationStart) { return; }


        //�c����ܐ���0�H
        if(mPrizesNum == 3)
        {
            //�J�[�\���ړ����鏈��


            mPrizesNum = 0;//�e�X�g�p
            //�~�b�V�����I��̏��������
            return;
        }

        // �T�u�X�N���C�u�m�F�̃��O�o��
        if (OnPlayPerformance == null) { return; }

        //�ۗ��ʐ���0�Ȃ�I��
        if(mBigController.GetStock() == 0) { return; }

        //�ۗ��ʂ�g�p
        mBigController.UseStock();

        //�~�b�V�������I
        int randomNumber = CS_LotteryFunction.LotNormalInt(mMissionStatus.infomation[mPrizesNum].mission.Count -1);
        mPerformanceFinish = false;//���o�I���t���O��false

        mPrizesNum++;//���ܐ��𑝂₷


        if (OnPlayPerformance != null)
        {
            //���o�J�n�g���K�[��ON
            OnPlayPerformance(randomNumber);
        }
           
    }



    private void CheckLottery()
    {
        if (debugCount < 10000)
        {
            //int randomNumber = CS_LotteryFunction.LotPerformance(mProbabilities);
            //Debug.Log("�����_���ɑI�΂ꂽ���o: " + mProbabilityStatus.performances[randomNumber].name);
            //debugCount++;

            //if (debugCount >= 10000)
            //{
            //    Debug.Log("10000��I��");
            //}
        }

    }

    //�V�[����ɂ���I�u�W�F�N�g����CS_SetPheseController������ĕԂ�
    public static CS_SetPheseController GetCtrl()
    {
        //�V�[����̑S�Ă�GameObject��擾���āA���O��mPrefabName��܂ރI�u�W�F�N�g�����
        GameObject targetObject = FindObjectsOfType<GameObject>()
            .FirstOrDefault(obj => obj.name.Contains("SetPhaseCtrl"));
        if (targetObject != null)
        {
            Debug.Log("�����t�F�[�Y�i�ߓ�����������");
            return targetObject.GetComponent<CS_SetPheseController>();
        }
        return null;
    }

    //���o�I���֐�
    public void PerformanceFinish()
    {
        mPerformanceFinish = true;
    }
    
    //�o�^����Ă���C�x���g�n���h������ׂč폜
    public static void RemoveAllHandlers()
    {
        // OnPlayPerformance �ɉ�������̃n���h�����o�^����Ă���ꍇ
        if (OnPlayPerformance != null)
        {
            // OnPlayPerformance �ɓo�^����Ă���S�Ẵn���h����擾
            Delegate[] handlers = OnPlayPerformance.GetInvocationList();

            // ���ׂẴn���h������
            foreach (Delegate handler in handlers)
            {
                OnPlayPerformance -= (Performance)handler;
            }
        }
    }

    //�I�u�W�F�N�g�̐F��ڂ�
    private void MoveColor()
    {
        // �F��ׂ̃I�u�W�F�N�g�Ɉړ�������
        for (int i = 0; i < cubes.Length; i++)
        {
            Color currentColor = cubes[i].GetComponent<Renderer>().material.color;

            if (i < cubes.Length - 1) // �Ō��Cube�̏ꍇ�͉�����Ȃ�
            {
                cubes[i + 1].GetComponent<Renderer>().material.color = currentColor;
            }

            // �Ō��Cube�̐F��N���A����ꍇ�͈ȉ��̍s��L���ɂ��܂�
            // cubes[i].GetComponent<Renderer>().material.color = Color.white;
        }
    }

}

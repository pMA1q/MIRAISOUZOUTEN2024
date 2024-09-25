//---------------------------------
//�����t�F�[�Y�i�ߓ�
//�S���ҁF����
//---------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CS_SetPheseController : MonoBehaviour
{
   

    //�eEnum�ɑ΂���m��
    [SerializeField]
    CS_TestProbabilityStatus mProbabilityStatus;
    List<float> mProbabilities = new List<float>();

    //���o���I��������ۂ�
    private bool mPerformanceFinish = true;
    

//-------------------------------�C�x���g�n���h��----------------
    public delegate void Performance(int _performance);

    //���o�𗬂��g���K�[�C�x���g
    public static event Performance OnPlayPerformance;
//-------------------------------------------------------------

    int debugCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //�e�m����%�ɒ���
        for (int i = 0; i < mProbabilityStatus.performances.Count; i++)
        {
            mProbabilities.Add(mProbabilityStatus.performances[i].value);
            Debug.Log(mProbabilityStatus.performances[i].name + "�̊m��" + mProbabilities[i] + "%");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //CheckLottery();
        //���o���I����Ă��Ȃ��Ȃ�I��
        if (!mPerformanceFinish) { return; }

        //�ۗ��ʂ��g�p

        //���o���I
        int randomNumber = CS_LotteryFunction.LotPerformance(mProbabilities);
        mPerformanceFinish = false;
        //���o�J�n�g���K�[��ON
        OnPlayPerformance(randomNumber);
    }



    private void CheckLottery()
    {
        if (debugCount < 10000)
        {
            int randomNumber = CS_LotteryFunction.LotPerformance(mProbabilities);
            Debug.Log("�����_���ɑI�΂ꂽ���o: " + mProbabilityStatus.performances[randomNumber].name);
            debugCount++;

            if (debugCount >= 10000)
            {
                Debug.Log("10000��I��");
            }
        }

    }

    //���o�I���֐�
    public void PerformanceFinish()
    {
        mPerformanceFinish = true;
    }

    //�o�^����Ă���C�x���g�n���h�������ׂč폜
    public static void RemoveAllHandlers()
    {
        // OnPlayPerformance �ɉ�������̃n���h�����o�^����Ă���ꍇ
        if (OnPlayPerformance != null)
        {
            // OnPlayPerformance �ɓo�^����Ă���S�Ẵn���h�����擾
            Delegate[] handlers = OnPlayPerformance.GetInvocationList();

            // ���ׂẴn���h��������
            foreach (Delegate handler in handlers)
            {
                OnPlayPerformance -= (Performance)handler;
            }
        }
    }
}

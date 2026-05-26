using UnityEngine;

public class Mole : MonoBehaviour
{
    [SerializeField] Material DefaultMaterial;
    [SerializeField] Material HitMaterial;

    public GameObject TimerObject;

    private bool allowAddPoint = true;
    private bool moleUpTimeFlag = true;
    private float randomMoleUpTime;
    private float randomMoleDownTime;
    private int addPoint = 1;

    private void OnMouseDown()
    {
        EndTimer timer = TimerObject.GetComponent<EndTimer>();
        if (!timer.gameEnd)
        {
            if (allowAddPoint)
            {
                ScoreCount scoreCount = GetComponentInParent<ScoreCount>();
                scoreCount.SetScore(addPoint);
                allowAddPoint = false;
                this.GetComponent<MeshRenderer>().material = HitMaterial;
            }
        }      
    }

    private void Update()
    {
        MoveMole();
    }

    private void MoveMole()
    {
        EndTimer timer = TimerObject.GetComponent<EndTimer>();
        if (!timer.gameEnd)
        {
            if (moleUpTimeFlag && randomMoleDownTime <= 0)
            {
                int timeLimitDivisor = 10;

                float moleUpTimeUpperLimit = Mathf.RoundToInt(timer.timeLimit) / timeLimitDivisor;
                float moleUpTimeLowerLimit = 1f;

                if (moleUpTimeUpperLimit == 0)
                {
                    moleUpTimeUpperLimit = 1;
                }

                randomMoleUpTime = Random.Range(moleUpTimeLowerLimit, moleUpTimeUpperLimit);

                moleUpTimeFlag = false;
                allowAddPoint = true;
            }
            else if (!moleUpTimeFlag && randomMoleUpTime <= 0)
            {
                int timeLimitDivisor = 10;

                float moleDownTimeUpperLimit = Mathf.RoundToInt(timer.timeLimit) / timeLimitDivisor;
                float moleDownTimeLowerLimit = 2f;

                if (moleDownTimeUpperLimit == 0)
                {
                    moleDownTimeUpperLimit = 1;
                }

                randomMoleDownTime = Random.Range(moleDownTimeLowerLimit, moleDownTimeUpperLimit);

                moleUpTimeFlag = true;
                allowAddPoint = false;
                this.GetComponent<MeshRenderer>().material = DefaultMaterial;
            }

            float moleObjectPosition_YCoordinate = 0.75f;
            float moleObjectPosition_MinusYCoordinate = -0.75f;

            if (randomMoleUpTime > 0)
            {
                transform.position = new Vector3(transform.position.x, moleObjectPosition_YCoordinate, transform.position.z);
            }
            else if (randomMoleUpTime < 0)
            {
                transform.position = new Vector3(transform.position.x, moleObjectPosition_MinusYCoordinate, transform.position.z);
            }

            if (!moleUpTimeFlag)
            {
                randomMoleUpTime -= Time.deltaTime;
            }
            else if (moleUpTimeFlag)
            {
                randomMoleDownTime -= Time.deltaTime;
            }
        }         
    }
}

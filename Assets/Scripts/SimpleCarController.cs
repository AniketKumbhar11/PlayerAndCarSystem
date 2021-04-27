using UnityEngine;

public class SimpleCarController : MonoBehaviour {
   private float m_horizontalInput;
   private float m_verticalInput;
  private float m_steeringAngle;

    private Rigidbody rb;
    public Vector3 Centerofmass;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30f;
    public float motorForce = 50f;
    public bool Isbrk = false;
    public float motarBrk;
    public float Curentmotarbrek;


    public BoxCollider LeftDoor;
    public BoxCollider RightDoor;
    public bool CarInput;
    private void Start()
    {
        CarInput = false;
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Centerofmass;
    }


    public void GetInput()
	{
        
        {
            m_horizontalInput = Input.GetAxis("Horizontal");
            m_verticalInput = Input.GetAxis("Vertical");
        }


    }

	private void Steer()
	{
		m_steeringAngle = maxSteerAngle * m_horizontalInput;
		frontDriverW.steerAngle = m_steeringAngle;
		frontPassengerW.steerAngle = m_steeringAngle;
	}

	private void Accelerate()
	{
        rearDriverW.motorTorque = m_verticalInput * motorForce;
        rearPassengerW.motorTorque = m_verticalInput * motorForce;




        Curentmotarbrek = Isbrk ? motarBrk : 0;

        if (Isbrk)
        {
            ApplyBraking();

        }
        else
        {
            ReasleBrk();
        }

    }
    private void ApplyBraking()
    {
        frontDriverW.brakeTorque = Curentmotarbrek * Curentmotarbrek;
        frontPassengerW.brakeTorque = Curentmotarbrek * Curentmotarbrek;
        rearDriverW.brakeTorque = Curentmotarbrek * Curentmotarbrek;
        rearPassengerW.brakeTorque = Curentmotarbrek * Curentmotarbrek;



    }
    private void ReasleBrk()
    {
        frontDriverW.brakeTorque = Curentmotarbrek;
        frontPassengerW.brakeTorque = Curentmotarbrek;
        rearDriverW.brakeTorque = Curentmotarbrek;
        rearPassengerW.brakeTorque = Curentmotarbrek;
        rearPassengerW.brakeTorque = Curentmotarbrek;
    }

    private void UpdateWheelPoses()
	{
		UpdateWheelPose(frontDriverW, frontDriverT);
		UpdateWheelPose(frontPassengerW, frontPassengerT);
		UpdateWheelPose(rearDriverW, rearDriverT);
		UpdateWheelPose(rearPassengerW, rearPassengerT);
	}

	private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
	{
		Vector3 _pos = _transform.position;
		Quaternion _quat = _transform.rotation;

		_collider.GetWorldPose(out _pos, out _quat);

		_transform.position = _pos;
		_transform.rotation = _quat;
	}

    private void FixedUpdate()
    {

        if (CarInput)
        {
            GetInput();
            Steer();
            Accelerate();
            UpdateWheelPoses();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Isbrk = true;


        else if (Input.GetKeyUp(KeyCode.Space))

            Isbrk = false;



        if (LeftDoor.gameObject.tag == "Player")
        {
            Debug.Log("Player Tigerit");
        }
    }



 
    

    
}

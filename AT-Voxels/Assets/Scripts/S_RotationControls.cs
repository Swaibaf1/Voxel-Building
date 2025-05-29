using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_RotationControls : MonoBehaviour
{
    [SerializeField] GameObject m_objectToRotate;
    [SerializeField] Transform m_rotationPoint;
    [SerializeField] float m_rotationSpeed;
    [SerializeField] float m_verticalMultiplier;
    Vector2 m_rotateValues; 
    bool m_isLookingHorizontal;
    bool m_isLookingVertical;
    bool m_isShiftPressed = false;

    
  
    // Update is called once per frame
    void Update()
    {
        if(!m_isShiftPressed)
        {
            if(m_isLookingHorizontal)
            {
                RotateLeftRight(m_rotateValues.x);
            }
            if (m_isLookingVertical)
            {   
                RotateUpDown(m_rotateValues.y);
            }
        }


        

       
    }

    void MoveUpDown(float _speed)
    {
        float _value = (_speed / m_verticalMultiplier);

        m_objectToRotate.transform.position += new Vector3(0,_value,0);

    }

    void MoveLeftRight(float _speed)
    {
        float _value = (_speed / m_verticalMultiplier);

        m_objectToRotate.transform.position += new Vector3(_value, 0, 0);
    }

    void RotateLeftRight(float _speed)
    {
        Vector3 _angle = _speed * Vector3.up;
        m_objectToRotate.transform.Rotate(_angle);
    }

    void RotateUpDown(float _speed)
    {
        Vector3 _angle = _speed * Vector3.right;
        m_objectToRotate.transform.Rotate(_angle);
    }


    public void OnLookHorizontal(InputAction.CallbackContext _context)
    {
        if(_context.started)
        { 
           m_isLookingHorizontal = true;
           m_rotateValues.x = _context.ReadValue<float>();
           if(m_isShiftPressed)
           {
                MoveLeftRight(m_rotateValues.x);
           }

        }
        else if(_context.canceled)
        {
            m_isLookingHorizontal = false;
        }
        
    }

    public void OnLookVertical(InputAction.CallbackContext _context)
    { 
        if(_context.started)
        {
            m_isLookingVertical = true;
            m_rotateValues.y = -_context.ReadValue<float>();
            if(m_isShiftPressed)
            {
                MoveUpDown(-m_rotateValues.y);
            }
            
        }
        else if(_context.canceled)
        {
            m_isLookingVertical = false;
        }
    }

    public void OnShiftPressed(InputAction.CallbackContext _context)
    {
        if(_context.started)
        {
            m_isShiftPressed = true;
        }

        else if (_context.canceled)
        {
            m_isShiftPressed = false;
        }

    }

}

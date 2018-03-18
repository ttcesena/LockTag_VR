using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LockTag
{
    public class BreakroomProgression : LevelStack
    {
        #region States
        public enum States
        {
            PreStart,
            Visor,
            Gloves,
            Move,
            Fridge,
            Soda,
            Table,
            Leaving
        }
        #endregion

        #region Singleton
        static protected BreakroomProgression _instance;
        static public BreakroomProgression Instance { get { return _instance; } }
        #endregion

        #region Action References
        public Visor visor;

        public GameObject fridgeHandle;
        private FridgeStateDoorCheck fridgeDoorCheck;

        public TableStateCheck tableCheck;

        public GameObject breakroomDoor;
        #endregion

        #region Functions
        private void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning(this.GetType().Name + " is already in play. Deleting new!", gameObject);
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }
        private void Start()
        {
            currentState = States.PreStart;
        }

        #region State Machine
        void PreStart_EnterState()
        {
            Debug.Log("In PreStart");
            currentState = States.Visor;

            // disable movement
        }

        void PreStart_SuperUpdate()
        {

        }

        void PreStart_ExitState()
        {

        }

        void Visor_EnterState()
        {
            // Voice line here
            Debug.Log("In Visor");
        }

        void Visor_SuperUpdate()
        {
            // if visor is on -> currentState = States.Gloves;
            if (visor.equipped == true)
            {
                currentState = States.Gloves;
            }
        }

        void Gloves_EnterState()
        {
            // Voice line here
            Debug.Log("In Gloves");

            // skip for now
            currentState = States.Move;
        }

        void Gloves_SuperUpdate()
        {
            // if gloves are on -> currentState = States.Move;
        }

        void Move_EnterState()
        {
            Debug.Log("In Move");

            // skip for now
            currentState = States.Fridge;

            // enable movement
        }

        // fridge
        void Fridge_EnterState()
        {
            Debug.Log("In Fridge");

            // highlight fridge
            //OutlineManager.Instance.Outline(fridgeHandle, true);
            fridgeHandle.GetComponent<LiveHighlightingManager>().isHighlighted = true;
            fridgeDoorCheck = fridgeHandle.GetComponent<FridgeStateDoorCheck>();
        }

        void Fridge_SuperUpdate()
        {
            if (fridgeDoorCheck.fridgeDoorCheck)
                currentState = States.Table;
        }
        // soda[[IS THIS NEEDED??]]
        void Soda_EnterState()
        {
            // voice line here
        }

        void Soda_SuperUpdate()
        {
            // wait for right soda on table
        }

        // table
        void Table_EnterState()
        {
            Debug.Log("In Table");
        }

        void Table_SuperUpdate()
        {
            if (tableCheck.sodaOnTable)
                currentState = States.Leaving;
        }
        // leaving
        void Leaving_EnterState()
        {
            Debug.Log("In Leaving");
            breakroomDoor.SetActive(false);
        }
        void Leaving_SuperUpdate()
        {

        }
        #endregion

        #endregion
    }
}

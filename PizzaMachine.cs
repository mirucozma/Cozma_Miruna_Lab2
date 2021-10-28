using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;
using System.ComponentModel;


namespace Cozma_Miruna_Lab2  
{
    class PizzaMachine : Component            //3.1          3.5
    {
        private PizzaType mIngredients;        //3.4
        public PizzaType Ingredients
        {
            get
            {
                return mIngredients;
            }
            set
            {
                mIngredients = value;
            }
        }
        private System.Collections.ArrayList mPizzas = new System.Collections.ArrayList();   //3.5
        public Pizza this[int Index]
        {
            get
            {
                return (Pizza)mPizzas[Index];
            }
            set
            {
                mPizzas[Index] = value;
            }
        }
        public delegate void PizzaCompleteDelegate();       //3.6
        public event PizzaCompleteDelegate PizzaComplete;
        DispatcherTimer pizzaBakeTimer;         //3.7

        private void InitializeComponent()      //3.8
        {
            this.pizzaBakeTimer = new DispatcherTimer();
            this.pizzaBakeTimer.Tick += new System.EventHandler(this.pizzaBakeTimer_Tick);
        }
        private void pizzaBakeTimer_Tick(object sender, EventArgs e)   //3.10
        {
            Pizza aPizza = new Pizza(this.Ingredients);
            mPizzas.Add(aPizza);
            PizzaComplete();
        }
        public PizzaMachine()        //3.9
        {
            InitializeComponent();
        }

        
        public bool Enabled
        {                                //3.11
            set
            {
                pizzaBakeTimer.IsEnabled = value;
            }
        }
        public int Interval
        {
            set
            {
                pizzaBakeTimer.Interval = new TimeSpan(0, 0, value);
            }
        }
        public void MakePizzas(PizzaType dIngredients)           //3.12
        {
            Ingredients = dIngredients;

            switch (Ingredients)
            
            {
                case PizzaType.Canibale: Interval = 3; break;
                case PizzaType.Margherita: Interval = 2; break;
                case PizzaType.Pepperoni: Interval = 5; break;
                case PizzaType.Quattro_Stagioni: Interval = 7; break;
                case PizzaType.Veggie: Interval = 4; break;
            }
            pizzaBakeTimer.Start();
        }
    }  //end PizzaMachine Class
    enum PizzaType   //3.2
    {
        Margherita,
        Pepperoni,
        Veggie,
        Quattro_Stagioni,
        Canibale
    }
    class Pizza               //3.3
    {
        private PizzaType mIngredients; // câmp
        public PizzaType Ingredients // proprietate
        {
            get //metoda get
            {
                return mIngredients;
            }
            set //metoda set
            {
                mIngredients = value;
            }
        }
        private float mPrice = .50F;
        private float Price
        {
            get
            {
                return mPrice;
            }
            set
            {
                mPrice = value;
            }
        }
        private readonly DateTime mTimeOfCreation;
        public DateTime TimeOfCreation
        {
            get
            {
                return mTimeOfCreation;
            }
        }
        public Pizza(PizzaType aIngredients) // constructor
        {
            mTimeOfCreation = DateTime.Now;
            mIngredients = aIngredients;
        }
    }// end Pizza class 

}

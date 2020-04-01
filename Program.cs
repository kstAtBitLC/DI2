using System;
using System.Collections.Generic;

namespace DependencyInjection_2
{
    interface IWerkzeug
    {
        void Graben();
    }


    class Meister {
        List<Lehrling> Lehrlinge = new List<Lehrling>();

        public void WerArbeitetBeiDir(){
            foreach (var item in Lehrlinge)
            {
                Lehrling l = (Lehrling) item;
                System.Console.WriteLine( l.Name );                
            }
            System.Console.WriteLine( );
        }

        public void ErteileAnweisung(IWerkzeug irgendwasZumGraben){  
            Lehrling l = (Lehrling) Lehrlinge[0];
            
            //l.GrabeLoch(irgendwasZumGraben); 
            this.ErteileAnweisung(l, irgendwasZumGraben);
        }


        public void ErteileAnweisung(Lehrling l, IWerkzeug irgendwasZumGraben){    
            System.Console.WriteLine($"{l.Name} stöhnt ...");        
            l.GrabeLoch(irgendwasZumGraben); 
            if (irgendwasZumGraben is TNT)
            {
                Lehrlinge.RemoveAt(0);
            }
        }

        public void LehrlingEinstellen(string name){
            Lehrlinge.Add(new Lehrling() { Name = name });
        }
    }

    class Lehrling{
        public string Name { get; set; }

        public void GrabeLoch(IWerkzeug irgendwasZumGraben){
            irgendwasZumGraben.Graben();
        }

    }

    class Schaufel: IWerkzeug
    {
        public void Graben(){

            for (int i = 0; i < 3; i++)
            {
                System.Console.WriteLine( "Die Schaufel dringt wiederwillig in das Erdreich ein");
                System.Console.WriteLine( "Die Schaufel wird zusammen mit der Erde herausgehoben");
                System.Console.WriteLine( "Die Erde wird auf einen Haufen abgelegt" );
                System.Console.WriteLine( "======================================================");    
            }
            System.Console.WriteLine( "Das Loch ist da und Erde liegt neben dem Loch");
            System.Console.WriteLine(  "**********************************************************" );
        }
            
    }


    class TNT: IWerkzeug
    {
        public void Graben(){
            System.Console.WriteLine( "Der Lehrling steckt TNT in die Erde");
            System.Console.WriteLine( );

            for (int i = 0; i < 3; i++)
            {
                System.Console.WriteLine( "Der Lehrling studiert flüchtig die Gebrauchsanweisung ...");                
                System.Console.WriteLine(  "Nichts passiert!");
                System.Console.WriteLine( "Der Lehrling stapft enttäuscht mit dem Fuß auf" );
                System.Console.WriteLine( "==========================================================");    
            }
            System.Console.WriteLine(  "Es ist ein lauter Knall zu hören ...");
            System.Console.WriteLine(   );
            System.Console.WriteLine( "Das gewünschte Loch ist da und Erde liegt überall herum");
            System.Console.WriteLine( "Der Lehrling ist nicht mehr da ..." );
            System.Console.WriteLine(  "************************************************************" );
        }
            
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Dependency Injection!");

            Meister meisterLampe = new Meister();
            meisterLampe.LehrlingEinstellen("Kevin");
            meisterLampe.LehrlingEinstellen("Jequeline");
            meisterLampe.WerArbeitetBeiDir();
            meisterLampe.ErteileAnweisung(new TNT());
            meisterLampe.WerArbeitetBeiDir();  

            meisterLampe.ErteileAnweisung(new Schaufel()); 
            meisterLampe.WerArbeitetBeiDir();  
                     
            Console.ReadLine( );
        }
    }
}

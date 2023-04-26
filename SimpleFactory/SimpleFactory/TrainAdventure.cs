using System;

namespace SimpleFactory
{
    public class TrainAdventure
    {
        public IAdventurer Training(String type){
            switch(type){
                case "archer" : {
                    return new Archer();             
                }
                case "warrior": {
                    return new Warrior();                
                }
                
                default : 
                    return null;
            }
        }
    }
}
using System;

namespace IA
{
    class Program
    {
        static void Main(string[] args)
        {
            int action = 0; 
            char[,] rooms = new char[3,3];
            bool[,] roomStatus = new bool[3,3];
            for(int i =0;i<3;i++){
                for(int j=0;j<3;j++){
                    rooms[i,j] = ' ';
                    roomStatus[i,j] = false;
                }
            }
            //x = Sujo
            //O = Agente
            //roomStatus serve para auxiliar na hora de checar se esta tudo limpo onde true é sujo e false é limpo
            rooms[0,2] = 'x';
            roomStatus[0,2] = true;
            rooms[1,0] = 'x';
            roomStatus[1,0] = true;
            rooms[2,1] = 'x';
            roomStatus[2,1] = true;
            Robot agente = new Robot(0,0);
            bool allClear = false; //False = Tudo sujo; True = Tudo Limpo
            rooms[agente.MyY,agente.MyX] = 'O';
            Console.WriteLine("Ações Tomadas:" + action);
            while(allClear == false){

                print(rooms);
                rooms[agente.MyY,agente.MyX] = ' ';
                agente.Movement();
                action++;
                if(roomStatus[agente.MyY,agente.MyX]==true){
                    roomStatus[agente.MyY,agente.MyX]=false;
                }
                rooms[agente.MyY,agente.MyX] = 'O';
                System.Threading.Thread.Sleep(500);
                Console.WriteLine(' ');
                allClear = checkRoomStatus(roomStatus,allClear);
                Console.WriteLine("Ações Tomadas:" + action);
                if(allClear==true){
                    print(rooms);
                }
            }
        }

        static void print(char[,] rooms){
                for(int i =0;i<3;i++){
                    Console.WriteLine("");
                    for(int j=0;j<3;j++){
                        Console.Write("|  "+rooms[i,j]+"  |");
                    }
                    Console.WriteLine("");
                }
        }

        static bool checkRoomStatus(bool[,] roomStatus,bool allClear){
            bool breaker = false;
            for(int i =0;i<3;i++){
                for(int j=0;j<3;j++){
                    if(roomStatus[i,j]==false){
                        allClear = true;
                    }
                    else if(roomStatus[i,j]==true){
                        allClear = false;
                        breaker = true;
                        break;
                    }
                }
                if(breaker==true){
                    break;
                }
            }
            return allClear;
        }
    }
}
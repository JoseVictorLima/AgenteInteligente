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
            Console.WriteLine("Escolha 3 salas sujas de 2 a 9");
            for(int i = 0;i<3;i++){
                int room = Int32.Parse(Console.ReadLine());
                switch(room){
                    // case 1 : 
                    //     if(rooms[0,0]=='x'){
                    //         Console.WriteLine("A sala já foi escolhida");
                    //         i--;
                    //     }
                    //     else rooms[0,0] = 'x';
                    //     break;
                    case 2 : 
                        if(rooms[0,1]=='x'){
                            Console.WriteLine("A sala já foi escolhida");
                            i--;
                        }
                        else rooms[0,1] = 'x';
                        break;
                    case 3 : 
                        if(rooms[0,2]=='x'){
                            Console.WriteLine("A sala já foi escolhida");
                            i--;
                        }
                        else rooms[0,2] = 'x';
                        break;
                    case 4 : 
                        if(rooms[1,0]=='x'){
                            Console.WriteLine("A sala já foi escolhida");
                            i--;
                        }
                        else rooms[1,0] = 'x';
                        break;
                    case 5 : 
                        if(rooms[1,1]=='x'){
                            Console.WriteLine("A sala já foi escolhida");
                            i--;
                        }
                        else rooms[1,1] = 'x';
                        break;
                    case 6 : 
                        if(rooms[1,2]=='x'){
                            Console.WriteLine("A sala já foi escolhida");
                            i--;
                        }
                        else rooms[1,2] = 'x';
                        break;
                    case 7 : 
                        if(rooms[2,0]=='x'){
                            Console.WriteLine("A sala já foi escolhida");
                            i--;
                        }
                        else rooms[2,0] = 'x';
                        break;
                    case 8 : 
                        if(rooms[2,1]=='x'){
                            Console.WriteLine("A sala já foi escolhida");
                            i--;
                        }
                        else rooms[2,1] = 'x';
                        break;
                    case 9 : 
                        if(rooms[2,2]=='x'){
                            Console.WriteLine("A sala já foi escolhida");
                            i--;
                        }
                        else rooms[2,2] = 'x';
                        break;
                    default : 
                        Console.WriteLine("Sala Invalida");
                        i--;
                        break;
                }
            }
            for(int i =0;i<3;i++){
                for(int j=0;j<3;j++){
                    if(rooms[i,j]=='x')roomStatus[i,j] = true;
                }
            }
            // rooms[0,2] = 'x';
            // roomStatus[0,2] = true;
            // rooms[1,0] = 'x';
            // roomStatus[1,0] = true;
            // rooms[2,1] = 'x';
            // roomStatus[2,1] = true;
            Robot agente = new Robot(0,0);
            bool allClear = false; //False = Tudo sujo; True = Tudo Limpo
            rooms[agente.MyY,agente.MyX] = 'O';
            while(allClear == false){
                Console.WriteLine("Ações Tomadas:" + action);
                print(rooms);
                rooms[agente.MyY,agente.MyX] = ' ';
                if(allClear!=true){
                    roomStatus[agente.MyY,agente.MyX] = agente.Movement(roomStatus[agente.MyY,agente.MyX]);
                    action++;
                    rooms[agente.MyY,agente.MyX] = 'O';
                }
                System.Threading.Thread.Sleep(500);
                Console.WriteLine(' ');
                allClear = checkRoomStatus(roomStatus,allClear);
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
using System;
using System.Collections.Generic;

namespace IA{
    class Robot{
        List<memoryClass> memory = new List<memoryClass>();
        public int MyX{get;set;}
        public int MyY{get;set;}
        public int OldX{get;set;}
        public int OldY{get;set;}   
        public Robot(int x,int y){
            MyX = x;
            MyY = y;
        }

        public bool Movement(bool roomStatus){
            bool cleaning = false; // Serve para indicar que o agente limpou uma sala
            int direct = 0;
            object position = new object();
            bool noError = false;
            int[] blockedRoutes = new int[4];// serve para impedir o agente de tentar executar uma mesma ação infinitamente
            int routeIndex = 0;
            if(roomStatus ==  true){
                roomStatus = false;
                cleaning = true;
            }
            while(noError==false){
                Random random = new Random();
                direct  = random.Next(1,5);
                bool takeAnotherDirect = false; //Serve para impedir loop 
                foreach(int route in blockedRoutes){
                    if(direct == route){
                        takeAnotherDirect = true;
                    }
                }
                // 1 = esquerda | 2 = baixo | 3 = direita | 4 = cima
                if(takeAnotherDirect==false){
                    if(direct == 1){
                        if(MyX - 1 >= 0){
                            if(consulingMemory(MyX,MyY,direct)){
                                OldX = MyX;
                                OldY = MyY;
                                MyX = MyX - 1;
                                noError = true;
                                // Console.WriteLine("Esquerda");
                            } else{
                                blockedRoutes[routeIndex] = direct;
                                routeIndex++;
                            }
                        }
                    } else if(direct == 2){
                        if(MyY + 1 <= 2){
                            if(consulingMemory(MyX,MyY,direct)){
                                OldX = MyX;
                                OldY = MyY;
                                MyY = MyY + 1;
                                noError = true;
                                // Console.WriteLine("Baixo");
                            } else{
                                blockedRoutes[routeIndex] = direct;
                                routeIndex++;
                            }
                        }
                    }  else if(direct == 3){
                        if(MyX + 1 <= 2){
                             if(consulingMemory(MyX,MyY,direct)){
                                OldX = MyX;
                                OldY = MyY;
                                MyX = MyX + 1;
                                noError = true;
                                // Console.WriteLine("Direita");
                            } else{
                                blockedRoutes[routeIndex] = direct;
                                routeIndex++;
                            }
                        }
                    }  else if(direct == 4){
                        if(MyY - 1 >= 0){
                            if(consulingMemory(MyX,MyY,direct)){
                                OldX = MyX;
                                OldY = MyY;
                                MyY = MyY - 1;
                                noError = true;
                                // Console.WriteLine("Cima");
                            } else{
                                blockedRoutes[routeIndex] = direct;
                                routeIndex++;
                            }
                        }
                    }
                }
            }
            if(cleaning==true){
                AddigInMemory(direct);
            }
            return roomStatus;
        }

        public void AddigInMemory(int lastAction){
            var pieceOfMemory = new memoryClass();
            pieceOfMemory.X = OldX;
            pieceOfMemory.Y = OldY;
            pieceOfMemory.Action = lastAction;
            this.memory.Add(pieceOfMemory);
        }

        public bool consulingMemory(int x, int y,int action){
            bool goThisWay = true;
            foreach(var pieceOfMemory in this.memory){
                if((x == pieceOfMemory.X)&&(y==pieceOfMemory.Y)&&(action==pieceOfMemory.Action)){
                    goThisWay = false;
                }
            }
            return goThisWay;
        }
    }

    class memoryClass{
        public int X{get;set;}
        public int Y{get;set;}
        public int Action{get;set;}
    }
}
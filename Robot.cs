using System;

namespace IA{
    class Robot{
        public int MyX{get;set;}
        public int MyY{get;set;}
        public Robot(int x,int y){
            MyX = x;
            MyY = y;
        }

        public void Movement(){
            object position = new object();
            bool noError = false;
            while(noError==false){
                Random random = new Random();
                var direct  = random.Next(0,4);
                // 0 = esquerda | 1 = baixo | 2 = direita | 3 = cima
                if(direct == 0){
                    if(MyX - 1 >= 0){
                        MyX = MyX - 1;
                        noError = true;
                        // Console.WriteLine("Esquerda");
                    }
                } else if(direct == 1){
                    if(MyY + 1 <= 2){
                        MyY = MyY + 1;
                        noError = true;
                        // Console.WriteLine("Baixo");
                    }
                }  else if(direct == 2){
                    if(MyX + 1 <= 2){
                        MyX = MyX + 1;
                        noError = true;
                        // Console.WriteLine("Direita");
                    }
                }  else if(direct == 3){
                    if(MyY - 1 >= 0){
                        MyY = MyY - 1;
                        noError = true;
                    }
                }
            }
        }
    }
}
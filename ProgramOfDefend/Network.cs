using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProgramOfDefend
{
    class Network
    {
        public string filePath { get; set; }
        public double KoefOfNetwork { get; set; }
        public List<Node> ListOfNodes;
        public List<Node> SortListOfNodes;
        public int Counter { get; set; }
        

        public Network(string filePath)
        {
            Counter = 0;
            this.filePath = filePath;
            ListOfNodes = new List<Node>();
            ReadFromFile(this.filePath);
            SortTheListOfNodes();
            CalkKoefOfNet();

            


        }
        // Читаем данные с текстового файла
        public void ReadFromFile(string filepath)
        {
            StreamReader sr = File.OpenText(filePath);
            while (!sr.EndOfStream)
            {
                this.AddEntryFromFileLine(sr.ReadLine());
            }
        }
        //Проверяем последовательность и наличие узлов защиты в хосте.
        public bool Checking(int X)
        {
            
                switch (X)
                {
                    case 1:

                    if (X == Counter || X == Counter + 1 || Counter == 3)
                    {
                        Counter = X;
                        return true;
                    }
                    else return false;

                    case 2:
                        if (X == Counter || X == Counter + 1)
                        {
                            Counter = X;
                            return true;
                        }
                    else return false;
                    
                    case 3:
                        if (Counter == X || X == Counter + 1)
                        {
                            Counter = X;
                            return true;
                        }
                    else return false;
                    
                    default:
                        return false;
                        

                }
            
            
        }

        //Добавляэм данные из строки в файле
        public bool AddEntryFromFileLine(string line)
        {
            string[] fields = line.Split(',');
            int X = int.Parse(fields[1]);


            if (Checking(X)) //Проверяем последовательность наличие и последовательность узлов защиты в хосте.
            {

                try
                {
                    Node one = new Node(int.Parse(fields[0]));

                    switch (fields[1])
                    {

                        case "1":
                            for (int i = 2; i < fields.Length; i += 2)
                            {

                                ParamOfKoef First = new ParamOfKoef(double.Parse(fields[i]), double.Parse(fields[i + 1]));
                                one.NumberOfKoefInNode = 1;
                                one.ListK1.Add(First);

                            }
                            break;
                        case "2":
                            for (int i = 2; i < fields.Length; i += 2)
                            {
                                ParamOfKoef Second = new ParamOfKoef(double.Parse(fields[i]), double.Parse(fields[i + 1]));
                                one.NumberOfKoefInNode = 2;
                                one.ListK2.Add(Second);
                            }
                            break;
                        case "3":
                            for (int i = 2; i < fields.Length; i += 2)
                            {
                                ParamOfKoef third = new ParamOfKoef(double.Parse(fields[i]), double.Parse(fields[i + 1]));
                                one.NumberOfKoefInNode = 3;
                                one.ListK3.Add(third);
                            }
                            break;

                    }
                    ListOfNodes.Add(one);



                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message + " System isn`t protected");
                    return false;

                }
                catch (Exception a)
                {
                    Console.WriteLine(a.Message);
                    return false;
                }
                return true;
            }
            else return false;
        }
        public void SortTheListOfNodes()
        {
            Node Exemple = new Node(ListOfNodes[0].NumberOfNode);
            foreach (Node el in ListOfNodes)
            {
                if(Exemple.NumberOfNode == el.NumberOfNode)
                {
                    switch(el.NumberOfKoefInNode)
                    {
                        case 1:
                            Exemple.ListK1 = el.ListK1;
                            break;
                        case 2:
                            Exemple.ListK2 = el.ListK2;
                            break;
                        case 3:
                            Exemple.ListK3 = el.ListK3;
                            SortListOfNodes.Add(Exemple);
                            break;
                    }

                }
                else
                {
                    
                    Exemple.NumberOfNode = el.NumberOfNode;
                    Exemple.ListK1 = el.ListK1;

                }
            }
        }
        public void AddElementInNode(int numOfNode, int numOfCoef, double A, double M)
        {
            switch(numOfCoef)
            {
                case 1:
                    SortListOfNodes[numOfNode - 1].ListK1.Add(new ParamOfKoef(A, M));
                    SortListOfNodes[numOfNode - 1].CountKoef();
                    break;
                case 2:
                    SortListOfNodes[numOfNode - 1].ListK2.Add(new ParamOfKoef(A, M));
                    SortListOfNodes[numOfNode - 1].CountKoef();
                    break;
                case 3:
                    SortListOfNodes[numOfNode - 1].ListK3.Add(new ParamOfKoef(A, M));
                    SortListOfNodes[numOfNode - 1].CountKoef();
                    break;

            }
        }
        public void CalkKoefOfNet()
        {
            foreach(Node el in SortListOfNodes)
            {
                KoefOfNetwork *= el.KoefOfNode;
            }
        }
        
    }
}

using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab9
{
 
    interface IOrderedDictionary
    {

        void Add(object value);
        bool Contains(object value); // проверка наличия элемента в коллекции
        void Remove(); // удаление элемента из коллекции
        void Print();

    }
    class Collection<T>:IOrderedDictionary
    {
        public Queue<T> queue = new Queue<T>();
        public void Add(object value) 
        {
            queue.Enqueue((T)value);
        }
        public void Remove()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Удаление элемента из очереди (первый элемент): " + queue.Dequeue());
            Console.ResetColor();
        }
        public bool Contains(object value)
        {
            return queue.Contains((T)value);
        }

         public void Print()
        {
            Console.Write("Очередь:");
            foreach (var item in queue)
            {
                Console.Write($"{item},");
            }
        }
        public T Value(int index)
        {
            return queue.ElementAt((int)index);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Services services1 = new Services("Housing and communal", 100);
            Services services2 = new Services("Construction", 200);
            Services services3 = new Services("technical", 150);
            Services services4 = new Services("Heat supply", 250);
            Collection<Services> myCollection = new Collection<Services>();
            myCollection.Add(services1);
            myCollection.Add(services2);
            myCollection.Add(services3);
            myCollection.Print();
            Console.WriteLine();
            myCollection.Remove();  
            Console.WriteLine($"{myCollection.Contains(services2)}");
            myCollection.Print();
            Console.WriteLine();

            Collection<int> myCollection1= new Collection<int>();
            for (int i = 0; i < 10; i++)
            {
                myCollection1.Add(i);
            }
            myCollection1.Print();
            Console.WriteLine();
            Console.Write("Какое количество элементов удалить из очереди?");
            int userNumb = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i <userNumb ; i++)
            {
                myCollection1.Remove();
            }
            myCollection1.Print();
            Console.WriteLine();
            for(int i = 100; i < 110; i++)
            {
                myCollection1.Add(i);
            }
            myCollection1.Print();
            Console.WriteLine();
            List<int> list = new List<int>();

            for (int i = 0; i < myCollection1.queue.Count; i++)
            {
                list.Add(myCollection1.Value(i));
            }
            Console.Write("Вторая коллекция:");
            foreach (var item in list)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine();
            Console.Write("Введите индекс элемента:");
            int ind = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < list.Count; i++)
            {
                if (ind == i)
                {
                    Console.WriteLine($"Элемент есть в списке:{list[i]}");
                }
            }
            var myCollection2 = new ObservableCollection<Services>();
            myCollection2.CollectionChanged += Collection3_CollectionChanged;
            myCollection2.Add(services4);
            myCollection2.Remove(services4);
            void Collection3_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Console.WriteLine($"Добавлен новый объект:{services4}");
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        Console.WriteLine($"Удален объект:{services4}");
                        break;
                }
            }
        }
    }
}


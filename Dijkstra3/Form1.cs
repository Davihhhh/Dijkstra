using System.Threading;

namespace Dijkstra3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
        private bool check = false;
        public void Main()
        {
            int vertici = 5;
            SimpleGraph g = new SimpleGraph(vertici);

            g.SetWeight(1, 3, 2);
            g.SetWeight(1, 2, 1);
            g.SetWeight(2, 3, 3);
            g.SetWeight(2, 4, 3);
            g.SetWeight(3, 5, 4);
            g.SetWeight(3, 4, 2);
            g.SetWeight(4, 5, 5);

            //Dictionary<int, double> t = Strade_Dijkstra(g, 1, vertici);

            Dijkstra(g, vertici);

            /*
            for (int i = 0; i < vertici; i++)
            {
                Console.WriteLine($"percorso minimo per raggiungere il nodo {i + 1}: {t[i + 1]}");
            }
            */
        }
        public void RandomNodes()
        {
            Random rnd = new Random();

            int vertici = rnd.Next(2, 9);
            int maxnodes = (vertici * vertici) - vertici;

            SimpleGraph g = new SimpleGraph(vertici);

            for (int a = 0; a < maxnodes; a++)
            {
                g.SetWeight(rnd.Next(1, vertici + 1), rnd.Next(1, vertici + 1), rnd.Next(1, 100));
            }

            Dijkstra(g, vertici);
        }

        public void Dijkstra(SimpleGraph g, int vertici)
        {
            check = true;
            double[,] tabella = new double[vertici + 1, vertici + 1];
            List<int> nodi = g.GetVertices();
            ListViewItem riga = new ListViewItem("");           
            



            //Console.Write("   ");
            listView1.Columns.Add(" ");
            for (int a = 0; a < vertici; a++)
            {
                //Console.Write("N" + (a + 1) + "  ");              
                listView1.Columns.Add("N" + nodi[a].ToString());
            }
            //Console.WriteLine();
            

            for (int a = 1; a <= vertici; a++)
            {
                List<int> temp = g.GetNeighbors(a);
                double peso = 0;
                string[] pezzi = new string[vertici + 1];
                //Console.Write("N" + a + " ");

                pezzi[0] = "N" + a;

                for (int b = 1; b <= vertici; b++)
                {
                    if (a == b)
                    {
                        tabella[a, b] = 0;
                        pezzi[b] = "0";
                    }
                    else
                    {
                        peso = g.GetWeight(a, b);                       
                        tabella[a, b] = peso;
                        pezzi[b] = peso.ToString();
                    }
                    //Console.Write(tabella[a, b] + "   ");                  
                }
                //Console.WriteLine();
                riga = new ListViewItem(pezzi);
                listView1.Items.Add(riga);
            }
        }

        public Dictionary<int, double> Strade_Dijkstra(SimpleGraph g, int start, int vertici)
        {
            PriorityQueue<int, double> p = new PriorityQueue<int, double>();
            Dictionary<int, double> strade = new Dictionary<int, double>();

            for (int i = 1; i <= vertici; i++)
            {
                if (i == start)
                    strade[i] = 0;
                else
                    strade[i] = double.PositiveInfinity;
            }

            p.Enqueue(start, 0);

            while (p.Count != 0)
            {
                int a = p.Dequeue();
                List<int> vicini = g.GetNeighbors(a);

                for (int i = 0; i < vicini.Count; i++)
                {
                    double peso = g.GetWeight(a, vicini[i]);
                    if (strade[a] + peso < strade[vicini[i]])
                    {
                        strade[vicini[i]] = (strade[a] + peso);
                        p.Enqueue(vicini[i], strade[vicini[i]]);
                    }
                }
            }
            return strade;
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!check)
                Main();
            else
                MessageBox.Show("Pulisci prima la lista!");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            if (!check)
                RandomNodes();
            else
                MessageBox.Show("Pulisci prima la lista!");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (check)
            {
                listView1.Clear();
                check = false;
            }
            else
                MessageBox.Show("Già pulita!");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
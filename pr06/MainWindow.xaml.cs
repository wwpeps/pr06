using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr06
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int[] mass = new int[1000];
        int[] mass1 = new int[1000];
        int[] mass2 = new int[1000];
        int[] mass3 = new int[1000];
        int[] mass4 = new int[1000];

        Random rand = new Random();

        public static int n;

        public static int t;

        public MainWindow()
        {
            InitializeComponent();
            n = rand.Next(10, 20);
            zap(mass);
            pub(mass1);
            pub(mass2);
            pub(mass3);
            pub(mass4);

            for (int i = 0; i < n; i++) 
            {
                ta.Text += mass[i].ToString() + Environment.NewLine;
            }
            t = 0;
        }

        public static void zap(int[] mass) 
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                mass[i] = rand.Next(-5,5);
            }
        }

        public static void pub(int[] arr) 
        {
            for (int i = 0; i < n; i++) 
            {
                arr[i] = mass[i];
            }
        }

        public static void bbsort(int[] Array)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n-1; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        int temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                        t += 1;
                    }
                }
            }
        }

        public static void insort(int[] array)
        {
            for (int i = 1; i < n; i++)
            {
                int cur = array[i];
                int j = i;
                while (j > 0 && cur < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = cur;
                t += 1;
            }
        }

        public static void selsort(int[] Array)
        {
            for (int i = 0; i < n - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (Array[j] < Array[min])
                    {
                        min = j;
                    }
                }
                int dummy = Array[i];
                Array[i] = Array[min];
                Array[min] = dummy;
                min = i;
                t += 1;
            }
        }

        public static int part(int[] Array, int start, int end)
        {
            int temp;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (Array[i] < Array[end]) 
                {
                    temp = Array[marker]; 
                    Array[marker] = Array[i];
                    Array[i] = temp;
                    marker += 1;
                }
                t += 1;
            }
            temp = Array[marker];
            Array[marker] = Array[end];
            Array[end] = temp;
            return marker;
        }

        public static void quisort(int[] Array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = part(Array, start, end);
            quisort(Array, start, pivot - 1);
            quisort(Array, pivot + 1, end);
        }

        private void ba_Click(object sender, RoutedEventArgs e)
        {
            bbsort(mass4);
            for (int i = 0; i < n; i++) 
            {
                tb.Text += mass4[i].ToString() + Environment.NewLine;
            }
            tc.Text = t.ToString();
            t = 0;
        }

        private void bb_Click(object sender, RoutedEventArgs e)
        {
            insort(mass1);
            for (int i = 0; i < n; i++)
            {
                tb.Text += mass1[i].ToString() + Environment.NewLine;
            }
            td.Text = t.ToString();
            t = 0;
        }

        private void bd_Click(object sender, RoutedEventArgs e)
        {
            selsort(mass2);
            for (int i = 0; i < n; i++)
            {
                tb.Text += mass2[i].ToString() + Environment.NewLine;
            }
            tv.Text = t.ToString();
            t = 0;
        }

        private void bc_Click(object sender, RoutedEventArgs e)
        {
            quisort(mass3, 0, n);
            for (int i = 0; i < n; i++)
            {
                tb.Text += mass3[i].ToString() + Environment.NewLine;
            }
            tq.Text = t.ToString();
            t = 0;
        }
    }
}

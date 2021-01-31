/*
 *  Jun Yoo
 *  Summer 2018 Final
 *  This program will visualize each sorting algorithm process.
 *  
 */


using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Sort_o_matic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected const int length = 40;
        protected const double xscale = 600 / length;
        protected const double yscale = 380 / length;
        private Random ran = new Random();
        double[] nums = new double[length];
        Rectangle[] list = new Rectangle[length];
        private SolidColorBrush whiteBrush, redBrush, greenBrush, orangeBrush;
        private Thread shufflingThread, sortingThread;

        public MainWindow()
        {
            InitializeComponent();
            whiteBrush = new SolidColorBrush(Colors.White);
            redBrush = new SolidColorBrush(Colors.Red);
            greenBrush = new SolidColorBrush(Colors.Green);
            orangeBrush = new SolidColorBrush(Colors.Orange);
            Draw();

        }

        private void Draw()
        {
            SortCanvas.Children.Clear();
            for (int i = 0; i < list.Length; i++)
            {
                nums[i] = i;
                list[i] = new Rectangle()
                {
                    Width = xscale / 1.1,
                    Height = yscale * i,
                    StrokeThickness = 1,
                    Fill = whiteBrush
                };
                SortCanvas.Children.Add(list[i]);
                Canvas.SetBottom(list[i], 16);
                Canvas.SetLeft(list[i], xscale * i);
            }
        }

        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            shufflingThread = new Thread(delegate ()
            {
                nums = Shuffle(nums);
            });
            shufflingThread.Start();
        }

        private void SelectionSortButton_Click(object sender, RoutedEventArgs e)
        {
            sortingThread = new Thread(delegate ()
            {
                nums = SelectionSort(nums);
            });
            sortingThread.Start();
        }

        private void BubbleSortButton_Click(object sender, RoutedEventArgs e)
        {
            sortingThread = new Thread(delegate ()
            {
                nums = BubbleSort(nums);
            });
            sortingThread.Start();
        }
        private void InsertionSortButton_Click(object sender, RoutedEventArgs e)
        {
            sortingThread = new Thread(delegate ()
            {
                nums = InsertionSort(nums);
            });
            sortingThread.Start();
        }
        private void QuickSortButton_Click(object sender, RoutedEventArgs e)
        {
            sortingThread = new Thread(delegate ()
            {
                QuickSort(nums,0,nums.Length-1);
            });
            sortingThread.Start();
        }
        private void MergeSortButton_Click(object sender, RoutedEventArgs e)
        {
            sortingThread = new Thread(delegate ()
            {
                MergeSortRecursion(nums, 0, nums.Length - 1);
            });
            sortingThread.Start();
        }

        private double[] Shuffle(double[] arr)
        {
            int i = list.Length;
            while (i > 1)
            {
                i--;
                int j = ran.Next(i + 1);
                SetRed(i);
                SetRed(j);
                Swap(i, j);
                SetWhite(i);
                SetWhite(j);
            }
            return arr;
        }

        private void SetRed(int i)
        {
            this.Dispatcher.Invoke(() =>
            {
                list[i].Fill = redBrush;
            });
        }

        private void SetWhite(int i)
        {
            this.Dispatcher.Invoke(() =>
            {
                list[i].Fill = whiteBrush;
            });
        }

        private void SetGreen(int i)
        {
            this.Dispatcher.Invoke(() =>
            {
                list[i].Fill = greenBrush;
            });
        }
        private void SetOrange(int i)
        {
            this.Dispatcher.Invoke(() =>
            {
                list[i].Fill = orangeBrush;
            });
        }

        private double[] BubbleSort(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                SetGreen(i);
                Thread.Sleep(10);
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    SetGreen(j);
                    Thread.Sleep(10);
                    if (arr[j] > arr[j + 1])
                    {
                        SetRed(j);
                        SetRed(j + 1);
                        Thread.Sleep(10);
                        Swap(j, j + 1);
                        SetWhite(j);
                        SetWhite(j + 1);
                        Thread.Sleep(10);
                    }
                    SetWhite(j);
                    Thread.Sleep(10);
                }
                SetWhite(i);
                Thread.Sleep(10);
            }
            return arr;
        }

        private double[] SelectionSort(double[] arr)
        {
            int i, j;
            for (i = nums.Length - 1; i > 0; i--)
            {
                int first = 0;
                SetGreen(first);
                Thread.Sleep(10);
                for (j = 1; j <= i; j++)
                {
                    SetGreen(j);
                    Thread.Sleep(10);
                    if (nums[j] > nums[first])
                    {
                        first = j;
                    }
                    SetWhite(j);
                    Thread.Sleep(10);
                }
                SetRed(first);
                SetRed(i);
                Swap(first, i);
                Thread.Sleep(10);
                SetWhite(i);
                SetWhite(first);
                Thread.Sleep(10);
                j--;
            }
            return arr;
        }

        private double[] InsertionSort(double[] arr)
        {
            for(int i = 0; i < arr.Length - 1; i++)
            {
                SetGreen(i);
                Thread.Sleep(10);
                int j = i + 1;
                while(j > 0)
                {
                    SetGreen(j);
                    Thread.Sleep(10);
                    if (arr[j-1] > arr[j])
                    {
                        SetRed(j);
                        SetRed(j - 1);
                        Thread.Sleep(10);
                        Swap(j, j - 1);
                        SetWhite(j);
                        SetWhite(j - 1);
                        Thread.Sleep(10);
                    }
                    SetWhite(j);
                    Thread.Sleep(10);
                    j--;
                }
                SetWhite(i);
                Thread.Sleep(10);
            }
            return arr;
        }

        private void QuickSort(double[] arr, int left, int right)
        {
            int i = left, j = right;
            double pivot = arr[(left + right) / 2];
            SetOrange((int)pivot);
            Thread.Sleep(10);
            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0)
                {
                    SetWhite(i);
                    Thread.Sleep(10);
                    i++;
                    SetGreen(i);
                    Thread.Sleep(10);
                }

                while (arr[j].CompareTo(pivot) > 0)
                {
                    SetWhite(j);
                    Thread.Sleep(10);
                    j--;
                    SetGreen(j);
                    Thread.Sleep(10);
                }

                if (i <= j)
                {
                    SetRed(i);
                    SetRed(j);
                    Thread.Sleep(10);
                    Swap(i,j);
                    SetWhite(i);
                    SetWhite(j);
                    Thread.Sleep(10);
                    i++;
                    j--;
                }
            }
            SetWhite((int)pivot);
            if (left < j)
            {
                QuickSort(arr, left, j);
            }

            if (i < right)
            {
                QuickSort(arr, i, right);
            }
        }

        private void MergeSortRecursion(double[] arr, int left, int right)
        {
            SetGreen(left);
            if (left < right)
            {
                int m = left + (right - left) / 2;
                MergeSortRecursion(arr, left, m);
                MergeSortRecursion(arr, m + 1, right);
                Merge(arr, left, m, right);
            }
        }

        private void Merge(double[] arr, int left, int mid, int right)
        {
            int i, j, k;
            int n1 = mid - left + 1;
            int n2 = right - mid;
            double[] L = new double[n1];
            double[] R = new double[n2];

            for (i = 0; i < n1; i ++)
            {
                L[i] = arr[left + i];
            }
            for(j = 0; j < n2; j++)
            {
                R[j] = arr[mid + 1 + j];
            }

            i = 0;
            j = 0;
            k = left;
            
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    SetRed(k);
                    Thread.Sleep(10);
                    MergeLine(k, L[i]);
                    SetWhite(k);
                    Thread.Sleep(10);
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    SetRed(k);
                    Thread.Sleep(10);
                    MergeLine(k, R[j]);
                    SetWhite(k);
                    Thread.Sleep(10);
                    j++;
                }

                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                SetRed(k);
                Thread.Sleep(10);
                MergeLine(k, L[i]);
                SetWhite(k);
                Thread.Sleep(10);
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                SetRed(k);
                Thread.Sleep(10);
                MergeLine(k, R[j]);
                SetWhite(k);
                Thread.Sleep(10);
                j++;
                k++;
            }
        }

        private void Swap(int i, int j)
        {
            double temp;
            temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
            SwapLine(i, j);
        }

        private void SwapLine(int i, int j)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
            (ThreadStart)delegate ()
            {
                double newHeight = list[i].Height;
                list[i].Height = list[j].Height;
                list[j].Height = newHeight;
            });
            Thread.Sleep(30);
        }
        private void MergeLine(int i, double h)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
            (ThreadStart)delegate ()
            {
                list[i].Height = h*yscale;
            });
            Thread.Sleep(30);
        }
        
    }
}
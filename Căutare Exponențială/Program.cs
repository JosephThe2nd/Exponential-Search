using System;

namespace Exponential_Search
{   //Program pentru căutarea unui element x într-un vector sortat
    class Program
    {

        //Metodă care returnează poziția primei apariții a lui x în vector
        static int exponentialSearch(int[] arr, int n, int x)
        {
            //verificare dacă x se află pe prima poziție
            if (arr[0] == x)
                return 0;

            //Se caută intervalul pe care trebuie făcută căutarea binară prin dublarea
            //repetată a lui i
            int i = 1;
            while (i < n && arr[i] <= x)
                i = i * 2;

            //Apelarea metodei pentru căutare binară pentru intervalul găsit
            return binarySearch(arr, i / 2, Math.Min(i, n - 1), x);
        }

        //Metodă recursivă pentru căutarea binară.
        //Returnează locația lui x în vector dacă există
        //În caz că nu există returnează -1
        static int binarySearch(int[] arr, int l, int r, int x)
        {
            if (r >= l)
            {
                //Se calculează mijlocul
                int mid = l + (r - l) / 2;

                //Dacă elementul se află în mijloc
                if (arr[mid] == x)
                    return mid;
                //Dacă elementul este mai mic decât mijlocul, acesta se poate afla
                //doar în jumătatea inferioară(în stânga)
                if (arr[mid] > x)
                    return binarySearch(arr, l, mid - 1, x);

                //Alfel, elementul poate fi doar în jumătatea superioară(în dreapta)
                return binarySearch(arr, mid + 1, r, x);
            }

            //Dacă elementul nu este găsit în vector
            return -1;
        }

        public static void Main()
        {
            int[] arr = { 2, 3, 4, 10, 40 };
            int n = arr.Length;
            int x = 10;
            int result = exponentialSearch(arr, n, x);
            if (result == -1)
                Console.Write($"Elementul {x} nu există în vector");
            else
                Console.Write($"Elementul {x} există în vector pe pozitia {result}");
        }
    }
}
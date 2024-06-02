using System;

namespace ProjetoNetwork
{
    internal class Network
    {
        private int[] parent; 
        private int numeroElementos; 

        public Network(int numeroElementos)
        {
            if (numeroElementos <= 0)
            {
                throw new ArgumentException("O número de elementos deve ser maior que zero.");
            }

            this.numeroElementos = numeroElementos;
            parent = new int[numeroElementos + 1];

            for (int i = 1; i <= numeroElementos; i++)
            {
                parent[i] = i;
            }
        }

        public bool Query(int elemento1, int elemento2)
        {
            ValidarElementos(elemento1);
            ValidarElementos(elemento2);
            return FindRoot(elemento1) == FindRoot(elemento2);
        }

        public bool Connect(int elemento1, int elemento2)
        {
            ValidarElementos(elemento1);
            ValidarElementos(elemento2);

            int root1 = FindRoot(elemento1);
            int root2 = FindRoot(elemento2);

            if (root1 == root2)
            {
                return false; 
            }

            parent[root1] = root2;
            return true;
        }

        private int FindRoot(int element)
        {
            if (parent[element] != element)
            {
                parent[element] = FindRoot(parent[element]); // Compressão de caminho
            }
            return parent[element];
        }

        private void ValidarElementos(int element)
        {
            if (element <= 0 || element > numeroElementos)
            {
                throw new ArgumentOutOfRangeException(nameof(element), "O elemento está fora do intervalo válido.");
            }
        }

        public int GetComponentCount()
        {
            int count = 0;
            for (int i = 1; i <= numeroElementos; i++)
            {
                if (parent[i] == i)
                {
                    count++;
                }
            }
            return count;
        }

        public void PrintNetwork()
        {
            Console.WriteLine("Estado atual da rede:");
            for (int i = 1; i <= numeroElementos; i++)
            {
                Console.WriteLine($"Elemento {i}: Raiz {FindRoot(i)}");
            }
        }
    }
}
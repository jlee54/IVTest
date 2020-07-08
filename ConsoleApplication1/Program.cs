using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {}

        static public List<int> Func(List<int> arg1, List<int> arg2){

            int arg1_count = arg1.Count;
            int arg2_count = arg2.Count;
            List<int> short_arr = new List<int>();
            List<int> long_arr = new List<int>();
            int short_count = 0;
            int long_count = 0;

            //Determine the shorter and longer supplied lists
            if (arg1_count < arg2_count)
            {
                short_arr = arg1;
                long_arr = arg2;
                short_count = arg1_count;
                long_count = arg2_count;
            }
            else
            {
                short_arr = arg2;
                long_arr = arg1;
                short_count = arg2_count;
                long_count = arg1_count;
            }

            int index_sum = 0;
            int index_buffer = 0;
            int offset = long_count - short_count;
            int offset_ind = 0;

            //Loop over larger list
            for (int i = long_count - 1; i >= 0; i--)
            {
                if (long_arr[i] < 0 || long_arr[i] > 9)
                {
                    throw new Exception("List items must be between 0 and 9");
                }

                index_sum = long_arr[i] + index_buffer;

                //Add (if applicable) shorter lists index value
                offset_ind = i - offset;
                if (offset_ind >= 0)
                {
                    if (short_arr[offset_ind] < 0 || short_arr[offset_ind] > 9)
                    {
                        throw new Exception("List items must be between 0 and 9");
                    }

                    index_sum += short_arr[offset_ind];
                }

                //Replace value in the longer list with the new value
                index_buffer = 0;
                if (index_sum > 9)
                {
                    long_arr[i] = index_sum % 10;
                    index_buffer++;
                }
                else
                {
                    long_arr[i] = index_sum;
                }
            }

            //If carry over extends array length, dynamically add new index
            if (index_buffer != 0)
            {
                List<int> shifted_arr = new List<int> { 1 };
                shifted_arr.AddRange(long_arr);
                return shifted_arr;
            }
            else
            {
                return long_arr;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AncestryExercise.Helpers
{
    public static class ListHelper
    {
        public static double GetMedian(List<double> list)
        {
            // copy the list into an array and sort it. if it's odd, get the middle item, if it's even, get the average of the middle items
            double[] sortedItems = (double[])list.ToArray();
            int size = sortedItems.Length;
            int middle = size / 2;
            double median = (size % 2 != 0) ? sortedItems[middle] : (sortedItems[middle] + sortedItems[middle - 1]) / 2;
            return median;
        }
    }
}
using System;
using System.Collections.Generic;

namespace SplitString
{
    class Program
    {
        static void Main(string[] args)
        {
            string strToSplit = "amelborp nu revloser arap esriuges ed nah euq senoiccurtsni ed adanedro y atinif augibma on aicneuces anu se omtirogla nu";
            
            string[] result = SplitString(strToSplit, 20);

            foreach (string str in result)
            {
                Console.WriteLine(str + " - " + str.Length);
            }
        }

        /// <summary>
        /// Divide a string into other strings, all with a given size ratio. 
        /// If it is a segment of the string, it does not match the size, then 
        /// proceed to cut the previous word in order to comply with the size provided.
        /// </summary>
        /// <param name="str">String to divide</param>
        /// <param name="size">The maximum size of each cut</param>
        /// <param name="adjust">Indicates whether you adjust the size of the cut</param>
        /// <remarks>
        /// If the parameter adjust is false and the parameter size is too small to make a cut then an 
        /// exception type ArgumentOutOfRangeException will occur.
        /// </remarks>
        /// <returns>An array of strings</returns>
        static string[] SplitString(string str, int size, bool adjust = false)
        {
            List<string> strResult = new List<string>();
            int index = 0;
            char separator = ' ';

            string strTemp = str.Trim();

            do
            {
                if (strTemp.Length <= size)
                {
                    strResult.Add(strTemp.Trim());
                    strTemp = null;
                }
                else
                {
                    index = strTemp.LastIndexOf(separator, size);

                    if (adjust && index == -1)
                    {
                        index = strTemp.IndexOf(separator);
                        if (index == -1)
                        {
                            strResult.Add(strTemp.Trim());
                            strTemp = null;
                        }
                    }

                    if (strTemp != null)
                    {
                        strResult.Add(strTemp.Substring(0, index).Trim());
                        strTemp = strTemp.Substring(index + 1).TrimStart();
                    }
                }
            } while (!string.IsNullOrEmpty(strTemp));

            return strResult.ToArray();
        }
    }
}

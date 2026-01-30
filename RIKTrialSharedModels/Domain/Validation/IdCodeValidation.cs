using System;
using System.Collections.Generic;
using System.Text;

namespace RIKTrialSharedModels.Domain.Validation
{
    public static class IdCodeValidation
    {
        /// <summary>
        /// Estonian ID validation
        /// Logic from https://et.wikipedia.org/wiki/Isikukood
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool ValidEstonianId(string id)
        {
            if (id.Length != 11) return false;

            if (!id.All(char.IsDigit)) return false;

            int[] nums = id.Select(ch => ch - '0').ToArray(); //array of each number in id.

            int checkSum = 0;

            int[] firstWeights = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };

            int[] secondWeights = {3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };

            for (int i = 0; i < 10; i++)
            {
                checkSum += nums[i] * (firstWeights[i]);
            }

            checkSum %= 11;

            if(checkSum == 10)
            {
                checkSum = 0;

                for (int i = 0; i < 10; i++)
                {
                    checkSum += nums[i] * (secondWeights[i]);
                }

                checkSum %= 11;
                if(checkSum == 10)
                {
                    checkSum = 0;
                }

                if (nums[^1] == checkSum) return true;
            }
            else
            {
                if (nums[^1] == checkSum) return true;
            }

            return false;
        }
    }
}

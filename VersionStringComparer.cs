using System;
using System.Linq;

namespace VersionStringComparer
{
    public static class VersionStringComparer
    {

        // Custom Version Format
        // Software version are stored as a string in the 
        // format [major].[minor].[build].[revision].
        // Each version part will always be non-negative integers.
        // You may see version like "2", "1.5", or "2.12.4.0.6"
        // The period is only used as a separator and does not
        // represent a decimal point.

        // Algorithm Details
        // Your algorithm should have two string input parameters:
        // version1 and version2. It should return -1 when version1
        // is less than version2, 0 when version1 = version2, and
        // 1 when version1 is greater than version2.

        // Constraints
        // All inputs can be treated as valid and the maximum version part
        // will be less than 100

        // Examples
        // "2" == "2.0" == "2.0.0" == "2.0.0.0" == "2.0.0.0.0" (returns 0 in each case)
        // "2" < "2.0.0.0.1" (returns -1)
        // "2" < "2.1" (returns -1)
        // "2.1.0" > 2.0.1" (returns 1)
        // "2.10.0.1" > 2.1.0.10: (returns 1)
        // "2.0.1" > "1.2000.1" (returns 1)
        public static int VersionCompare(string version1, string version2)
        {
            // 1. Split the version strings into arrays of each string piece separated by the period.
            string[] parts1 = version1.Split('.');
            string[] parts2 = version2.Split('.');

            // 2. Find the maximum length of the two arrays.
            // We need to find the biggest length from the parts, to properly set up our loop
            int maxPartsLength = Math.Max(parts1.Length, parts2.Length);

            // 3. Loop that will go through each part of the version strings.
            for(int i = 0; i < maxPartsLength; i++){

                // 4. Get the part value for each version string.
                int part1 = GetPartValueOrDefault(parts1, i);
                int part2 = GetPartValueOrDefault(parts2, i);

                // 6. Compare the part values and return 1 or -1 if they are not equal.
                // based on which one is bigger/smaller, we can return the proper value
                if(part1 < part2){
                    return -1;
                }
                else if (part1 > part2){
                    return 1;
                }


            }

            // 7. If we get to this point, then the version strings are equal, return 0
            return 0;
        }

        public static int GetPartValueOrDefault(string[] parts, int i){
            // 5. Get the part value for each version string.
            // if the length is bigger, then we are still having a valid index
            // when we have a valid index, Parse out the part of the string into an int
            // if the length is smaller, then we are out of bounds and we need to return 0
            if(parts.Length > i){
                return int.Parse(parts[i]);
            }
            else{
                return 0;
            }
        }
    }

}
















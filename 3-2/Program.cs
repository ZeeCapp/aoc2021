using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace _3_2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] inputData;
            string[] oxygenData, co2Data;
            int result = 0;

            inputData = (await File.ReadAllLinesAsync("./input.txt"));
            oxygenData = inputData;
            co2Data = inputData;

            //find oxygen bits
            for(int x = 0; x < oxygenData[0].Length; x++){
                char removeTriggerBit = FindOxygenRemoveBit(oxygenData, x);
                oxygenData = RemoveBadData(oxygenData, removeTriggerBit, x);

                if(oxygenData.Length == 1){
                    Console.WriteLine("Oxygen data: " + oxygenData[0]);
                    break;
                }
                else if(x == oxygenData[0].Length - 1){
                    x=-1;
                }
            } 

            //find co2 bits
            for(int x = 0; x < co2Data[0].Length; x++){
                char removeTriggerBit = FindCO2RemoveBit(co2Data, x);
                co2Data = RemoveBadData(co2Data, removeTriggerBit, x);

                if(co2Data.Length == 1){
                    Console.WriteLine("CO2 Data: " + co2Data[0]);
                    break;
                }
                else if(x == co2Data[0].Length - 1){
                    x=-1;
                }
            } 

            //calculate result from found bits
            result = Convert.ToInt32(oxygenData[0], 2) * Convert.ToInt32(co2Data[0], 2);              
            Console.WriteLine("Lifesupport rating: " + result);    
                
        }

        //returns the bit that is to be removed in the 'posX' position of the oxygen data
        static char FindOxygenRemoveBit(string[] bitData, int posX){
            int oneCount = 0;
            int zeroCount = 0;
            
            for(int y = 0; y < bitData.Length; y++){
                if((bitData[y])[posX] == '1'){
                    oneCount++;
                }
                else{
                    zeroCount++;
                }
            }

            if(oneCount >= zeroCount){
                return '0';
            }
            return '1';
        }

        //returns the bit that is to be removed in the 'posX' position of the co2 data
        static char FindCO2RemoveBit(string[] bitData, int posX){
            int oneCount = 0;
            int zeroCount = 0;
            
            for(int y = 0; y < bitData.Length; y++){
                if((bitData[y])[posX] == '1'){
                    oneCount++;
                }
                else{
                    zeroCount++;
                }
            }

            if(zeroCount <= oneCount){
                return '1';
            }
            return '0';
        }

        //removes all data from 'inputData' that have a 'removeTriggerBit' in the 'posX' position
        static string[] RemoveBadData(string[] inputData, char removeTriggerBit, int posX){                        
            List<string> localInputCopy = new List<string>(inputData);
            int currentDataLength = localInputCopy.Count;
            
            for(int y = 0; y < currentDataLength; y++){
                if(localInputCopy.Count == 1)
                    return localInputCopy.ToArray();

                if((localInputCopy[y])[posX] == removeTriggerBit){
                    localInputCopy.RemoveAt(y);
                    currentDataLength = localInputCopy.Count;
                    y-=1;
                }
            }
            return localInputCopy.ToArray();
        }
    }
}

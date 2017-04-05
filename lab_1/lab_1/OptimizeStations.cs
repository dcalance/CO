using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_1
{
    class OptimizeStations
    {
        List<ListBoxItem> fileList = new List<ListBoxItem>();
        Dictionary<string, Dictionary<string, List<TimeSpan>>> times = new Dictionary<string, Dictionary<string, List<TimeSpan>>>();
        Dictionary<string, Dictionary<string, List<TimeSpan>>> optimisedTimes;
        long optimalValue = 0;

        public OptimizeStations(params ListBoxItem[] files)
        {
            foreach (var item in files)
            {
                fileList.Add(item);
            }
            fileParse();
            optimisedTimes = new Dictionary<string, Dictionary<string, List<TimeSpan>>>(times);
            getInitialOptimalValue();
            optimiseTime();
        }
        void fileParse()
        {
            foreach (var item in fileList)
            {
                string[] lines = File.ReadAllLines(item.id);
                times[item.text] = new Dictionary<string, List<TimeSpan>>();
                foreach (var line in lines)
                {
                    string lineNoSpace = line.Replace(" ", "");
                    string[] split = lineNoSpace.Split(')');
                    if (!times[item.text].ContainsKey(split[0]))
                    {
                        times[item.text][split[0]] = new List<TimeSpan>();
                    }
                    string[] stringTimes = split[1].Split(',');
                    foreach (var time in stringTimes)
                    {
                        string[] hourMinutes = time.Split(':');
                        times[item.text][split[0]].Add(new TimeSpan(Int32.Parse(hourMinutes[0]), Int32.Parse(hourMinutes[1]), 0));
                    }
                }
            }
        }
        void getInitialOptimalValue()
        {
            Dictionary<string, List<TimeSpan>> stationTimes = new Dictionary<string, List<TimeSpan>>();
            foreach (var station in times)
            {
                stationTimes[station.Key] = new List<TimeSpan>();
                foreach (var bus in station.Value)
                {
                    stationTimes[station.Key].AddRange(bus.Value);
                }
                stationTimes[station.Key] = stationTimes[station.Key].OrderBy(x => x).ToList();
            }
            foreach (var station in stationTimes)
            {
                for (int counter = 0; counter < stationTimes[station.Key].Count - 1; counter++)
                {
                    int delayTime;
                    delayTime = (station.Value[counter + 1] - station.Value[counter]).Minutes;
                    optimalValue += Convert.ToInt64(Math.Exp(Convert.ToDouble(delayTime)));
                }
            }
        }
        Dictionary<string, List<TimeSpan>> getShiftedTimesBus(int shiftValue, string busName)
        {
            Dictionary<string, List<TimeSpan>> stationTimes = new Dictionary<string, List<TimeSpan>>();
            foreach (var station in optimisedTimes)
            {
                if (!stationTimes.ContainsKey(station.Key))
                {
                    stationTimes[station.Key] = new List<TimeSpan>();
                }
                foreach (var bus in station.Value)
                {
                    if (bus.Key == busName)
                    {
                        for (int counter = 0; counter < bus.Value.Count; counter++)
                        {
                            stationTimes[station.Key].Add(bus.Value[counter] + new TimeSpan(0, shiftValue, 0));
                        }   
                    }
                    else
                    {
                        stationTimes[station.Key].AddRange(bus.Value);
                    }
                    
                }
                stationTimes[station.Key] = stationTimes[station.Key].OrderBy(x => x).ToList();
            }
            return stationTimes;
        }
        Dictionary<string, Dictionary<string, List<TimeSpan>>> getShiftedDict(int shiftValue, string busName)
        {
            Dictionary<string, Dictionary<string, List<TimeSpan>>> resultDict = new Dictionary<string, Dictionary<string, List<TimeSpan>>>();
            foreach (var station in optimisedTimes)
            {
                resultDict[station.Key] = new Dictionary<string, List<TimeSpan>>();
                foreach (var bus in station.Value)
                {
                    resultDict[station.Key][bus.Key] = new List<TimeSpan>();
                    if (bus.Key == busName)
                    {
                        for (int counter = 0; counter < bus.Value.Count; counter++)
                        {
                            resultDict[station.Key][bus.Key].Add(bus.Value[counter] + new TimeSpan(0, shiftValue, 0));
                        }
                    }
                    else
                    {
                        resultDict[station.Key][bus.Key].AddRange(bus.Value);
                    }
                }
            }
            return resultDict;
        }
        void optimiseTime()
        {
            Dictionary<string, List<TimeSpan>> stationTimes = new Dictionary<string, List<TimeSpan>>();
            Dictionary<string, Dictionary<string, List<TimeSpan>>> optimisedDict = new Dictionary<string, Dictionary<string, List<TimeSpan>>>(optimisedTimes);
            foreach (var station in optimisedTimes)
            {
                if (!stationTimes.ContainsKey(station.Key))
                {
                    stationTimes[station.Key] = new List<TimeSpan>();
                }
                foreach (var bus in station.Value)
                {
                    for (int shiftValue = -10; shiftValue <= 10; shiftValue++) //here we shift our buses times
                    {
                        stationTimes = getShiftedTimesBus(shiftValue, bus.Key);
                    
                        long localOptimalValue = 0;
                        foreach (var item in stationTimes)
                        {
                            for (int counter = 0; counter < item.Value.Count - 1; counter++)
                            {
                                int delayTime;
                                delayTime = (item.Value[counter + 1] - item.Value[counter]).Minutes;
                                localOptimalValue += Convert.ToInt64(Math.Exp(Convert.ToDouble(delayTime)));
                            }
                        }
                        if (localOptimalValue < optimalValue)
                        {
                            optimisedDict = getShiftedDict(shiftValue, bus.Key);
                            optimalValue = localOptimalValue;
                        }
                    }
                    optimisedTimes = optimisedDict;
                }
            }
        }
        public Dictionary<string, Dictionary<string, List<int>>> getPlotData()
        {
            Dictionary<string, Dictionary<string, List<int>>> result = new Dictionary<string, Dictionary<string, List<int>>>();
            Dictionary<string, List<TimeSpan>> stationTimes = new Dictionary<string, List<TimeSpan>>();
            foreach (var station in times)
            {
                stationTimes[station.Key] = new List<TimeSpan>();
                foreach (var bus in station.Value)
                {
                    stationTimes[station.Key].AddRange(bus.Value);
                }
                stationTimes[station.Key] = stationTimes[station.Key].OrderBy(x => x).ToList();
            }
            foreach (var station in stationTimes)
            {
                if (!result.ContainsKey("Pre"))
                {
                    result["Pre"] = new Dictionary<string, List<int>>();
                }
                result["Pre"][station.Key] = new List<int>();
                for (int counter = 0; counter < stationTimes[station.Key].Count - 1; counter++)
                {
                    int delayTime;
                    delayTime = (station.Value[counter + 1] - station.Value[counter]).Minutes;
                    result["Pre"][station.Key].Add(delayTime);
                }
            }
            stationTimes = new Dictionary<string, List<TimeSpan>>();
            foreach (var station in optimisedTimes)
            {
                stationTimes[station.Key] = new List<TimeSpan>();
                foreach (var bus in station.Value)
                {
                    stationTimes[station.Key].AddRange(bus.Value);
                }
                stationTimes[station.Key] = stationTimes[station.Key].OrderBy(x => x).ToList();
            }
            foreach (var station in stationTimes)
            {
                if (!result.ContainsKey("Post"))
                {
                    result["Post"] = new Dictionary<string, List<int>>();
                }
                result["Post"][station.Key] = new List<int>();
                for (int counter = 0; counter < stationTimes[station.Key].Count - 1; counter++)
                {
                    int delayTime;
                    delayTime = (station.Value[counter + 1] - station.Value[counter]).Minutes;
                    result["Post"][station.Key].Add(delayTime);
                }
            }
            return result;
        }
        public void generateOutputFiles()
        {
            foreach (var station in optimisedTimes)
            {
                string path = $@"optimised\{station.Key}.txt";
                using (StreamWriter writetext = new StreamWriter(path))
                {
                    foreach (var bus in station.Value)
                    {
                        string line;
                        line = bus.Key + ") ";
                        foreach (var time in bus.Value)
                        {
                            line += time.Hours + ":";
                            if (time.Minutes < 10)
                            {
                                line += "0" + time.Minutes;
                            }
                            else
                            {
                                line += time.Minutes;
                            }
                            line += ", ";
                        }
                        line = line.Remove(line.Length - 2);
                        writetext.WriteLine(line);
                    }
                    
                }
            }
        }
    }
}

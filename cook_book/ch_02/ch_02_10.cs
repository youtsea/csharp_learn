using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//使用线程安全的字典
namespace cook_book.ch_02
{
    class ch_02_10
    {
        public static async void Test()
        {
            List<Fan> fansAttending = new List<Fan>();
            for (int i = 0; i < 100; i++)
            {
                fansAttending.Add(new Fan() {Name = "Fan" + i});
            }
            Fan[] fans = fansAttending.ToArray();

            int gateCount = 10;
            Task[] entryGaTasks = new Task[gateCount];
            Task[] securityMonitors = new Task[gateCount];
            for (int gateNumber = 0; gateNumber < gateCount; gateNumber++)
            {
                int GateNum = gateNumber;
                int GateCount = gateCount;
                Action action = delegate() { AdmitFans(fans, GateNum, GateCount); };
                entryGaTasks[gateNumber] = Task.Run(action);
            }

            for (int gateNumber = 0; gateNumber < gateCount; gateNumber++)
            {
                int GateNum = gateNumber;
                Action action = delegate() { MonitorGate(gateNumber); };
                securityMonitors[gateNumber] = Task.Run(action);
            }

            await Task.WhenAll(entryGaTasks);
            monitorGates = false;
        }

        private static void AdmitFans(Fan[] fans, int gateNumber, int gateCount)
        {
            Random rnd = new Random();
            int fansPerGate = fans.Length/gateCount;
            int start = gateNumber*fansPerGate;
            int end = start + fansPerGate - 1;
            for (int f = start; f <= end; f++)
            {
                Console.WriteLine($"Admitting {fans[f].Name} through gate {gateNumber}");
                var fanAtGate =
                    stadiumGates.AddOrUpdate(gateNumber, fans[f],
                        (key, fanInGate) =>
                        {
                            Console.WriteLine($"{fanInGate.Name} was replaced by " +
                                              $"{fans[f].Name} in gate {gateNumber}");
                            return fans[f];
                        });

                Thread.Sleep(rnd.Next(500, 2000));

                fans[f].Admitted = DateTime.Now;
                fans[f].AdmittanceGateNumber = gateNumber;
                Fan fanAdmitted;
                if (stadiumGates.TryRemove(gateNumber, out fanAdmitted))
                    Console.WriteLine($"{fanAdmitted.Name} entering event from gate " +
                                      $"{fanAdmitted.AdmittanceGateNumber} on " +
                                      $"{fanAdmitted.Admitted.ToShortTimeString()}");
                else 
                    Console.WriteLine($"{fanAdmitted.Name} held by security " +
                                      $"at gate {fanAdmitted.AdmittanceGateNumber}");
            }

        }

        private static void MonitorGate(int gateNumber)
        {
            Random rnd = new Random();
            while (monitorGates)
            {
                Fan currentFanInGate;
                if (stadiumGates.TryGetValue(gateNumber, out currentFanInGate))
                    Console.WriteLine($"Monitor: {currentFanInGate.Name} is in Gate " +
                        $"{gateNumber}");
                else
                    Console.WriteLine($"Monitor: No fan is in Gate {gateNumber}");
                Thread.Sleep(rnd.Next(500, 5000));
            }
        }

        private static ConcurrentDictionary<int, Fan> stadiumGates = new ConcurrentDictionary<int, Fan>();
        private static bool monitorGates = true;
    }

    public class Fan
    {
        public string Name { get; set; }
        public DateTime Admitted { get; set; }
        public int AdmittanceGateNumber { get; set; }
    }
}
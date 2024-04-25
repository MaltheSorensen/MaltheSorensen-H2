using Park_A_Lot_2000;
using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        int parkingLotCapacity = 3;
        ParkingLot parkingLot = new ParkingLot(parkingLotCapacity);
        int numCars = 10;

        Thread[] carThreads = new Thread[numCars];
        Random random = new Random();

        for (int i = 0; i < numCars; i++)
        {
            int carId = i + 1;
            int waitTime = random.Next(2000, 10000);
            carThreads[i] = new Thread(() => parkingLot.Enter(carId, waitTime));
            carThreads[i].Start();
        }

        foreach (Thread thread in carThreads)
        {
            thread.Join();
        }
    }
}
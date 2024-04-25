using System;
using System.Threading;


namespace Park_A_Lot_2000
{
    class ParkingLot
    {
        private Semaphore semaphore;

        public ParkingLot(int capacity)
        {
            semaphore = new Semaphore(capacity, capacity);
        }

        public void Enter(int carId, int waitTime)
        {
            semaphore.WaitOne();

            lock (this)
            {
                Console.WriteLine($"Car {carId} entering the parking lot...");
            }

            Thread.Sleep(waitTime);

            lock (this)
            {
                Console.WriteLine($"Car {carId} exited the parking lot!");
            }

            semaphore.Release();
        }
    }
}

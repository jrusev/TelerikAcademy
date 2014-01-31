namespace GSMTest
{
    using System;
    using System.Collections.Generic;
    using MobilePhone;

    //  Write a class GSMTest to test the GSM class:
    //    Create an array of few instances of the GSM class.
    //    Display the information about the GSMs in the array.
    //    Display the information about the static property IPhone4S.
    public class GSMTest
    {
        public static void Main()
        {
            GSM[] testPhones = new GSM[3];
            testPhones[0] = new GSM("Galaxy 4", "Samsung");
            testPhones[1] = new GSM("iPhone 5S", "Apple", new Battery("1440 mAh", 10, 3, BatteryType.LiIo), new Display(5, 16000000));
            testPhones[2] = new GSM("iPhone 5C", "Apple", 500, "John Dow", new Battery("1440 mAh", 10, 3, BatteryType.NiMH), new Display(5, 16000000));

            foreach (var phone in testPhones)
            {
                Console.WriteLine(phone);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCFinal.Domain.Data;
using GCFinal.Domain.Models.PackingModels;
using GCFinal.Domain.Models.Items;

namespace GCFinal.Services
{
    class TripPackingService
    {
        //Daily Items
        //Trip items
        //Temp 
        //Precip
        //Wind

        //switch case
        public string ItemsToPack()
        {
            var temperature = new Temperature();
            switch (temperature)
            {
                case Temperature.Hot:
                    //logic to get hot items
                    return"TODO";
                case Temperature.Warm:
                    //logic for warm items
                    return "TODO";
                case Temperature.Cool:
                    //logic for cool items
                    return "TODO";
                case Temperature.Cold:
                    //logic for cold items
                    return "TODO";
                default:
                    //cool items
                    return "TODO";
            }
        }


        public bool IsPrecipitating(decimal rainValue)
        {
            if (rainValue > 10)
            {
                return true;
            }
            return false;
        }

        public bool IsWindy(decimal windValue)
        {
            if (windValue > 10)
            {
                return true;
            }
            return false;
        }

        public Temperature DayTemp (decimal temp)
        {
            if (temp >= 80)
            {
                return Temperature.Hot;
            }

            if (temp >= 65 && temp < 79)
            {
                return Temperature.Warm;
            }

            if (temp >= 45 && temp < 64)
            {
                return Temperature.Cool;
            }
            
            return Temperature.Cold;
            
        }
    }
}

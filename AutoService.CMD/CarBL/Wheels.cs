using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.CMD.CarBL
{
    public class Wheels
    {
        //Предпололжим что здесь мы описали необходимые свойства и методы колёс


        public MechanismStatuses Status { get; set; }

        public Wheels(MechanismStatuses status = MechanismStatuses.Work)
        {
            //Это только потому что я генерирую,
            //включаться сюда не должно в нормальном проекте
            Random rnd = new Random();

            if (status == MechanismStatuses.Work)
                Status = (MechanismStatuses)rnd.Next(0, 2);
            else
                Status = status;

        }
    }
}

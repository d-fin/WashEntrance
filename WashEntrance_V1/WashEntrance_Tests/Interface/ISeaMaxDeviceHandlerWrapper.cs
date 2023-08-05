using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sealevel; 

namespace WashEntrance_Tests.Interface
{
    public interface ISeaMAXDeviceHandlerWrapper
    {
        byte[] SM_ReadDigitalInputs();
    }

    public class SeaMAXDeviceHandlerWrapper : ISeaMAXDeviceHandlerWrapper
    {
        public SeaMAX device = new SeaMAX();

        public byte[] SM_ReadDigitalInputs(int start, int quantity, byte[] input)
        {
            int err = device.SM_ReadDigitalInputs(start, quantity, input);

            return input; 
        }
    }

}

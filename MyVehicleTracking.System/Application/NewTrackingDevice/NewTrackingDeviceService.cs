using DBStorage.NewTrackingDevice;
using Domain.NewTrackingDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewTrackingDevice
{
    public class NewTrackingDeviceService : INewTrackingDeviceService
    {
        private INewTrackingDeviceRepository _newTrackingDeviceRepository;
        public NewTrackingDeviceService(NewTrackingDeviceRepository newTrackingDeviceRepository)
        {
            _newTrackingDeviceRepository = newTrackingDeviceRepository;
        }

        public IEnumerable<Domain.NewTrackingDevice.NewTrackingDevice> GetAllNewTrackingDevices()
        {
            return _newTrackingDeviceRepository.GetAllNewTrackingDevices();
        }
    }
}

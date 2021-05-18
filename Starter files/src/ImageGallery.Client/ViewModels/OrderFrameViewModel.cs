using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ImageGallery.Client.ViewModels
{
    public class OrderFrameViewModel
    {
        public AddressViewModel Address { get; private set; }

        public OrderFrameViewModel(string address)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Address = JsonSerializer.Deserialize<AddressViewModel>(address, options);
        }
    }
}
